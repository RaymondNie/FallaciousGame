using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class scene8 : MonoBehaviour {

	// Text elements on screen
	//public Text text;
	public Text text;
	// Buttons
	public GameObject option1;
	public GameObject option2;
	public GameObject option3;
	public GameObject option4;

	// Printing text
	private IEnumerator scrollingTextRoutine;
	private string currText; // curr text keeps track of the entire current dialogue
	float scrollSpeed = 0.0125f;

	// Different states of the scene
	enum State{s1, s2, s3, s4, s5, s6};
	State currState;

	// Let text control the scrolling
	public ScrollRect myScrollRect;

	void Start(){
		// Initialize start scene
		currState = State.s1;

		// Starting options
		option1.GetComponentInChildren<Text>().text = "“It’s been OK.”\n";
		option2.GetComponentInChildren<Text>().text = "“Absolutely”\n";

		// Starting text
		string dialogue = "A middle-aged wealthy looking gentleman with ginger hair approaches me. “Having a good time here tonight, sir?”\n\n";

		scrollingTextRoutine = scrollingText (dialogue);
		StartCoroutine (scrollingTextRoutine);
	}

	void activeButtons(bool active){
		option1.SetActive (active);
		option2.SetActive (active);
		option3.SetActive (active);
		option4.SetActive (active);
	}

	void resetButtons(){
		option1.GetComponentInChildren<Text>().text = "";
		option2.GetComponentInChildren<Text>().text = "";
		option3.GetComponentInChildren<Text>().text = "";
		option4.GetComponentInChildren<Text>().text = "";
	}

	void Update(){
		if (Input.GetMouseButtonDown(0)) {
			StopCoroutine (scrollingTextRoutine);
			text.text = currText;
			activeButtons (true);
			Canvas.ForceUpdateCanvases();
			myScrollRect.verticalNormalizedPosition = 0f;
		}
	}

	public void changeState(int option){
		if (currState == State.s1) {
			string dialogue;
			if (option == 1) {
				dialogue = "“It’s been OK.”\n\n“Well still better than me, sir.”, he says\n\n";
				s2 (dialogue);
			} else if (option == 2) {
				dialogue = "“Absolutely”\n\n“Glad you're enjoying yourself, sir.”, he says\n\n";
				s2 (dialogue);
			}
		} else if (currState == State.s2) {
			string dialogue;
			if (option == 1) {
				dialogue = "“How this could happen to a gentleman such as yourself?”\n\n";
				s3 (dialogue);
			} else if (option == 2) {
				dialogue = "I really don’t care anything about him but still ask him about his situation.\n\n“How this could happen to a gentleman such as yourself?”\n\n";
				s3 (dialogue);
			}
		} else if (currState == State.s3) {
			if (option == 1) {
				string dialogue = "“Sure”\n\n";
				s4 (dialogue);
			} else if (option == 2) {
				string dialogue = "“Nah sorry.”\n\n";
				s5 (dialogue);
			}
		} else if (currState == State.s5) {
			if (option == 1) {
				LevelManager.load_level ();
			}
		}
	}

	IEnumerator scrollingText(string s){
		currText += s;
		activeButtons (false);
		for (int i = 0; i < s.Length; ++i) {
			text.text += s[i];
			myScrollRect.verticalNormalizedPosition = 0f;
			yield return new WaitForSeconds(scrollSpeed);
		}
		activeButtons (true);
		myScrollRect.verticalNormalizedPosition = 0f;
	}

	void s2(string s){
		// Update current state
		currState = State.s2;

		// Change options
		resetButtons();
		option1.GetComponentInChildren<Text>().text = "“How this could happen to a gentleman such as yourself?”";
		option2.GetComponentInChildren<Text>().text = "I really don’t care anything about him but still ask him about his situation.";

		// Additional text
		string dialogue = s + "he sits down and says, “because I have such a bad life man.”\n\nI scan through his face, and I see a crystal clear word “Depressed” floating above his head.\n\n“I just lost my job and my wife is cheating on me.”\n\n“Sorry to hear that man.”\n\n";
		scrollingTextRoutine = scrollingText (dialogue);
		StartCoroutine (scrollingTextRoutine);
	}


	void s3(string s){
		// Update current state
		currState = State.s3;

		resetButtons();
		option1.GetComponentInChildren<Text>().text = "“Sure.”\n\n";
		option2.GetComponentInChildren<Text>().text = "“Nah sorry man.”\n\n";

		// Additional text
		string dialogue = s + "“Things never go well for me. Let me tell you my story so you might learn something from it and avoid becoming someone like me.”, he continues, “Could you buy me a beer first? Thanks.”\n\n";
		scrollingTextRoutine = scrollingText (dialogue);
		StartCoroutine (scrollingTextRoutine);
	}

	void s4(string s){
		// Update current state
		currState = State.s3;

		// Additional text
		string dialogue = s + "“That’s very nice of you.”\n\nHe continues his sad story, talking randomly from family to work, and always repeating two specific plots: kid stole his car and insurance company refused to cover his drugs.\n\nHis advice: don’t have kids and don’t buy insurance, which is something already knew before.\n\nHe then asks politely again, “Could you buy me another beer?”\n\n";
		scrollingTextRoutine = scrollingText (dialogue);
		StartCoroutine (scrollingTextRoutine);
	}

	void s5(string s){
		// Update current state
		currState = State.s5;

		resetButtons();
		option1.GetComponentInChildren<Text>().text = "Take a drink...\n";

		// Additional text
		string dialogue = s + "He seems to be so pissed off, muttering how I’m such an inconsiderate person and not even a true Canadian and leaves.  Such a low energy guy. I should never become a guy like him no matter what happens to me, I thought to myself, ignoring the fact that he actually got a house and a wife which I don’t.";
		scrollingTextRoutine = scrollingText (dialogue);
		StartCoroutine (scrollingTextRoutine);
	}
}
