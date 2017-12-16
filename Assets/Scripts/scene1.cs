using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class scene1 : MonoBehaviour {

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
	enum State{s1, s2, s3, s4, s5, s6, s7, s8, s9, s10};
	State currState;

	// Let text control the scrolling
	public ScrollRect myScrollRect;

	string cupChoice;
	string revealedCup;

	void Start(){
		// Initialize start scene
		currState = State.s1;

		// Starting options
		option1.GetComponentInChildren<Text>().text = "“Of course not. Chris here.”\n";
		option2.GetComponentInChildren<Text>().text = "“You already sat down man. But nevermind. Chris here.”\n";

		// Starting text
		string dialogue = "A handsome young man comes in and sits on the opposite side of me.\n\n“You don't mind if I sit here right?”\n\n";

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
				dialogue = "\"Of course not. Chris here.\"\n\n";
				s2 (dialogue);
			} else if (option == 2) {
				dialogue = "\"You already sat down man. But nevermind. Chris here.\"\n\n";
				s2 (dialogue);
			}
		} else if (currState == State.s2) {
			string dialogue;
			if (option == 1) {
				dialogue = "\"Just a boring guy on a boring Wednesday night.\"\n\n";
				s3 (dialogue);
			} else if (option == 2) {
				dialogue = "\"I'm a professor. I teach logic.\"\n\n";
				s4 (dialogue);
			}
		} else if (currState == State.s3) {
			if (option == 1) {
				string dialogue = "I'm a professor. I teach logic.\n\n";
				s4 (dialogue);
			}
		} else if (currState == State.s4) {
			if (option == 1) {
				string dialogue = "“It’s not that fun when you are the only guy in the classroom who understands logic.”\n\n";
				s5 (dialogue);					
			}
		} else if (currState == State.s5) {
			string dialogue;
			if (option == 1) {
				dialogue = "“OK, I wouldn't reject a  chance for a free drink.”\n\n";
				s6 (dialogue);
			} else if (option == 2) {
				dialogue = "“Sure, and I will buy you a drink if I cannot get it right.”\n\n";
				s6 (dialogue);
			}
		} else if (currState == State.s6) {
			string dialogue;
			if (option == 1) {
				dialogue = "“Bottle on the left.”\n\n";
				cupChoice = "left";
				s7 (dialogue, "left");
			} else if (option == 2) {
				dialogue = "“Bottle in the middle.”\n\n";
				cupChoice = "middle";
				s7 (dialogue, "middle");
			} else if (option == 3) {
				dialogue = "“Bottle on the right.”\n\n";
				cupChoice = "right";
				s7 (dialogue, "right");
			}
		} else if (currState == State.s7) {
			string dialogue;
			if (option == 1) {
				dialogue = "A logic professor should make a rational choice. “I’ll switch.”\n\n";
				s8 (dialogue, true);
			} else if (option == 2) {
				dialogue = "He is trying to trick me here. “I’ll stay.”\n\n";
				s8 (dialogue, false);
			}
		} else if (currState == State.s8) {
			if (option == 1) {
				string dialogue = "“Nice trick. Good luck and have fun then.”\n\n";
				s9 (dialogue);
			}
		} else if (currState == State.s9) {
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

		// Additional text
		string dialogue = s + "“James.”\n\nAfter a friendly handshake, James says, “I’m a software developer, work across the street. How about you?”\n\n";
		scrollingTextRoutine = scrollingText (dialogue);
		StartCoroutine (scrollingTextRoutine);

		// Change options
        resetButtons();
		option1.GetComponentInChildren<Text>().text = "Just a boring guy on a boring Wednesday night.\n";
		option2.GetComponentInChildren<Text>().text = "I'm a professor. I teach logic.\n";
	}


	void s3(string s){
		// Update current state
		currState = State.s3;

        resetButtons();
		option1.GetComponentInChildren<Text>().text = "I'm a professor. I teach logic.\n";

		// Additional text
		string dialogue = s + "“Well that is a reason to come to the bar”, he said, “But seriously what do you do?”\n\n";
		scrollingTextRoutine = scrollingText (dialogue);
		StartCoroutine (scrollingTextRoutine);
	}

	void s4(string s){
		// Update current state
		currState = State.s4;

        resetButtons();
		option1.GetComponentInChildren<Text>().text = "“It’s not that fun when you are the only guy in the classroom who understands logic.”\n";

		// Additional text
		string dialogue = s + "“Sounds interesting. Logic is fun, why are you bored?”, he asks.\n\n";
		scrollingTextRoutine = scrollingText (dialogue);
		StartCoroutine (scrollingTextRoutine);
	}

	void s5(string s){
		// Update current state
		currState = State.s5;

        resetButtons();
		option1.GetComponentInChildren<Text>().text = "“OK, I wouldn't reject a  chance for a free drink.”";
		option2.GetComponentInChildren<Text>().text = "“Sure, and I will buy you a drink if I cannot get it right.”";

		// Additional text
		string dialogue = s + "“I got it.” He says. “Professor that teaches logic. I think I got something fun for you though.”\n\n";
		dialogue += "He asks the waiter for three plastic bottles and pulls out a ping pong ball out of nowhere.\n\n";
		dialogue += "James states, “I’m also an amateur magician. Your drink is on me if you can guess which bottle the ball is in.”\n\n";
		scrollingTextRoutine = scrollingText (dialogue);
		StartCoroutine (scrollingTextRoutine);
	}

	void s6(string s){
		// Update current state
		currState = State.s6;

		resetButtons ();
		option1.GetComponentInChildren<Text>().text = "The one in the left.";
        option2.GetComponentInChildren<Text>().text = "The one in the middle.";
        option3.GetComponentInChildren<Text>().text = "The one on the right.";

		// Additional text
		string dialogue = s + "This is a classic act.  He places the ball under the left bottle and rearranges them with lightning fast speed.  It’s hard to follow all the moves but I think the ball is still under the bottle on the left.\n\n";
		dialogue += "“Which one?”, James asks\n\n";
		scrollingTextRoutine = scrollingText (dialogue);
		StartCoroutine (scrollingTextRoutine);
	}

	void s7(string s, string cup){
		// Update current state
		currState = State.s7;

		resetButtons();
		option1.GetComponentInChildren<Text>().text = "A logic professor should make a rational choice. “I’ll switch.”\n";
		option2.GetComponentInChildren<Text>().text = "He is trying to trick me here. “I’ll stay.”\n";

		// Additional text
		string dialogue = s + "“Are you sure?”\n\nHe reveals what is in the bottle on the ";
		if (cupChoice == "left") {
			revealedCup = "right";
			dialogue += "right";
		} else if (cupChoice == "right") {
			revealedCup = "middle";
			dialogue += "middle";
		} else {
			revealedCup = "left";
			dialogue += "left";
		}
		dialogue += ". There is nothing inside and he places the cup back down.\n\n“I’ll give you a chance to switch. What’s your choice now?” \n\nWell then, this is a Monty Hall problem. This guy must have learned some logic before and is trying to test me now.\n\n";
		scrollingTextRoutine = scrollingText (dialogue);
		StartCoroutine (scrollingTextRoutine);
	}

	void s8(string s, bool rational){
		// Update current state
		currState = State.s8;

		resetButtons();
		option1.GetComponentInChildren<Text>().text = "“Nice trick. Good luck and have fun then.”\n";
		string dialogue = "";
		if (rational) {
			dialogue += "“Of course you will switch. A logic professor definitely knows about the Monty Hall problem and will switch.”\n\n";
		} else {
			dialogue += "“Not following the optimal choice from Monty Hall and think I’m tricking you? It doesn’t matter.”\n\n";
		}
		
		// Additional text
		dialogue = s + "He then reveals all the bottles and the bottle on the " + revealedCup + " that he revealed earlier had the ball.\n\n“You forgot I’m a magician.”, James says with a smile on his face.\n\n\"Oh come on. This is cheating.\"\n\n“Sorry about that Chris”, he says, ";
		dialogue += "“But you are such a good sport so don’t worry, your drink is on me.”\n\n“Thanks for that, James.”\n\nHe stands up and says, “No problem. Thanks for your time though that was just practice for me. See that girl over there? That’s my actual target tonight.”\n\nI look at the direction he points to, seems like I’m just the warm-up round for James.\n\n";
		scrollingTextRoutine = scrollingText (dialogue);
		StartCoroutine (scrollingTextRoutine);
	}

	void s9(string s){
		// Update current state
		currState = State.s9;

		resetButtons();
		option1.GetComponentInChildren<Text> ().text = LevelManager.end_text ();

		// Additional text
		string dialogue = s + "Magic beats logic. Not surprising though, especially when your final goal is trying to pick up a girl.\n\n";
		scrollingTextRoutine = scrollingText (dialogue);
		StartCoroutine (scrollingTextRoutine);
	}
}
