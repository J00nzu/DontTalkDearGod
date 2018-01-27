using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuffScript : MonoBehaviour {
	
	// Use this for initialization


	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void StartPuffEffect(GameObject go){

		this.transform.position = new Vector3(go.transform.position.x,
			go.transform.position.y,0); 
		StartCoroutine (puffEffect());

	}



	IEnumerator puffEffect(){


		yield return new WaitForSeconds (1);
		Destroy (this.gameObject);
	}
}
