using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class KeyMovementScript : MonoBehaviour {


	private GameObject HolderObject;
	public int timer;
	public float SecondsToWait;
	private IEnumerator coroutine;

	public float speed;
	// Use this for initialization
	void Start () {
		HolderObject = this.gameObject;




		// Start function WaitAndPrint as a coroutine.

		coroutine = BasicMovement ();//redFlick();
		StartCoroutine(coroutine);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator BasicMovement(){
		while (true) {
			for(int i = 0; i < timer;i++){

				//image.transform.position.y += 0.3f * Time.deltaTime;
				yield return new WaitForSeconds (SecondsToWait);
				HolderObject.transform.Translate (Vector3.up *speed* Time.deltaTime);

			}



			for(int i = 0; i < timer;i++){

				//image.transform.position.y -= 0.3f * Time.deltaTime;
				yield return new WaitForSeconds (SecondsToWait);
				HolderObject.transform.Translate (-Vector3.up  *speed* Time.deltaTime);
			}



		}


	}
}
