using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public void load_level(string name){
		Debug.Log("Level load requested for " + name);
		Application.LoadLevel(name);
	}

}
