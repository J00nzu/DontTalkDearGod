using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeySuccessEffect : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Destroy(this.gameObject, 1.5f);
	}
	
	// Update is called once per frame
	void Update () {
		transform.localScale *= (1 + (0.5f * Time.deltaTime));
		transform.Translate(Vector3.up*100*Time.deltaTime);
		transform.Rotate(new Vector3(0, 0, 360 * Time.deltaTime));
	}
}
