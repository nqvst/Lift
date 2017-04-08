using UnityEngine;
using System.Collections;

public class ProximityWarning : MonoBehaviour {

	private bool alert;
	private float distance;
	public AudioClip alertSound;
	float lastPlayed = 0;
	AudioSource audio;
	void Awake () {
		audio = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		if( alert && Time.time > lastPlayed)
		{
			audio.PlayOneShot(alertSound);
			lastPlayed = Time.time + distance * Time.deltaTime;
		}
		
	}

	void OnTriggerStay2D(Collider2D other)
	{
		if(other.transform.CompareTag("Obstacle")){
			alert = true;
			distance = Vector2.Distance(transform.position, other.transform.position);
			Debug.Log("Radar detected an obstacle " + distance.ToString("F1") + " away");
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if(other.transform.CompareTag("Obstacle")){
			alert = false;
		}
	}
}
