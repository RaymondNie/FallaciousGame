using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameOver : MonoBehaviour {

	public Text text;
	// Buttons
	public GameObject option1;

	// Printing text
	private IEnumerator scrollingTextRoutine;
	private string currText; // curr text keeps track of the entire current dialogue
	float scrollSpeed = 0.0125f;

	void Start(){
		// Starting text
		string dialogue = "I should probably be heading home now.\nGot an 8:30 lecture to teach tomorrow...";
		scrollingTextRoutine = scrollingText (dialogue);
		StartCoroutine (scrollingTextRoutine);
	}

	IEnumerator scrollingText(string s){
		currText += s;
		for (int i = 0; i < s.Length; ++i) {
			text.text += s[i];
			yield return new WaitForSeconds(scrollSpeed);
		}
	}

	public void restart(){
		SceneManager.LoadScene ("Start");
	}
}
