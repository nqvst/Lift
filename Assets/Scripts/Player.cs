using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float height = 0;
	private int highScore = 0;

	public GUISkin skin;


	void Start()
	{
		highScore = PlayerPrefs.GetInt("HighScore");
	}

	void Update()
	{
		if(transform.position.y > height){
			height = transform.position.y;
		}
	}

	void OnGUI(){
		GUI.skin = skin;

		GUILayout.Label("Height: " + height.ToString("f0"));

		GUILayout.Label("High Score: " + highScore);

		//GUILayout.Label("Velocity: " + rigidbody2D.velocity.magnitude.ToString("f0"));
	}

	void OnDie(){
		if(highScore < Mathf.CeilToInt(height)){
			PlayerPrefs.SetInt("HighScore", Mathf.CeilToInt(height));
		}
	}
}
