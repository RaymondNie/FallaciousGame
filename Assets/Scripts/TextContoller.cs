using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TextContoller : MonoBehaviour {

	public Text text;
	public Text speaker;
	public Text option1;
	public Text option2;

	enum State{Start, Agree, Disagree, End};

	State currState;

	void Start(){
		// Initialize start scene
		currState = State.Start;
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

	void stateAgree(){
		// Sample state 1
		currState = State.Agree;
		speaker.text = "Raymond";
		option1.text = "End game";
		text.text = "You pressed agree";
	}

	void stateDisagree(){
		// Sample state 1
		currState = State.Disagree;
		speaker.text = "Raymond";
		option1.text = "End game";
		text.text = "You pressed disagree";
	}

	void stateEnd(){
		currState = State.End;
		// Load next scene...
		SceneManager.LoadScene("GameOver");
	}


}
