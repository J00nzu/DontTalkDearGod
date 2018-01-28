using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntroSeqScript : MonoBehaviour {
	public float[] keys = {
		1.0f, 2.5f,
		3.5f, 4.5f,
		5.5f, 6.5f,
	};

	public int keyPairIdx = 0;
	float t = 0.0f;

	Color lerpedColor = Color.clear;
	Image img01,img02,img03;

	// Use this for initialization
	void Start () {
		img01 = transform.Find ("Image donttalk").GetComponent<Image> ();
		img02 = transform.Find ("Image ohdeargod").GetComponent<Image> ();
		img03 = transform.Find ("Image end").GetComponent<Image> ();

		InvokeRepeating("fadeImg01", keys[0], 0.02f);
	}

	void fadeImg01 () {
		t = Time.time;
		keyPairIdx = 0;

		lerpedColor = Color.Lerp (Color.black, Color.white, 
			Mathf.Clamp ( (t - keys[keyPairIdx]) / (keys[keyPairIdx] - keys[keyPairIdx+1]), 
			               0.0f, 1.0f));
		img01.color = lerpedColor;
	}

	// Update is called once per frame
	void Update () {
		
	}
}
