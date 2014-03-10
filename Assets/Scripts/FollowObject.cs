using UnityEngine;
using System.Collections;

public class FollowObject : MonoBehaviour {

	public GameObject target;
	public string targetTag;
	public float yOffset = 10;
	Vector3 targetPosition;
	Vector3 startPosition = new Vector3(0,0,-10);

	void Start () {
		if((targetTag != null || targetTag != "") && target == null){
			target = GameObject.FindGameObjectWithTag(targetTag);
		}
	}
	
	void FixedUpdate ()
	{
		if (target != null) {
			
			if(target.gameObject == null){
				targetPosition = startPosition;
			}else{
				targetPosition = new Vector3 (0, target.transform.position.y + yOffset, -10);
			}
		}
		
		if (targetPosition != transform.position && targetPosition.y + yOffset >= transform.position.y) {
			transform.position = Vector3.Lerp (transform.position, targetPosition, 0.1f);
		}
		
	}
}
