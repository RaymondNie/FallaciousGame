using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class scene6 : MonoBehaviour {

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
		option1.GetComponentInChildren<Text>().text = "“Just some salad. How about you?”";
		option2.GetComponentInChildren<Text>().text = "“I cooked a steak. How about you?”";

		// Starting text
		string dialogue = "This beautiful lady comes and reaches her hand out, “Erin. Nice to meet you.”\n\n“Chris. Good to meet you too.”\n\nWell, I should come to “foo bar” more often.\n\n";
		dialogue += "She sits down.\n\nShe puts her hands on the table.\n\nShe looks at me.\n\nCome on man, say something.\n\nWell, she starts the conversation first: “Have you had dinner yet?”\n\n";
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
				dialogue = "“Just some salad. How about you?”\n\n";
				dialogue += "“Salad? Me too, I’m vegetarian. Are you?”\n\n“Sorry I am not.”\n\n“You should try it. You finished your first step by having only salad tonight.”\n\n";
				s2 (dialogue);
			} else if (option == 2) {
				dialogue = "“I cooked a steak. How about you?”\n\n";
				dialogue += "“I just had some salad. I’m vegetarian.”\n\n";
				s2 (dialogue);
			}
		} else if (currState == State.s2) {
			string dialogue;
			if (option == 1) {
				dialogue = "“Might try it sometime soon.”\n\n“Excellent. You will thank me someday.”\n\n";
				s3 (dialogue);
			} else if (option == 2) {
				dialogue = "“Nah I think I will stay stick with being a carnivore”\n\n“Well, can’t say I didn’t try.”\n\n";
				s3 (dialogue);
			}
		} else if (currState == State.s3) {
			if (option == 1) {
				string dialogue = "“Have fun with your friends then.”\n\n";
				s4 (dialogue);
			} else if (option == 2) {
				string dialogue = "“I really enjoyed this conversation with you. I think I might need some advice for being a vegetarian in the future. Can I have your number?”\n\n";
				dialogue += "She smiles and replies: “Nobody still texts anymore. Search my name Erin MacDonald on Facebook. The one in Ontario is me.”\n\n“No problem. Have fun then.”\n\nShe walks away and I take out my phone instantly, type the name and search... \n\n**** you… That’s an 80 year old lady from Thunder Bay.\n\n";
				s4 (dialogue);
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
		option1.GetComponentInChildren<Text>().text = "“I might try to make the switch sometime soon.”";
		option2.GetComponentInChildren<Text>().text = "“Nah I think I will stay stick with being a carnivore”";
		 
		// Additional text
		string dialogue = s + "She then continues to talk about the benefits of being a vegetarian, but I kind of lose interest in the conversation and just stare at her.\n\nBefore my imagination started getting too strange, she interrupts my thought and asks: “Have you been convinced to become a vegetarian now?”\n\nAs a meat lover I hesitate, but don’t really want to say no here.\n\n";
		scrollingTextRoutine = scrollingText (dialogue);
		StartCoroutine (scrollingTextRoutine);
	}


	void s3(string s){
		// Update current state
		currState = State.s3;

		resetButtons();
		option1.GetComponentInChildren<Text>().text = "“Have fun with your friends then.”";
		option2.GetComponentInChildren<Text>().text = "“I really enjoyed this conversation with you. I think I might need some advice for being a vegetarian in the future. Can I have your number?” ";

		// Additional text
		string dialogue = s + "she laughs, “By the way, what do you do during the day?”\n\n“Oh I’m a professor who teaches logic.”\n\n“That’s really special. Logic. Emm...what are some interesting things that you teach about?”\n\n";
		dialogue += "Finally, my years of study have have culminated to this moment. Logic is such a huge topic though.\n\nI think of something that might be fun. : “Did you know that Hitler, the Nazi leader, is also a vegetarian?”";
		dialogue += "“Oh really? That’s surprising. But are you sure you are not making this up?”\n\n";
		dialogue += "“No definitely not. He doesn’t even drink.”\n\n“Well, I do drink so that’s nice. Just sharing one habit with Hitler should be fine.”\n\n“Don’t feel bad for yourself. You are actually in a classic fallacy called bad company fallacy, or guilt by association. Basically, just because you did the same thing as some bad people doesn’t necessarily mean you are guilty. For example, Hitler went to washroom and we do as well, right?”\n\n“Wow is the kind of stuff that you teach? Sounds like fun.”\n\n“Of course! In this situation, we actually have a specific Latin phrase for fallacies too, for example this one is called ‘reductio ad Hitlerum’. “ \n\nI’m so glad i could remember the Latin name, hoping that it sounds impressive. \n\nThinking of what part of logic should I introduce to her next, she says: “You are such a fun man. But I still cannot understand why Hitler was a vegetarian. Well, have to go now my friends are waiting me.”\n\n";
		dialogue += "Clearly she still doesn’t fully understand the fallacy.\n\n";
		scrollingTextRoutine = scrollingText (dialogue);
		StartCoroutine (scrollingTextRoutine);
	}

	void s4(string s){
		// Update current state
		currState = State.s4;

		resetButtons();
		option1.GetComponentInChildren<Text>().text = "Take a drink...";

		// Additional text
		string dialogue = s + "Well, things can get better. Always have someone else in the bar.\n\n";

		scrollingTextRoutine = scrollingText (dialogue);
		StartCoroutine (scrollingTextRoutine);
	}
}
