using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManagerWrapper : MonoBehaviour {

	public void loadLevelWrapper (){
		LevelManager.load_level();
	}

	public void loadSpecificWrapper(string s){
		LevelManager.load_specific_level (s);
	}
}
