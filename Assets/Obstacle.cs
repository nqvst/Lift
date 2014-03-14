using UnityEngine;
using System.Collections;

public class Obstacle : MonoBehaviour {

	bool justMoved = false;
	public float range = 10;
	public float frequency = 50;
	public Transform obstaclePrefab;
	public Transform collectablePrefab;
	void Start()
	{
		Instantiate(collectablePrefab, transform.position, Quaternion.identity);
	}
	
	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.transform.CompareTag("Boundries") && !justMoved){
			
			justMoved = true;
			Invoke("Recycle", 0.1f);
			Instantiate(obstaclePrefab, new Vector2(Random.Range(-range, range), transform.position.y + frequency), Quaternion.identity);
		}
		
	}
	
	void Recycle ()
	{
		Destroy(gameObject);
		
	}
}
