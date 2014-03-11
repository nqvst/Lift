using UnityEngine;
using System.Collections;

public class ObstacleScroll : MonoBehaviour {

	void Start()
	{

	}
	
	void OnTriggerExit2D(Collider2D other)
	{
		Debug.Log("in Obstacle! - " + other.transform.name);
		if(other.transform.CompareTag("ScrollTrigger")){
			transform.position =  new Vector2(Random.Range(-32, 32), transform.position.y + 160);
		}
	}

}
