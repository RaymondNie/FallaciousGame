using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class scene9 : MonoBehaviour {

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

	// beer or whisky
	bool beer;

	void Start(){
		// Initialize start scene
		currState = State.s1;

		// Starting options
		option1.GetComponentInChildren<Text>().text = "“Definitely whisky.”\n";
		option2.GetComponentInChildren<Text>().text = "“Of course beer.”\n";

		// Starting text
		string dialogue = "A caucasian male with a lot of things in his hands passes by and asks: “Do you prefer whisky or beer?”\n\n";

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
				dialogue = "“Definitely whisky.”\n\n";
				beer = false;
				s2 (dialogue);
			} else if (option == 2) {
				dialogue = "“Of course beer.”\n\n";
				beer = true;
				s2 (dialogue);
			}
		} else if (currState == State.s2) {
			string dialogue;
			if (option == 1) {
				dialogue = "“What are you talking about?”\n\n";
				s3 (dialogue);
			}
		} else if (currState == State.s3) {
			if (option == 1) {
				string dialogue = "“Could you explain this a little bit?”\n\n";
				s4 (dialogue);
			} else if (option == 2) {
				string dialogue = "“Please have a seat and probably tell me what’s going on.”\n\n";
				s4 (dialogue);
			}
		} else if (currState == State.s4) {
			if (option == 1) {
				string dialogue = "“Yeah, Quebecers are just better in drinking whisky.”\n\n";
				s5 (dialogue);					
			} else if (option == 2) {
				string dialogue = "“Hey man you need to add up those numbers.”\n\n";
				s6 (dialogue);
			}
		} else if (currState == State.s5 || currState == State.s6) {
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
		option1.GetComponentInChildren<Text>().text = "“What are you talking about?”";

		// Additional text
		string dialogue = s + "He then puts down his whisky glass and starts to write something on a piece of paper.\n\n";
		dialogue += "“Well here are the results. Close call but still, Ontario guys are just not as good at drinking compared to us, man.”\n\n";
		scrollingTextRoutine = scrollingText (dialogue);
		StartCoroutine (scrollingTextRoutine);
	}


	void s3(string s){
		// Update current state
		currState = State.s3;

		resetButtons();
		option1.GetComponentInChildren<Text>().text = "“Could you explain this a little bit?”\n\n";
		option2.GetComponentInChildren<Text>().text = "“Please have a seat and probably tell me what’s going on.”\n\n";

		// Additional text
		string dialogue = s + "“May I sit down?” This obvious Quebecer asks politely and hands his paper to me, full of random numbers everywhere.\n\n";
		scrollingTextRoutine = scrollingText (dialogue);
		StartCoroutine (scrollingTextRoutine);
	}

	void s4(string s){
		// Update current state
		currState = State.s4;

		resetButtons();
		option1.GetComponentInChildren<Text>().text = "“Yeah, Quebecers are just better in drinking whisky.” \n\n";
		option2.GetComponentInChildren<Text>().text = "“Hey man you need to add up those numbers.” \n\n";

		// Additional text
		string dialogue = s + "“Sure. “ He points at the paper, “20 Ontario men in the bar and only 9 of them prefer whisky. But half of 6 Quebecois here like whisky over beer. A little bit lower than what I expected but still beat you guys.”\n\n";
		dialogue += "Such a pointless survey and I still have no idea what he wants to prove here.\n\n2 numbers on the paper catch my attention and I ask about them.\n\nHe explains to me, “The 0/2 is Ontario females and the 1/4 is for Quebecoises. Still the number is disappointing but victory on both genders ha.”\n\n";
		dialogue += "It’s 21st century, you should have an option called “other” in the gender column. Still, why is this guy doing a survey on this? People choosing beer over whisky does not mean they are bad at drinking. Wait a moment... I realize that this is a Simpson’s Paradox.\n\n";
		scrollingTextRoutine = scrollingText (dialogue);
		StartCoroutine (scrollingTextRoutine);
	}

	void s5(string s){
		// Update current state
		currState = State.s5;

		resetButtons();
		option1.GetComponentInChildren<Text>().text = LevelManager.end_text ();

		// Additional text
		string dialogue = s + "Whatever. I don’t want to waste time on this stupid question.\n\n“You have to admit right?”, he says,";

		if (beer) {
			dialogue += "“Learn the proper way to drink man.”\n\n";
		} else {
			dialogue += "“But you like whisky as well. Better than average Ontario men. Sante!”\n\n";
		}
		dialogue += "he just raises his glass off the table, chugs it and leaves. Completely ignoring the fact that I haven’t even taken a drink yet. What a strange guy but i’m glad he’s finally gone.\n";
		scrollingTextRoutine = scrollingText (dialogue);
		StartCoroutine (scrollingTextRoutine);
	}

	void s6(string s){
		// Update current state
		currState = State.s6;

		resetButtons ();
		option1.GetComponentInChildren<Text>().text = LevelManager.end_text ();

		// Additional text
		string dialogue = s + "“What do you mean?”\n\n“If you add the numbers up, you would find 9 out of 22 Ontario people like whisky.”\n\nI take out my phone and open the calculator, “That’s roughly 41%, just more than the number 4 out of 10 from you guys.”\n\n“Are you serious? How can this even be possible?”\n\n“It’s actually something called Simpson’s Paradox. Only happen because too many Quebec females are here.”\n\nI point at the number 1/4 , and it seems like he understands the situation.\n\n“Ces femelles are just dragging us behind.“\n\n";
		if (beer) {
			dialogue += "“But you must have hacked your calculator. You beer lovers just like cheating.”\n\nWhy am I even wasting my time on this guy. I try to explain to him one last time\n\n";
		} else {
			dialogue += "“Men are just better. Just like you, also love whisky. Great work!” I’m not sure if he really understood the Simpson’s Paradox now, but just as I'm about to say something.\n";
		}

		dialogue += "he just raises his glass off the table, chugs it and leaves. Completely ignoring the fact that I haven’t even taken a drink yet.\n\nWhat a strange guy but i’m glad he’s finally gone.\n";
		scrollingTextRoutine = scrollingText (dialogue);
		StartCoroutine (scrollingTextRoutine);
	}
		
}
