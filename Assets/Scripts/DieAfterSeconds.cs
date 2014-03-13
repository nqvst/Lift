using UnityEngine;
using System.Collections;

public class DieAfterSeconds : MonoBehaviour {

	public float seconds = 3;

	void Start () {
		Invoke("Die", seconds);
	}
	
	void Die()
	{
		Destroy(gameObject);
	}
}
