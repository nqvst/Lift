using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

	public GUISkin skin;
	public Transform explosionPrefab;	

	float health;
	public float damageImpact = 100;

	public float maxHealth = 100;

	void Start () 
	{
		health = maxHealth; 
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(health <= 0){
			Die();
		}
	}

	void Respawn()
	{
		Application.LoadLevel(Application.loadedLevel);
	}

	void OnCollisionEnter2D(Collision2D coll)
	{

		Debug.Log(coll.collider.transform.name);
		health -= rigidbody2D.velocity.magnitude * damageImpact;
		health = 0;
	}

	void Die()
	{
		gameObject.SendMessage("OnDie");
		gameObject.SetActive(false);
		Instantiate(explosionPrefab, transform.position, Quaternion.identity);
		Invoke("Respawn", 1f);
	}

	void OnTriggerExit2D(Collider2D other)
	{
		Debug.Log(other.transform.name);
		if(other.transform.CompareTag("Boundries")){
			health = 0;
		}
	}

}
