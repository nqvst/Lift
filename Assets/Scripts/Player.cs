using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float height = 0;
	private int highScore = 0;

	public GUISkin skin;

	bool showMotivationGui = false;
	string motivationalString = "";

	void Start()
	{
		highScore = PlayerPrefs.GetInt("HighScore");
	}

	void Update()
	{
		if(transform.position.y > height){
			height = transform.position.y;
		}

//		if(Mathf.Abs(transform.position.x) > 40){
//			transform.position = new Vector2(transform.position.x * -0.9f, transform.position.y);
//		}

		if((Mathf.CeilToInt(transform.position.y) % 100) == 0){
			motivationalString = Mathf.CeilToInt(transform.position.y).ToString();
			showMotivationGui = true;
			Invoke("RemoveMotivation", 1.5f);
		}
	}

	void RemoveMotivation(){
		showMotivationGui = false;
	}

	void OnGUI()
	{
		GUI.skin = skin;
		GUI.Label(new Rect(10, 10, 400, 100),"Height: " + height.ToString("f0"));
		GUI.Label(new Rect(Screen.width - 250, 10, 250, 100),"Best: " + highScore);  
		if(showMotivationGui){
			GUI.Label(new Rect(Screen.width/2 -50, Screen.height/2 -100, 250, 100), motivationalString + "!");
		}
	}

	void OnDie()
	{
		if(highScore < Mathf.CeilToInt(height)){
			PlayerPrefs.SetInt("HighScore", Mathf.CeilToInt(height));
		}
	}
}
