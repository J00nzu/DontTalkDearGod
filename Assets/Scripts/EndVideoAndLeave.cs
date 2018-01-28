using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

using UnityEngine.SceneManagement;

public class EndVideoAndLeave : MonoBehaviour {
	private VideoPlayer vp;
	// Use this for initialization
	void Start () {
		vp = this.gameObject.GetComponent<VideoPlayer> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (!vp.isPlaying) {
			SceneManager.LoadScene (0);
		}
	}
}
