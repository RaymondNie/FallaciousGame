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
	float scrollSpeed = 0.0175f;

	// Different states of the scene
	enum State{s1, s2, s3, s4, s5, s6};
	State currState;

	// Let text control the scrolling
	public ScrollRect myScrollRect;

	// Date counter
	int day = 355;
	void Start(){
		// Initialize start scene
		currState = State.s1;

		// Starting options
		option1.GetComponentInChildren<Text>().text = "“Did you get separated from your parents?”\n\n";
		option2.GetComponentInChildren<Text>().text = "\"Are you old enough to be in here?\"\n\n";

		// Starting text
		string dialogue = "A young looking girl walks down and sits beside me, I notice that she is drinking from a “Minute Maid” orange juice box.\n\n";
		dialogue += "\"Heya mister, I'm Sally nice to meet ya!\" she exclaims.\n\n\"Nice to meet you miss, my name is Chris\"\n";
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
				dialogue = "\"Did you get separated from your parents?\"\n\n";
				s2 (dialogue);
			} else if (option == 2) {
				dialogue = "\"Are you old enough to be in here?\"\n\n";
				s2 (dialogue);
			}
		} else if (currState == State.s2) {
			string dialogue;
			if (option == 1) {
				dialogue = "\"The difference mam is 1 day.\"\n\n";
				// decrement day
				--day;
				s3 (dialogue);
			} else if (option == 2) {
				dialogue = "\"By that logic you could continue and argue a baby should be able to drink!\"\n\n";
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
		option1.GetComponentInChildren<Text>().text = "\"The difference mam is 1 day.\"";
		option2.GetComponentInChildren<Text>().text = "\"By that logic you could continue and argue a baby should be able to drink!\"";

		// Additional text
		string dialogue = s + "She laughs, \"I'm already 21. I'm an engineering student in university. Just getting my daily intake of vitamin C if you were wondering about my drink\"\n\n";
		dialogue += "A student. I shouldn’t mention I’m a prof then.\n\nIt dawns upon me that I haven't thought about my nutrient intake in all the time I've spent in undergrad and postgrad life...\n\n";
		dialogue += "Maybe I need some vitamin C as well...\n\n";
		dialogue += "\"Anyways, speaking about age, I have many friends who are just a few days off from being 19.  They can’t come to this bar with me so I always just end up meeting strange old people\", she says\n\n";
		dialogue += "I wonder if she is referring to me specifically.\n\n";
		dialogue += "I mean, what's the difference between 19 years and 18 years plus 355 days right?\n\n";

		scrollingTextRoutine = scrollingText (dialogue);
		StartCoroutine (scrollingTextRoutine);
	}


	void s3(string s){
		// Update current state
		currState = State.s2;

		// Additional text
		string dialogue = s + "\"Exactly! I mean, what's the difference between 18 years plus " + (day+1) + " days and 18 years plus " + day + " days right?\"\n\n";
		scrollingTextRoutine = scrollingText (dialogue);
		StartCoroutine (scrollingTextRoutine);
	}

	void s4(string s){
		// Update current state
		currState = State.s4;

		resetButtons();
		option1.GetComponentInChildren<Text> ().text = LevelManager.end_text ();

		// Additional text
		string dialogue = s + "\"Hmmm, I guess you're right. Critical thinking isn't my strong suit. Well it's time for me to get going now! See ya.\"\n\n";
		dialogue += "I wonder how long she would have kept going...\n\nShe was iterating the textbook example of the flaw of the fallacy of continuum without realizing it.\n\n";
		dialogue += "\"Take care Sally. You should come to my class on some day\", I think to myself. The university should put logic in the mandatory course list for engineering students.\n\n";
		scrollingTextRoutine = scrollingText (dialogue);
		StartCoroutine (scrollingTextRoutine);
	}
}
