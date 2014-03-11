using UnityEngine;
using System.Collections;

public class ThrustControll : MonoBehaviour {

	public float force = 100 ;

	Vector2 rightEnginePosition;
	Vector2 leftEnginePosition;

	public Transform leftEngine;
	public Transform rightEngine;

	public float maxVolume = 0.8f;
	float currentVolume = 0;

	bool isThrusting = false;

	public Texture aTexture;

	public GUISkin skin;

	void Update ()
	{
		rightEnginePosition = rightEngine.position;
		leftEnginePosition =  leftEngine.position;
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

		if( Input.GetAxis("ThrustR") <= 0 && Input.GetAxis("ThrustL") <= 0 && Input.touchCount <= 0)
		{
			isThrusting = false;
		}

		if(isThrusting){
			currentVolume = Mathf.Lerp(currentVolume, maxVolume,  0.2f);
		}else{
			currentVolume = Mathf.Lerp(currentVolume, 0, 0.2f);
		}

		audio.volume = currentVolume;

		float max = 1.2f;
		float min = 0.1f;
		audio.pitch = Mathf.Min(max, min +  rigidbody2D.velocity.magnitude / 90 );

	}

	private void ThrustLeft ()
	{
		rigidbody2D.AddForceAtPosition(transform.TransformDirection(Vector2.up) * force, leftEnginePosition);
	}

	private void ThrustRight ()
	{

		rigidbody2D.AddForceAtPosition(transform.TransformDirection(Vector2.up) * force, rightEnginePosition);	
	}


	void OnGUI ()
	{

		GUI.skin = skin;
//		GUI.DrawTexture(new Rect(10, 10, Screen.width/2 -20, Screen.height-20), aTexture);

		//GUI.Label(new Rect(Screen.width / 2,Screen.height/2, 300, 100), "Tap the Rigth and Left side of the screen to control the Thrust of the rocket");

//		GUI.DrawTexture(new Rect(Screen.width/2 + 10, 10, Screen.width/2-20 , Screen.height-20), aTexture);
	}
}
