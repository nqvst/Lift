using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

	public GUISkin skin;
	public Transform explosionPrefab;

	float health;
	bool isDead = false;
	float damageImpact = 10;

	public float maxHealth = 100;
	Rigidbody2D rb;

	void Start ()
	{
		rb = GetComponent<Rigidbody2D> ();
		health = maxHealth;
	}

	void Update ()
	{
		if(health <= 0 && !isDead){
			Die();
		}
	}

	void Respawn()
	{
		Application.LoadLevel(Application.loadedLevel);
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.transform.CompareTag ("Obstacle") || other.transform.CompareTag ("Boundries")) {
			Vector3 p = other.transform.position - transform.position;
			health -= rb.velocity.magnitude * damageImpact;
			rb.AddForceAtPosition(transform.TransformDirection(p) * 1000, p.normalized);
		}
	}

	void Die()
	{
		isDead = true;
		gameObject.SendMessage("OnDie");
		Instantiate(explosionPrefab, transform.position, Quaternion.identity);
		Invoke("Respawn", 1f);
	}

}
