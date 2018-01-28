using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BansheeGz.BGSpline.Curve;

public class CameraPathFollowerDisabler : MonoBehaviour {
	//BGCurve curve;
	public CamTweeningScript camTweeningScript;
	public CameraSmallVibrationScript cameraSmallVibrationScript;
	// Use this for initialization
	void Start () {
		//curve = GetComponent<BGCurve>();
		//cameraSmallVibrationScript = FindObjectsOfType<CameraSmallVibrationScript> () [0];
		camTweeningScript = GetComponent<CamTweeningScript>();
		cameraSmallVibrationScript = GetComponent<CameraSmallVibrationScript> ();

		cameraSmallVibrationScript.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		//var cursor = curve.GetComponent<BansheeGz.BGSpline.Components.BGCcCursor> ();
		if (camTweeningScript.parameter == 1) {
			//this line only disble the cursor part but still leave some handler not released
			//curve.enabled = false;

			//just release everything about the BGCurve
			//curve.gameObject.SetActive(false);
			camTweeningScript.enabled = false;
			transform.Find ("BGCurve CamPos").gameObject.SetActive(false);
			transform.Find ("BGCurve CamRot").gameObject.SetActive(false);
			cameraSmallVibrationScript.enabled = true;
		}
	}
}
