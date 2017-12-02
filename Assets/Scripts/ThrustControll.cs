using UnityEngine;
using System.Collections;

public class ThrustControll : MonoBehaviour {

	public float force = 100 ;

	Vector2 rightEnginePosition;
	Vector2 leftEnginePosition;

	Rigidbody2D rb;

	public Transform leftEngine;
	public Transform rightEngine;

	public float maxVolume = 0.8f;
	float currentVolume = 0;

	bool isThrusting = false;

	public GUISkin skin;

	private bool playerStarted = false;
	public AudioSource audio;
	[SerializeField] [Range(0, 100)]float autoCorrectRatio = 1;
	[SerializeField] bool inverControls = false;

	void Awake() {
		audio = GetComponent<AudioSource> ();
		rb = GetComponent<Rigidbody2D> ();
	}

	void Update ()
	{

		if(!playerStarted && transform.position.y > 20) Invoke("PlayerStarted", 1);

	}

	void FixedUpdate ()
	{

		if (Input.touchCount > 0)
		{

			foreach (Touch touch in Input.touches)
			{
				if (touch.phase != TouchPhase.Ended && touch.phase != TouchPhase.Canceled)
				{
					if (touch.position.x < Screen.width/2)
					{
						ThrustLeft();
						isThrusting = true;
					}
					else if (touch.position.x > Screen.width/2)
					{
						ThrustRight();
						isThrusting = true;
					}
				}
			}
		}


		if ( Input.GetAxis("ThrustL") > 0 )
		{
			ThrustLeft();
			isThrusting = true;
		}

		if ( Input.GetAxis("ThrustR") > 0 )
		{
			ThrustRight();
			isThrusting = true;
		}

		if ( Input.GetAxis("ThrustR") <= 0 && Input.GetAxis("ThrustL") <= 0 && Input.touchCount <= 0)
		{
			isThrusting = false;
		}

		if (isThrusting)
		{
			currentVolume = Mathf.Lerp(currentVolume, maxVolume,  0.2f);
		} else
		{
			currentVolume = Mathf.Lerp(currentVolume, 0, 0.2f);
		}

		audio.volume = currentVolume;

		float max = 1.2f;
		float min = 0.5f;

		audio.pitch = Mathf.Min(max, min +  rb.velocity.magnitude / 90 );

		transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.identity, Time.fixedDeltaTime * autoCorrectRatio);

	}

	private void ThrustLeft ()
	{
		if(inverControls) {
			rb.AddForceAtPosition(transform.TransformDirection(Vector2.up) * force, rightEngine.position);
		} else {
			rb.AddForceAtPosition(transform.TransformDirection(Vector2.up) * force, leftEngine.position);
		}
	}

	private void ThrustRight ()
	{

		if(inverControls) {
			rb.AddForceAtPosition(transform.TransformDirection(Vector2.up) * force, leftEngine.position);
		} else {
			rb.AddForceAtPosition(transform.TransformDirection(Vector2.up) * force, rightEngine.position);
		}
	}

	void PlayerStarted()
	{
		playerStarted = true;
	}

	void OnGUI ()
	{
		if(playerStarted) return;

		GUI.skin = skin;

		GUI.Box(new Rect(0, Screen.height - 200, 300, 110),"Thrust the Left engine ");
		GUI.Box(new Rect(Screen.width - 300, Screen.height - 200 , 300, 110),"Thrust the Right engine ");
	}
}
