using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyScript : MonoBehaviour {


	public Text text;

	public string key;

	public bool pressed = false;

	public Image unPres, pres;

	public KeyCode thisKeyCode;

	// Use this for initialization
	void Start () {
		
	}

	public void Initialize (string key) {
		this.key = key;
		text.text = key;
		thisKeyCode = (KeyCode)System.Enum.Parse(typeof(KeyCode), key);
		SetImages();
	}

	// Update is called once per frame
	void Update () {
		if (key.Equals("")) {
			return;
		}
		if (Input.GetKey(thisKeyCode)) {
			pressed = true;
		} else {
			pressed = false;
		}
		SetImages();

	}

	void SetImages () {
		if (pressed) {
			pres.enabled = true;
			unPres.enabled = false;
		} else {
			pres.enabled = false;
			unPres.enabled = true;
		}
	}

	void OnDestroy () {
		//FindObjectOfType<InputManagerScript>().UnlockKey(key);
	}
}
