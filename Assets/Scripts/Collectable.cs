using UnityEngine;
using System.Collections;

public class Collectable : MonoBehaviour {

	public Transform pickUpEffectPrefab;
//	public Transform collectablePrefab;

//	public float range = 10;
//	public float frequency = 50;

	void Start () {

	}

	void Update() {
		transform.Rotate(Vector3.up * 200f * Time.deltaTime);
	}


	void OnTriggerEnter2D(Collider2D other)
	{
		Debug.Log(other.transform.tag + " - Pickup");

		if(other.transform.CompareTag("Boundries"))
		{
			Debug.Log(other.transform.tag + " - Pickup");
			Destroy(gameObject);
		} else {
			Debug.Log(other.transform.tag + " - Pickup (else)");
			Instantiate(pickUpEffectPrefab, transform.position, Quaternion.identity);
			Destroy(gameObject);
			other.transform.SendMessage("OnPickUp");

		}

	}
}
