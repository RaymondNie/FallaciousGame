using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class scene5 : MonoBehaviour {

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
	enum State{s1, s2, s3, s4, s5, s6, s7};
	State currState;

	// Let text control the scrolling
	public ScrollRect myScrollRect;

	void Start(){
		// Initialize start scene
		currState = State.s1;

		// Starting options
		option1.GetComponentInChildren<Text>().text = "“Hello Martin. Sorry for forgetting your name.”";
		option2.GetComponentInChildren<Text>().text = "“Hi Martin. I should go to the gym more often so that I can remember the name.”";

		// Starting text
		string dialogue = "A strong six foot man drops in and greets me, “Hey Chris, haven’t seen you for a while.”\n\n";
		dialogue += "Oops. Seems like I forgot this guy’s name. He probably realizes that as well. \n\n";
		dialogue += "He introduces himself again, ”I’m one of the fitness professional in the gym that you work out in. My name is Martin.“\n\n";
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
				dialogue = "“Hello Martin. Sorry for forgetting your name.”";
				s2 (dialogue);
			} else if (option == 2) {
				dialogue = "“Hi Martin. I should go to the gym more often so that I can remember the name.”";
				s2 (dialogue);
			}
		} else if (currState == State.s2) {
			string dialogue;
			if (option == 1) {
				dialogue = "“I couldn’t agree more.  But Trump calls it all fake news so It seems it doesn’t bother him.”\n\n";
				s3 (dialogue);
			} 
		} else if (currState == State.s3) {
			if (option == 1) {
				string dialogue = "“There are too many problems with Trump and that’s why the media puts their focus point on him.”\n\n";
				s4 (dialogue);
			}
		} else if (currState == State.s4) {
			if (option == 1) {
				string dialogue = "“No I don’t.”\n\n";
				s5 (dialogue);
			}else if (option == 2){
				string dialogue = "\"Yes I do.\", I pretend\n\n";
				s6(dialogue);
			}
		}else if (currState == State.s5){
			if(option == 1){
				string dialogue = "“No I don’t.”\n\n";
				s7(dialogue);
			}
		}else if (currState == State.s6 || currState == State.s7){
			if(option == 1){
				LevelManager.load_level();
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
		option1.GetComponentInChildren<Text>().text = "“I couldn’t agree more.  But Trump calls it all fake news so It seems it doesn’t bother him.”";

		// Additional text
		string dialogue = s + "He laughs and replies: “You definitely need to come to the gym more often.”\n\nWe then talk about the gym, girls in the gym, girls in the bar, until being interrupted by the noise from the TV.\n\n“News about Donald Trump again. The media focuses too much on Trump.” He said.\n\n";
		scrollingTextRoutine = scrollingText (dialogue);
		StartCoroutine (scrollingTextRoutine);
	}

	void s3(string s){
		// Update current state
		currState = State.s3;

		resetButtons();
		option1.GetComponentInChildren<Text>().text = "“There are too many problems with Trump and that’s why the media puts their focus point on him.”";

		// Additional text
		string dialogue = s + "“Yup Trump is trying his best to demolish the corrupted Washington D.C. and media are just too liberal and not on his side.”\n\n";
		scrollingTextRoutine = scrollingText (dialogue);
		StartCoroutine (scrollingTextRoutine);
	}

	void s4(string s){
		// Update current state
		currState = State.s4;

		resetButtons();
		option1.GetComponentInChildren<Text>().text = "“No I don’t.”";
		option2.GetComponentInChildren<Text>().text = "Pretend I do.";

		// Additional text
		string dialogue = s + "“What do you mean problems? Most of them are fake and being made up by the media.”\n\nOK, I get it, Martin you are a Trump supporter. I’m thinking about how I can apply red herring to avoid this conversation but he actually asks first,\n\n “Chris do you support Trump? Don’t get brainwashed by liberal media.”\n\n";
		scrollingTextRoutine = scrollingText (dialogue);
		StartCoroutine (scrollingTextRoutine);
	}

	void s5(string s){
		// Update current state
		currState = State.s5;

		resetButtons();
		option1.GetComponentInChildren<Text>().text = "“No I don’t.”";

		// Additional text
		string dialogue = s + "“Are you serious? It’s just ridiculous that you would believe all that fake news.” Martin seems to be disappointed, and continues: “I remember you saying that you are a professor that teaches logic yet it seems you still cannot think independently. Shame on you.” \n\nHe asks again, this time flexing his muscles, “Do you support Trump now?”\n\n";
		scrollingTextRoutine = scrollingText (dialogue);
		StartCoroutine (scrollingTextRoutine);
	}

	void s7(string s){
		// Update current state
		currState = State.s7;

		resetButtons();
		option1.GetComponentInChildren<Text>().text = LevelManager.end_text ();

		// Additional text
		string dialogue = s + "I finally get chance to give my reasons, listing some of Trump’s policies on immigrants and analyzing them for Martin. He seems to be impatient, insisting that all my points are just made up by the puppet liberal media.\n\n “So brainwashed.” Martin stands up and leaves the booth angrily. I should probably get membership at a different gym.\n";
		scrollingTextRoutine = scrollingText (dialogue);
		StartCoroutine (scrollingTextRoutine);
	}

	void s6(string s){
		// Update current state
		currState = State.s6;

		resetButtons();
		option1.GetComponentInChildren<Text>().text = LevelManager.end_text ();

		// Additional text
		string dialogue = s + "I don’t want to get into a bar fight with a fitness professional. There are situations where one should accept appeal to force. We then talk about some local news in a friendly environment until he has to leave for an appointment. ";
		scrollingTextRoutine = scrollingText (dialogue);
		StartCoroutine (scrollingTextRoutine);
	}
}
