using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class startScene : MonoBehaviour {

	// Text elements on screen
	public Text text;
	public Text option1;
	public Text option2;
	public GameObject button1;
	public GameObject button2;
	public GameObject button3;
	public GameObject button4;
	// Printing text
	private IEnumerator scrollingTextRoutine;
	private string currText; // curr text keeps track of the entire current dialogue
	float scrollSpeed = 0.0175f;

	// Different states of the scene
	enum State{s1, s2, s3, s4};
	State currState;

	// Let text control the scrolling
	public ScrollRect myScrollRect;

	void Start(){
		// Initialize start scene
		currState = State.s1;

		// Starting options
		option1.text = "Well, It’s time to check it out.\n";
		option2.text = "Nah I would not go in a bar with such a stupid name.\n";

		// Starting text
		string dialogue = "Boring Wednesday, nothing to do as usual.\n\nI look outside my car window and cannot find anything that could inspire a night plan.\n\nDriving without any purpose in this little town is probably the only way to kill my night.\n\nWait a second, is that a new bar? Oh come on, why does the bar have the name “foo”?\n\nI must have missed this bar before...\n\n";

		scrollingTextRoutine = scrollingText (dialogue);
		StartCoroutine (scrollingTextRoutine);
	}

	void Update(){
		if (Input.GetMouseButtonDown(0)) {
			StopCoroutine (scrollingTextRoutine);
			text.text = currText;
			button1.SetActive (true);
			button2.SetActive (true);
			button3.SetActive (true);
			button4.SetActive (true);
			Canvas.ForceUpdateCanvases();
			myScrollRect.verticalNormalizedPosition = 0f;
		}
	}

	public void changeState(bool option){
		// Somewhere we keep track of current state and set transitions..
		// If statements...
		if (currState == State.s1) {
			string dialogue;
			if (option) {
				dialogue = "\"Well, It’s time to check it out.\"\n\n";
			} else {
				dialogue = "\"Nah I would not go in a bar with such a stupid name. But seriously, what can I do tonight? Watch Maple Leafs play at home? Already know we are going to lose. Forget it. Just go check out the bar Chris.\"\n\n";
			}
			s2 (dialogue);
		} else if (currState == State.s2) {
			string dialogue;
			if (option) {
				dialogue = "\"Just Bud Light please.\"\n\n“No problem man.”, he replies.å\n\n";
			} else {
				dialogue = "\"Any recommendation?\", I ask.\n\n\"We got a foobar special drink. Wanna try?\"\n\n“Sure”";
			}
			s3 (dialogue);
		} else if (currState == State.s3 || currState == State.s4) {
			LevelManager.load_level ();
		}

	}

	IEnumerator scrollingText(string s){
		currText += s;
		button1.SetActive (false);
		button2.SetActive (false);
		button3.SetActive (false);
		button4.SetActive (false);
		for (int i = 0; i < s.Length; ++i) {
			text.text += s[i];
			myScrollRect.verticalNormalizedPosition = 0f;
			yield return new WaitForSeconds(scrollSpeed);
		}
		button1.SetActive (true);
		button2.SetActive (true);
		button3.SetActive (true);
		button4.SetActive (true);
		myScrollRect.verticalNormalizedPosition = 0f;
	}

	void s2(string s){
		// Update current state
		currState = State.s2;

		// Change options
		option1.text = "Just Bud Light please.\n";
		option2.text = "Any recommendation?\n";

		// Additional text
		string dialogue = s + "I park along the street and walk inside. Doesn't look like anything special.\n\n“Alone, Sir?”, the waiter asks.\n\n“Yeah but get me a booth thanks.”\n\nI just don’t understand why people like to sit those barstools. So uncomfortable.\n\n“What do you want, sir?”\n\n";
		scrollingTextRoutine = scrollingText (dialogue);
		StartCoroutine (scrollingTextRoutine);
	}

	void s3(string s){
		// Update current state
		currState = State.s3;

		option1.text = "I take a sip of my drink...\n";
		option2.text = "";

		// Additional text
		string dialogue = s;
		scrollingTextRoutine = scrollingText (dialogue);
		StartCoroutine (scrollingTextRoutine);
	}
}
