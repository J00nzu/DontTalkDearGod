using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BansheeGz.BGSpline.Curve;

public class CameraPathFollowerDisabler : MonoBehaviour {
	BGCurve curve;
	public CameraSmallVibrationScript cameraSmallVibrationScript;
	// Use this for initialization
	void Start () {
		curve = GetComponent<BGCurve>();
		cameraSmallVibrationScript = FindObjectsOfType<CameraSmallVibrationScript> () [0];
	}
	
	// Update is called once per frame
	void Update () {
		var cursor = curve.GetComponent<BansheeGz.BGSpline.Components.BGCcCursor> ();
		if (cursor.DistanceRatio == 1) {
			//this line only disble the cursor part but still leave some handler not released
			//curve.enabled = false;

			//just release everything about the BGCurve
			curve.gameObject.SetActive(false);
			cameraSmallVibrationScript.enabled = true;
		}
	}
}
