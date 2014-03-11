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

	void OnGUI()
	{
		GUI.skin = skin;
		GUI.Label(new Rect(10, 10, 400, 100),"Height: " + height.ToString("f0"));
		GUI.Label(new Rect(Screen.width - 250, 10, 250, 100),"Best: " + highScore);  
	}

	void OnDie()
	{
		if(highScore < Mathf.CeilToInt(height)){
			PlayerPrefs.SetInt("HighScore", Mathf.CeilToInt(height));
		}
	}
}
