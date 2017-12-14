using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {
	public static  List<string> levelList = new List<string>() {"Scene2"};

	void Start(){
		DontDestroyOnLoad (transform.gameObject);
	}

	static void initializeLevels(){
		levelList = new List<string> () {"Scene2" };
	}

	public static void load_level(){
		if (levelList.Count == 0) {
			SceneManager.LoadScene("GameOver");
			initializeLevels ();
		} else {
			int randomIndex = Random.Range (0, levelList.Count);
			string levelName = levelList [randomIndex];
			SceneManager.LoadScene(levelName);
			levelList.RemoveAt (randomIndex);
		}
	}

	public static void load_specific_level(string s){
		SceneManager.LoadScene(s);
	}

}
