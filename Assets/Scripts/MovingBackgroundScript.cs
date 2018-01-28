using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBackgroundScript : MonoBehaviour {
	public Rigidbody rb;
	public Vector3 rot_dir;
	public float rot_vel = 0.25f;
	// Use this for initialization
	void Start () {
		//rb = GetComponent<Rigidbody>();
		if (rot_dir == new Vector3(0,0,0)) {
			rot_dir = transform.forward;
		}
	}
	
	// Update is called once per frame
	void Update () {
		//transform.Rotate (rot_dir * rot_vel);
		transform.RotateAround (transform.position, rot_dir, rot_vel);
	}
}
