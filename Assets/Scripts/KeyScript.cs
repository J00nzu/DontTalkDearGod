using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyScript : MonoBehaviour {

	public Text text;

	public string key;

	// Use this for initialization
	void Start () {
		
	}

	public void Initialize (string key) {
		this.key = key;
		text.text = key;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
