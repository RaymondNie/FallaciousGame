using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class scene2 : MonoBehaviour {

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
	enum State{s1, s2, s3, s4, s5, s6, s7, s8, s9, s10};
	State currState;

	// Let text control the scrolling
	public ScrollRect myScrollRect;


	void Start(){
		// Initialize start scene
		currState = State.s1;

		// Starting options
		option1.GetComponentInChildren<Text>().text = "Of course not. Chris here.\n";
		option2.GetComponentInChildren<Text>().text = "You already sat down man. But nevermind. Chris here.\n";

		// Starting text
		string dialogue = "A handsome young man just come in and sit opposite me.\n“You wouldn’t mind, right?”\n";

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
				dialogue = "Of course not. Chris here.\n";
				s2 (dialogue);
			} else if (option == 2) {
				dialogue = "You already sat down man. But nevermind. Chris here.\n";
				s2 (dialogue);
			}
		} else if (currState == State.s2) {
			string dialogue;
			if (option == 1) {
				dialogue = "Just a boring guy on a boring Wednesday night.\n";
				s3 (dialogue);
			} else if (option == 2) {
				dialogue = "I'm a professor. I teach logic.\n";
				s4 (dialogue);
			}
		} else if (currState == State.s3) {
			if (option == 1) {
				string dialogue = "I'm a professor. I teach logic.\n";
				s4 (dialogue);
			}
		} else if (currState == State.s4) {
			if (option == 1) {
				string dialogue = "“It’s not that fun when you are the only guy in the classroom understand logic.”\n";
				s5 (dialogue);					
			}
		} else if (currState == State.s5) {
			string dialogue;
			if (option == 1) {
				dialogue = "“OK I would not reject a free drink chance.”\n";
				s6 (dialogue);
			} else if (option == 2) {
				dialogue = "“I will buy you a drink if I cannot get it right.”\n";
				s6 (dialogue);
			}
		} else if (currState == State.s6) {
			string dialogue;
			if (option == 1) {
				dialogue = "“Bottle on the left.”\n";
				s7 (dialogue, "left");
			} else if (option == 2) {
				dialogue = "“Bottle in the middle.”\n";
				s7 (dialogue, "middle");
			} else if (option == 3) {
				dialogue = "“Bottle on the right.”\n";
				s7 (dialogue, "right");
			}
		} else if (currState == State.s7) {
			string dialogue;
			if (option == 1) {
				dialogue = "Logic professor should have rational choice. “I’ll switch.”";
				s8 (dialogue);
			} else if (option == 2) {
				dialogue = "He is trying to trick me here. “I’ll stay.”";
				s8 (dialogue);
			}
		} else if (currState == State.s8) {
			if (option == 1) {
				string dialogue = "“Nice trick. Good luck and have fun then.”";
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
		string dialogue = s + "“James.” After a friendly handshake, James asked: “I’m a software developer. Work across the street. How about you?”\n";
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
		string dialogue = s + "“That’s why you come to a bar”, he said, “But seriously what do you do?”\n";
		scrollingTextRoutine = scrollingText (dialogue);
		StartCoroutine (scrollingTextRoutine);
	}

	void s4(string s){
		// Update current state
		currState = State.s4;

        resetButtons();
		option1.GetComponentInChildren<Text>().text = "“It’s not that fun when you are the only guy in the classroom understand logic.”\n";

		// Additional text
		string dialogue = s + "“Sounds interesting then”, he said, “Logic is fun. Then why are you bored?”\n";
		scrollingTextRoutine = scrollingText (dialogue);
		StartCoroutine (scrollingTextRoutine);
	}

	void s5(string s){
		// Update current state
		currState = State.s5;

        resetButtons();
		option1.GetComponentInChildren<Text>().text = "“OK I would not reject a free drink chance.”";
		option2.GetComponentInChildren<Text>().text = "“I will buy you a drink if I cannot get it right.”";

		// Additional text
		string dialogue = s + "“I got it.” He says. “Professor that teaches logic. I think I got something fun for you though.” He asks the waiter for three plastic bottles, with a ping pong ball that he pulled out of nowhere. “I’m also an amateur magician. Your drink is on me if you could guess where is the ball correctly.”\n";
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
		string dialogue = s + "Classic trick. Ball under the left bottle, reorder the bottles with crazy fast speed. It’s hard to follow all the moves but I think the ball is still under the bottle on the left. “Which one?”\n";
		scrollingTextRoutine = scrollingText (dialogue);
		StartCoroutine (scrollingTextRoutine);
	}

	void s7(string s, string cup){
		// Update current state
		currState = State.s7;

		resetButtons();
		option1.GetComponentInChildren<Text>().text = "Logic professor should have rational choice. “I’ll switch.”\n";
		option2.GetComponentInChildren<Text>().text = "He is trying to trick me here. “I’ll stay.”\n";

		// Additional text
		string dialogue = s + "“Are you sure?” He revealed the bottle on the " + cup + ", nothing inside.\n“I’ll give you a chance to switch. What’s your choice now?” \nWell, a Monty Hall problem now. This guy must have learned some logic before and trying to test me now.\n";
		scrollingTextRoutine = scrollingText (dialogue);
		StartCoroutine (scrollingTextRoutine);
	}

	void s8(string s){
		// Update current state
		currState = State.s8;

		resetButtons();
		option1.GetComponentInChildren<Text>().text = "“Nice trick. Good luck and have fun then.”\n";

		// Additional text
		string dialogue = s + "He then reveals all the bottles and the bottle I chose at first had the ball! “You forgot I’m a magician.” \n\nOh come on. This is cheating. “Sorry about that Chris”, he says,\n\n";
		dialogue += "“But you are such a good man so don’t worry, your drink is on me.”\n\n“Thanks for that, James.” He stands up and say: “No problem. Thanks for your time though, finish my magic trick practicing. Saw that girl over there? That’s my actual target tonight.” I look at the direction he points to, well, seems like I’m just the warm-up round for James.\n";
		scrollingTextRoutine = scrollingText (dialogue);
		StartCoroutine (scrollingTextRoutine);
	}

	void s9(string s){
		// Update current state
		currState = State.s9;

		resetButtons();
		option1.GetComponentInChildren<Text>().text = "Take a drink...\n";

		// Additional text
		string dialogue = s + "Magic beats logic. Not surprising though, especially when your final goal is trying to pick up a girl.\n";
		scrollingTextRoutine = scrollingText (dialogue);
		StartCoroutine (scrollingTextRoutine);
	}
}
