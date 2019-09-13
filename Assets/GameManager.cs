using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {




	void Start () {

	}

	void Update () {

	}

	public void PlayInfiniteMode() {
		Debug.Log("PlayInfiniteMode");
		SceneManager.LoadScene("infinite");
	}

	public void PlayPuzzleMode() {
		Debug.Log("PlayPuzzleMode");
		SceneManager.LoadScene("puzzle_menu");
	}

	public void PlayIntroMode() {
		Debug.Log("PlayIntroMode");
		SceneManager.LoadScene("intro");
	}
}
