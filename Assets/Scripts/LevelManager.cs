using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {
	public static  List<string> levelList = new List<string>() {"Scene1", "Scene2", "Scene3", "Scene5", "Scene6", "Scene7", "Scene8", "Scene9"};
	public static int levelCounter;

	void Start(){
		levelCounter = 0;
		DontDestroyOnLoad (transform.gameObject);
	}

	static void initializeLevels(){
		levelList = new List<string> () {"Scene1", "Scene2", "Scene3", "Scene5", "Scene6", "Scene7", "Scene8", "Scene9"};
	}

	public static void load_level(){
		++levelCounter;
		if (levelCounter == 4) {
			load_specific_level("GameOver");
			levelCounter = 0;
			initializeLevels ();
		}else if (levelList.Count == 0) {
			SceneManager.LoadScene("GameOver");
			levelCounter = 0;
			initializeLevels ();
		} else {
			int randomIndex = Random.Range (0, levelList.Count);
			string levelName = levelList [randomIndex];
			SceneManager.LoadScene(levelName);
			levelList.RemoveAt (randomIndex);
		}
	}

	public static string end_text(){
		if (levelCounter == 1) {
			return "I take another sip of my drink...";
		} else if (levelCounter == 2) {
			return "My meal finally comes. It tastes like nothing.  I think about what just happened until...";
		} else if (levelCounter == 3) {
			return "I start to feel a bit sleepy with the help of alcohol.";
		} else {
			return "I take a sip of my drink...";
		}
	}

	public static void load_specific_level(string s){
		SceneManager.LoadScene(s);
	}

}
