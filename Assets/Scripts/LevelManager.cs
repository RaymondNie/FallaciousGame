using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {
	
	// Not sure if we going to use this since scenes should just be randomly loaded
	public void load_level(string name){
		Debug.Log("Level load requested for " + name);
		Application.LoadLevel(name);
	}
	
}
