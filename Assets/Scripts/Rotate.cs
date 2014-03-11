using UnityEngine;
using System.Collections;

public class Rotate : MonoBehaviour {

	public float speed = 10;
	public bool rotate = true;

	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if(rotate)
		{
			transform.Rotate(Vector3.up * Time.deltaTime * speed);
//			transform.Rotate(Vector3.up * Time.deltaTime * speed, Space.World);
		}
	}
}
