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
	public Transform typology;
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


		if (triggerButtonPressed) {

			rightControllerPosition = this.transform.position;
			resizingThePlane = true;
			typology.transform.position = rightControllerPosition;

		
		}
		if (triggerButtonUp) 
		{
			resizingThePlane = false;


		}


	}



	void OnTriggerStay(Collider col)
	{
		
		/*if(col.gameObject.CompareTag("PlaneSizeSliderHolder"))
		{
			if (resizingThePlane==true) {
				

				planeSizeSlider.gameObject.transform.localScale = new Vector3 ((Controller.GetAxis ().x * 2), 1, 1);

				}

		}


*/

		if(col.gameObject.CompareTag("TypologyMenuButton"))
		{
			if (resizingThePlane) {
				Instantiate (typology);
			}

		}



	}


}
