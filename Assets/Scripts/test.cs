using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		StartCoroutine (chooseGrannySounds());
		Debug.Log ("sound test 1 ");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator chooseGrannySounds(){
		int num = Random.Range (1,4);

		switch(num){
		case 1:
			FindObjectOfType<AudioManager> ().Play ("granny1");
			break;

		case 2:
			FindObjectOfType<AudioManager> ().Play ("granny2");
			break;

		case 3:
			FindObjectOfType<AudioManager> ().Play ("granny3");
			break;

		case 4:
			FindObjectOfType<AudioManager> ().Play ("granny4");
			break;



		}

		yield return new WaitForSeconds (1);

	}
}
