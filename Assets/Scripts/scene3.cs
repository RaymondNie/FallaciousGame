using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class scene3 : MonoBehaviour {

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
		option1.GetComponentInChildren<Text>().text = "“Are you serious? Never heard of these kind of news before.”";
		option2.GetComponentInChildren<Text>().text = "“That must be hearsay. There are no DNA tests right?”\n\n";

		// Starting text
		string dialogue = "One of the guys standing in the middle of bar comes towards me. He takes off his red hood: “Gentleman, how are you? I’m Tong.”\n\n“Chris. Nice to meet you.” I replied. \n\n“Do you come to this bar often?”\n\n“No. My first time in this bar.”\n\n“Then as a frequent customer, let me tell you something interesting about this bar. The bar has some special relationship with Bud Light. Some say that the owner of the bar is actually the Bud Light CEO’s illegitimate child.”\n\n";
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
				dialogue = "“Are you serious? Never heard of these kind of news before.”\n\n“Not 100% sure but as a beer lover I’m quite reliable.";
				s2 (dialogue);
			} else if (option == 2) {
				dialogue = "“That must be hearsay. There are no DNA tests right?”\n\n“No but as a beer lover I’m quite reliable.";
				s2 (dialogue);
			}
		} else if (currState == State.s2) {
			string dialogue;
			if (option == 1) {
				dialogue = "“I bet you 20 dollars that the bottle there is blue.”\n\n";
				s3 (dialogue);
			} else if (option == 2) {
				dialogue = "“I bet you a drink that the bottle there is blue.”\n\n";
				s3 (dialogue);
			}
		} else if (currState == State.s3) {
			if (option == 1) {
				string dialogue = "“It’s something called Bayes’ Theorem.”\n\n";
				s4 (dialogue, 1);
			} else if (option == 2) {
				string dialogue = "“Nah I just don’t believe all these ridiculous things.”\n\n";
				s4 (dialogue, 2);
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
		option1.GetComponentInChildren<Text>().text = "“I bet you a 20 dollars that the bottle there is blue.”";
		option2.GetComponentInChildren<Text>().text = "“I bet you a drink that the bottle there is blue.”";

		// Additional text
		string dialogue = s + " Do you see those beer bottles that the bartender is holding? It’s Bud Light and it’s the golden bottle. Those are limited editions, being produced 1 in a million and they got two of them here!”\n\nI follow his finger and to be honest, I cannot really distinguish whether the bottle is blue or gold, but the bottles do look special and different from the daily ones I normally have.\n\n“Are you sure about that? Aren’t the gold editions just for Canada 150?”\n\n“Good question. I can say I’m 90% sure that one the bartender holding is gold. And it’s not for Canada 150 because that one is also a blue bottle. The gold version is 1 in a million, it even says so on their official website.”\n\nAs a professor who knows Bayes’ Theorem, I see an opportunity to win a bet here.\n\n";
		scrollingTextRoutine = scrollingText (dialogue);
		StartCoroutine (scrollingTextRoutine);
	}

	void s3(string s){
		// Update current state
		currState = State.s3;

		resetButtons();
		option1.GetComponentInChildren<Text>().text = "“It’s something called Bayes’ Theorem.”";
		option2.GetComponentInChildren<Text>().text = "“Nah I just don’t believe all these ridiculous things.”";

		// Additional text
		string dialogue = s + "“Why? You don’t like this rumor?”, he asks.\n\n";
		scrollingTextRoutine = scrollingText (dialogue);
		StartCoroutine (scrollingTextRoutine);
	}

	void s4(string s, int option){
		// Update current state
		currState = State.s4;

		resetButtons();
		option1.GetComponentInChildren<Text>().text = LevelManager.end_text ();

		// Additional text
		string dialogue = s + "Tong agrees with the bet without hesitation and calls the bartender. It’s a gold bottle.\n\nThe bartender says: “You guys want to check the limited edition as well? It’s legit and the owner of the bar gave this one to me himself.”\n\n";
		if (option == 1) {
			dialogue += "Tong chuckles, “I told you Chris. I have learned Bayes’ Theorem before as well but the rumor is true man.”\n\n";
		} else {
			dialogue += "Tong chuckles, “Sometimes even ridiculous things can be true.”\n\n";
		}
		dialogue += "I’m a little bit disappointed, but I decide to ask the bartender.\n\n“Have you heard of the rumors about Bud Light CEO and this place?”\n\n“I'm going to choose to remain silent on that.”\n\nWith a strange smile on her face she leaves us and goes back to work.";
		dialogue += "Tong takes his reward and thanks me for it, “At least we have more insight about the rumor man.”\n\nI throw my hands up in the air, trying to calculate how unlucky I am, as I apply the Bayes’ formula in my head. It’s probably just not my day.\n\n";
		scrollingTextRoutine = scrollingText (dialogue);
		StartCoroutine (scrollingTextRoutine);
	}
}
