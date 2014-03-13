using UnityEngine;
using System.Collections;

public class Collectable : MonoBehaviour {

	public Transform pickUpEffectPrefab;
	public Transform collectablePrefab;

	public float range = 10;
	public float frequency = 50;

	void Start () {
	
	}


	void OnTriggerEnter2D(Collider2D other)
	{
		Debug.Log(other.transform.tag + " - Pickup");
		if(!other.transform.CompareTag("ScrollTrigger"))
		{
			Instantiate(pickUpEffectPrefab, transform.position, Quaternion.identity);
			Instantiate(collectablePrefab, new Vector2(Random.Range(-range, range), transform.position.y + frequency), Quaternion.identity);
			Destroy(gameObject);
			other.transform.SendMessage("OnPickUp");
		}

	}
}
