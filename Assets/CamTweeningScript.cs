using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CamTweeningScript : MonoBehaviour {
	public float animationTimeSec = 2.5f;
	//[Range(0.0f, 1.0f)] public float parameter = 0.0f;
	float parameter = 0.0f;

	float animationTimeLapsed = 0.0f;
	BansheeGz.BGSpline.Components.BGCcCursor camPosCursor, camRotCursor;

	// Use this for initialization
	void Start () {
		camPosCursor = transform.Find ("BGCurve CamPos").gameObject.GetComponent<BansheeGz.BGSpline.Components.BGCcCursor> ();
		camRotCursor = transform.Find ("BGCurve CamRot").gameObject.GetComponent<BansheeGz.BGSpline.Components.BGCcCursor> ();
	}

	// Update is called once per frame
	void Update () {
		animationTimeLapsed += Time.deltaTime;
		if (animationTimeLapsed < animationTimeSec) {
			parameter = animationTimeLapsed / animationTimeSec;

			camPosCursor.DistanceRatio = EasingFunction.EaseInOutSine (0.0f, 1.0f, parameter);
			//camRotCursor.DistanceRatio = EasingFunction.EaseInOutQuad (0.0f, 1.0f, animationTimeLapsed / animationTimeSec);
			camRotCursor.DistanceRatio = camPosCursor.DistanceRatio;
		}
	}
}
