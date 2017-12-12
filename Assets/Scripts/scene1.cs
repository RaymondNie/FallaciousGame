using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class scene1 : MonoBehaviour {

	// Text elements on screen
	public Text text;
	public Text speaker;
	public Text option1;
	public Text option2;
	public GameObject button1;
	public GameObject button2;

	// Printing text
	private IEnumerator scrollingTextRoutine;
	private string currText;
	float scrollSpeed = 0.0125f;

	// Different states of the scene
	enum State{Start, Agree, Disagree, End};
	State currState;

	// List of possible levels
	int[] validLevelNumbers = new int [2] {0,2};

	void Start(){
		// Initialize start scene
		currState = State.Start;
		scrollingTextRoutine = scrollingText ();
		// Starting text
		currText = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Mauris ut aliquam ligula, sed tempor magna. Aenean hendrerit justo eget neque blandit rutrum. Quisque in augue nisi. Maecenas quis lobortis sapien. Integer lobortis felis ut mi finibus, sit amet pharetra elit mollis. Sed aliquam turpis viverra mauris sodales tincidunt in vitae lectus. Proin vitae dolor rutrum, convallis lacus non, tincidunt nibh. Nulla facilisi. Fusce viverra tempus elit, id pulvinar lectus interdum at. Sed turpis nulla, mattis ac bibendum eu, sodales id justo. Morbi egestas quis orci a placerat. Fusce euismod porta tincidunt. Praesent ac quam id diam cursus sollicitudin. Vivamus ac orci mi. Etiam vitae magna a nibh molestie ultrices et vel sapien. Pellentesque sed finibus sapien.\n\n";
		StartCoroutine (scrollingTextRoutine);
	}

	void Update(){
		if (Input.GetMouseButtonDown(0)) {
			StopCoroutine (scrollingTextRoutine);
			scrollingTextRoutine = scrollingText ();
			text.text = currText;
			button1.SetActive (true);
			button2.SetActive (true);
		}
	}

	public void changeState(bool option){
		// Somewhere we keep track of current state and set transitions..
		// If statements...
		if (currState == State.Start) {
			if (option) {
				stateAgree ();
			} else {
				stateDisagree ();
			}
		}
		else if(currState == State.Agree || currState == State.Disagree){
			stateEnd();
		}

	}

	IEnumerator scrollingText(){
		button1.SetActive (false);
		button2.SetActive (false);
		for (int i = 0; i <= currText.Length; ++i) {
			text.text = currText.Substring (0, i);
			yield return new WaitForSeconds(scrollSpeed);
		}
		button1.SetActive (true);
		button2.SetActive (true);
	}

	void stateAgree(){
		// Sample state 1
		currState = State.Agree;
		speaker.text = "Raymond";
		option1.text = "End game";
		currText = "Raymond";
		StartCoroutine (scrollingTextRoutine);
	}

	void stateDisagree(){
		// Sample state 1
		currState = State.Disagree;
		speaker.text = "Raymond";
		option1.text = "End game";
		currText = "You pressed disagree";
	}

	void stateEnd(){
		currState = State.End;
		// Load next scene...
		int randomIndex = Random.Range(0, validLevelNumbers.Length);
		Application.LoadLevel(validLevelNumbers[randomIndex]);
	}



}
