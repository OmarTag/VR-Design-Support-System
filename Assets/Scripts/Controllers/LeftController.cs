using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftController : MonoBehaviour {

	//Trigger button init. for left controller
	private Valve.VR.EVRButtonId triggerButton = Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger;

	//Trigger button actions init. for left controller
	bool triggerButtonDown = false;
	bool triggerButtonUp= false;
	bool triggerButtonPressed = false;



	//grip button init. for left controller
	private Valve.VR.EVRButtonId gripButton = Valve.VR.EVRButtonId.k_EButton_Grip;

	//grip button actions init. for left controller
	bool gripButtonDown = false;
	bool gripButtonUp= false;
	bool gripButtonPressed = false;


	//touchpad  init. for left controller
	private Valve.VR.EVRButtonId touchPad = Valve.VR.EVRButtonId.k_EButton_SteamVR_Touchpad;

	//touchpad actions init. for left controller
	bool touchPadPressed = false;

	//controller init.
	private SteamVR_TrackedObject trackedObject;
	private SteamVR_Controller.Device Controller {get{return SteamVR_Controller.Input((int)trackedObject.index); }}


	//Menu Init.
	public GameObject menu;

	// Use this for initialization
	void Start () {
		trackedObject = GetComponent<SteamVR_TrackedObject> ();
		menu.SetActive (false);

	}

	// Update is called once per frame
	void Update () {
		if (Controller == null) 
		{
			Debug.Log ("controller is switched off");
		}

		//check the status of the leftcontroller gripButton
		gripButtonDown = Controller.GetPressDown(gripButton); 
		gripButtonUp = Controller.GetPressUp(gripButton); 
		gripButtonPressed = Controller.GetPress(gripButton); 

		//check the status of the leftcontroller triggerButton
		triggerButtonDown = Controller.GetPressDown(triggerButton); 
		triggerButtonUp = Controller.GetPressUp(triggerButton); 
		triggerButtonPressed = Controller.GetPress(triggerButton); 

		//check the status of the leftcontroller touchpad
		touchPadPressed = Controller.GetTouch (touchPad);


		if (triggerButtonPressed) {

			menu.SetActive (true);

		}
		if (triggerButtonUp) {

			menu.SetActive (false);
		
		}

		if (touchPadPressed) {


			//Debug.Log (Controller.GetAxis().x+","+Controller.GetAxis().y);
			menu.gameObject.transform.Rotate (new Vector3 (0, 0, -Controller.GetAxis().x*3));

		}

	}	

}
