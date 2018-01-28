using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrannySpawnerToMouth : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		GameObject go = GameObject.Find("GrannyMouth");
		transform.position = Camera.main.WorldToScreenPoint(go.transform.position);
	}
}
