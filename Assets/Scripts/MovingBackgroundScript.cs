using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBackgroundScript : MonoBehaviour {
	public Rigidbody rb;
	//Vector3 rot_dir = transform.forward;
	float rot_vel = 1.0f;
	// Use this for initialization
	void Start () {
		//rb = GetComponent<Rigidbody>();
		//rb.velocity = new Vector3(0, 10, 0);
	}
	
	// Update is called once per frame
	void Update () {
		//transform.Rotate (rot_dir * rot_vel);
		transform.RotateAround (transform.position, transform.forward, rot_vel);
	}
}
