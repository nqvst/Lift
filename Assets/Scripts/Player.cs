using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float height = 0;
	private int highScore = 0;
	private int collected = 0;

	public GUISkin skin;

	public Texture collectableTexture;

	public Transform motivationSound;

	private int lastHundredReached = 0;

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

		if((Mathf.CeilToInt(transform.position.y) % 100) == 0 && Mathf.CeilToInt(transform.position.y) > lastHundredReached){
			lastHundredReached = Mathf.CeilToInt(transform.position.y);
			motivationalString = lastHundredReached.ToString();
			Instantiate(motivationSound, transform.position, Quaternion.identity);
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
		GUI.Label(new Rect(10, 10, 400, 50),"Height: " + height.ToString("f0"));
		GUI.Label(new Rect(Screen.width - 250, 10, 250, 50),"Best: " + highScore);  
		if(showMotivationGui){
			GUI.contentColor = Color.green;
			GUI.Label(new Rect(Screen.width/2 -50, Screen.height/2 -100, 250, 50), motivationalString + "!");
		}

		GUI.DrawTexture(new Rect(20, 70, 30, 30), collectableTexture);
		GUI.Label(new Rect(50, 60, 200, 100)," " + collected.ToString());

	}

	void OnDie()
	{
		if(highScore < Mathf.CeilToInt(height)){
			PlayerPrefs.SetInt("HighScore", Mathf.CeilToInt(height));
		}
	}

	void OnPickUp()
	{
		collected++;
	}
}
