using UnityEngine;
using System.Collections;

public class ScrollObject : MonoBehaviour {

	bool justMoved = false;
	public float range = 10;
	public float frequency = 50;
	public Transform obstaclePrefab;


	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.transform.CompareTag("ScrollTrigger") && !justMoved){

			justMoved = true;
			Instantiate(obstaclePrefab, new Vector2(Random.Range(-range, range), transform.position.y + frequency), Quaternion.identity);
			Invoke("Recycle", 10);

		}

	}

	void Recycle ()
	{
		Destroy(gameObject);

	}

}
