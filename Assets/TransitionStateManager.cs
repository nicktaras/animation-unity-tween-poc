using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// http://www.pixelplacement.com/itween/documentation.php - tween api.

public class TransitionStateManager : MonoBehaviour {

	public GameObject Game;
	public GameObject ScreenSaver;
	public GameObject CentreStage;
	public GameObject OutOfStage;

	public int state;
	private enum APP_STATES : int { Idle = 0, Active = 2 };

	private bool inTransition;

	void Start () {
		inTransition = false;
		state = (int)APP_STATES.Idle;
	}
		
	void Update () {
		if (Input.GetKeyDown ("up") || Input.GetKeyDown ("down")) {
			stateTransition ();
		}
	}

	public void transitionStart() {
		inTransition = true;
	}

	public void transitionComplete() {
		inTransition = false;
		updateState ();
	}

	public void updateState () {
		if (state == (int)APP_STATES.Active){
			state = (int)APP_STATES.Idle;
		} else {
			state = (int)APP_STATES.Active;
		}
	}
		
	void stateTransition() {
		if (inTransition == false && state == (int)APP_STATES.Idle) {
			iTween.MoveTo (Game, iTween.Hash ("position", OutOfStage.transform.position, "easeType", "easeInBack", "onStart", "transitionStart", "onComplete", "transitionComplete", "onCompleteTarget", this.gameObject));
			iTween.MoveTo (ScreenSaver, iTween.Hash ("position", CentreStage.transform.position, "easeType", "easeOutBack", "delay", .8)); // "loopType", "pingPong",
		}
		if (inTransition == false && state == (int)APP_STATES.Active) {
			iTween.MoveTo (ScreenSaver, iTween.Hash ("position", OutOfStage.transform.position, "easeType", "easeInBack", "onStart", "transitionStart", "onComplete", "transitionComplete", "onCompleteTarget", this.gameObject));
			iTween.MoveTo (Game, iTween.Hash ("position", CentreStage.transform.position, "easeType", "easeOutBack", "delay", .8)); // "loopType", "pingPong",
		}
	}

}
	