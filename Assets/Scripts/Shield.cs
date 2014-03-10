using UnityEngine;
using System.Collections;

public class Shield : MonoBehaviour {

	SpriteRenderer spriteRenderer;
	CircleCollider2D circleCollider;
	public float duration = 10;

	bool isActive = false;

	void Start () 
	{
		circleCollider = gameObject.GetComponent<CircleCollider2D>();
		spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
	}
	
	void Update () 
	{
		
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.CompareTag("Shield")){
			Activate();
		}
	}

	void Activate ()
	{
		circleCollider.enabled = true;
		spriteRenderer.enabled = true;
	
		Invoke("DeActivate", duration);

	}

	void DeActivate ()
	{
		circleCollider.enabled = false;
		spriteRenderer.enabled = false;
	}

	void PowerUp(){
		Debug.Log("ThePower!!");
	}

}
