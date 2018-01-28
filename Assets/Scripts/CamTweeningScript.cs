using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CamTweeningScript : MonoBehaviour {
	public float animationTimeSec = 2.5f;
	//[Range(0.0f, 1.0f)] public float parameter = 0.0f;
	//public float parameter = 0.0f;
	public float parameter = 0.0f;

	public float IntroStaticTextHoldSec = 2.0f;
	public float IntroStaticTextSec = 5.5f;

	bool introTextDone = false;
	Image img01;
	float t, clamped_t;
	Color lerpedColor = Color.clear;

	float animationTimeLapsed = 0.0f;
	BansheeGz.BGSpline.Components.BGCcCursor camPosCursor, camRotCursor;

	// Use this for initialization
	void Start () {
		camPosCursor = transform.Find ("BGCurve CamPos").gameObject.GetComponent<BansheeGz.BGSpline.Components.BGCcCursor> ();
		camRotCursor = transform.Find ("BGCurve CamRot").gameObject.GetComponent<BansheeGz.BGSpline.Components.BGCcCursor> ();

		img01 = transform.Find ("Canvas").Find ("Image").GetComponent<Image>();
	}

	// Update is called once per frame
	void Update () {
		if (!introTextDone) {
			t = Time.time;
			if (t > IntroStaticTextHoldSec) {
				clamped_t = Mathf.Clamp ((t - IntroStaticTextHoldSec) / (IntroStaticTextSec - IntroStaticTextHoldSec), 
					                     0.0f, 1.0f);
					
				lerpedColor = Color.Lerp (Color.white, Color.clear, clamped_t);
				img01.color = lerpedColor;
			}
			if (t > IntroStaticTextSec)	introTextDone = true;
		}


		//if (introTextDone) {
		if (Time.time > IntroStaticTextHoldSec) {
			animationTimeLapsed += Time.deltaTime;
			if (animationTimeLapsed < animationTimeSec && parameter < 1.0f) {
				parameter += Time.deltaTime / animationTimeSec;

				camPosCursor.DistanceRatio = EasingFunction.EaseInOutSine (0.0f, 1.0f, parameter);
				//camRotCursor.DistanceRatio = EasingFunction.EaseInOutQuad (0.0f, 1.0f, animationTimeLapsed / animationTimeSec);
				camRotCursor.DistanceRatio = camPosCursor.DistanceRatio;
			} else {
				parameter = 1.0f;
			}
		}
	}
}
