using UnityEngine;
using System.Collections;

public class PowerUp : MonoBehaviour {

	public enum PowerType {Shield = 0, Speed = 1}
	public PowerType type;
	public float duration = 10;

	void OnTriggerEnter2D(Collider2D other){
		Debug.Log(other.transform.name);
		Destroy(gameObject);
		other.gameObject.SendMessage("PowerUp");
	}
}
