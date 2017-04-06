using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightController : MonoBehaviour {

	//Trigger button init. for right controller
	private Valve.VR.EVRButtonId triggerButton = Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger;

	//Trigger button actions init. for right controller
	bool triggerButtonDown = false;
	bool triggerButtonUp= false;
	bool triggerButtonPressed = false;



	//grip button init. for right controller
	private Valve.VR.EVRButtonId gripButton = Valve.VR.EVRButtonId.k_EButton_Grip;

	//grip button actions init. for right controller
	bool gripButtonDown = false;
	bool gripButtonUp= false;
	bool gripButtonPressed = false;


	//touchpad  init. for right controller
	private Valve.VR.EVRButtonId touchPad = Valve.VR.EVRButtonId.k_EButton_SteamVR_Touchpad;

	//touchpad actions init. for right controller
	bool touchPadPressed = false;
	bool touchPadUp = false;
	//controller init. 
	private SteamVR_TrackedObject trackedObject;
	private SteamVR_Controller.Device Controller {get{return SteamVR_Controller.Input((int)trackedObject.index); }}

	//RightController position
	Vector3 rightControllerPosition;


	//Slider GameObject Attributes
	public GameObject planeSizeSlider;
	bool resizingThePlane = false;

	//Typology Instantiation
	public GameObject typology;
	private GameObject instantiatedPrefab;

	//Trigger Button collider booleans
	private bool createTypology= false;
	private bool holdingTypolgy = false;
	private bool leftTheInstantitatedTypology = false;

	// Use this for initialization
	void Start () {
		
		trackedObject = GetComponent<SteamVR_TrackedObject> ();

	}

	// Update is called once per frame
	void Update () {
		if (Controller == null) 
		{
			Debug.Log ("controller is switched off");
		}

		//check the status of the rightcontroller gripButton
		gripButtonDown = Controller.GetPressDown(gripButton); 
		gripButtonUp = Controller.GetPressUp(gripButton); 
		gripButtonPressed = Controller.GetPress(gripButton); 

		//check the status of the rightcontroller triggerButton
		triggerButtonDown = Controller.GetPressDown(triggerButton); 
		triggerButtonUp = Controller.GetPressUp(triggerButton); 
		triggerButtonPressed = Controller.GetPress(triggerButton); 

		//check the status of the rightcontroller touchpad
		touchPadPressed = Controller.GetTouch (touchPad);
		touchPadUp = Controller.GetTouchUp (touchPad);


		rightControllerPosition = this.transform.position;

		//when the trigger button is pressed
		if (triggerButtonDown) 
		{
			if (createTypology==true) {
				
				leftTheInstantitatedTypology = false;
			   instantiatedPrefab= Instantiate(typology);


			}
		}

		if (triggerButtonPressed) {


			//when creating the typology prefab and colllided with the tpology button in the menu
			if (leftTheInstantitatedTypology == false) {
				instantiatedPrefab.transform.position = rightControllerPosition;
			}
				

			//while holding the trigger and tpology created, keep it in the same position of the controller
			//




		}

		if (triggerButtonUp) 
		{
			//after releasing the trigger it stays whenever its placed
			if (leftTheInstantitatedTypology == false) {
				instantiatedPrefab.transform.position = rightControllerPosition;
				leftTheInstantitatedTypology = true;
			}

		}
	}



	void OnTriggerStay(Collider col)
	{

		if(col.gameObject.CompareTag("TypologyMenuButton"))
		{
			createTypology = true;

		}


		if(col.gameObject.CompareTag("InstatiatedTypology"))
		{
			holdingTypolgy = true;

			Debug.Log ("collided with the typology");

		}


	}

	void OnTriggerExit(Collider col)
	{

		if(col.gameObject.CompareTag("TypologyMenuButton"))
		{
			createTypology = false;

		}

		if(col.gameObject.CompareTag("InstatiatedTypology"))
		{
			holdingTypolgy = false;

			Debug.Log ("UNNNNNNNNNNNNN collided with th typology");

		}




	}


}
