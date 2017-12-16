using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class scene7 : MonoBehaviour {

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
	float scrollSpeed = 0.0175f;

	// Different states of the scene
	enum State{s1, s2, s3, s4, s5, s6};
	State currState;

	// Let text control the scrolling
	public ScrollRect myScrollRect;

	void Start(){
		// Initialize start scene
		currState = State.s1;

		// Starting options
		option1.GetComponentInChildren<Text>().text = "“Explain the bet..”\n";
		option2.GetComponentInChildren<Text>().text = "“I never bet. Sorry bro.”\n";

		// Starting text
		string dialogue = "This shady, overweight young man with a goatee just threw two coins on my table.\n\n“Wanna bet bro?”\n\n";

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
				dialogue = "“Explain the bet..”\n\n";
				s2 (dialogue);
			} else if (option == 2) {
				dialogue = "“I never bet. Sorry bro.”\n\n“Hey don't be so quick to turn me down. Let me explain the details. ";
				s2 (dialogue);
			}
		} else if (currState == State.s2) {
			string dialogue;
			if (option == 1) {
				dialogue = "“Let’s do it”\n\n";
				s3 (dialogue);
			}
		} else if (currState == State.s3) {
			if (option == 1) {
				string dialogue = "“I choose heads.”\n\n";
				s4 (dialogue, true);
			} else if (option == 2) {
				string dialogue = "“I choose tails.”\n\n";
				s4 (dialogue, false);
			}
		} else if (currState == State.s4) {
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
		option1.GetComponentInChildren<Text>().text = "“Let's do it.”";

		// Additional text
		string dialogue = s + "I got two coins here.“, he then waves his hand and call a waiter’s name, “My bro Tony works here and wants to give you a chance for free beer. Of course with some risk though.”\n\nHis voice sounds so much warmer than that of a gambler.\n\nTony then comes with two bottles of unknown brand lagers.\n\n";
		dialogue += "“Have you heard of prisoner’s dilemma? Two loonies, one for you sir and one for my friend Mike. You both choose one side and reveal at the same time. If you both choose head, two beers all on me; If we get one head and one tail, the guy with heads needs to pay for both beers; If you both choose tails, just pay for your own beers. Maximum 20 bucks and no taxes here bro. Sounds fair?”\n\n";
		scrollingTextRoutine = scrollingText (dialogue);
		StartCoroutine (scrollingTextRoutine);
	}


	void s3(string s){
		// Update current state
		currState = State.s3;

		resetButtons();
		option1.GetComponentInChildren<Text>().text = "I choose heads.";
		option2.GetComponentInChildren<Text>().text = "I choose tails.";

		// Additional text
		string dialogue = s + "I would normally reject this proposal because the only way to avoid prisoner’s dilemma is not to be a prisoner.  But that German bottle looks like some really good brand that I would like to try.\n\n";
		scrollingTextRoutine = scrollingText (dialogue);
		StartCoroutine (scrollingTextRoutine);
	}

	void s4(string s, bool heads){
		// Update current state
		currState = State.s4;

		resetButtons();
		option1.GetComponentInChildren<Text>().text = LevelManager.end_text ();

		// Additional text
		string dialogue = s + "Time to reveal...\n\nMike chooses tails. Of course I didn’t get anything for free.\n\n";
		if (heads) {
			dialogue += "I put a 20 dollar note on the plate, give one bottle to Mike and leave one bottle to myself.\n\n“Cheers man! You got me this time.”\n\n“Never trust anyone sir. It’s advice from a professional gambler.”\n\n";
		} else {
			dialogue += "Mike and I put a 10 dollar note on the plate and take our own bottles of beer.\n\n“You don’t trust me as well.” I laugh.\n\n“Absolutely not! I’m a gambler.”\n\n";
		}

		dialogue += "Mike then empties the bottle like in three seconds, says thank you again, leaves the table with his buddy Tony together.\n\nI then take a sip, and the lager really surprises me. Smooth, with some bitterness, exactly my type of beer. Didn’t take a long time to finish the whole bottle, and I realized I probably got something wrong with the gamble.\n\n";
		dialogue += "They were working together right? Well, seems like a logic professor got trapped by a logic problem then. Nevermind, the beer itself would still worth it, and I learned something important, don’t gamble with professionals.\n\n";
		scrollingTextRoutine = scrollingText (dialogue);
		StartCoroutine (scrollingTextRoutine);
	}
}
