using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyEffectsScrip : MonoBehaviour {

	private Image image;

	public List<Image> imageList;

	public GameObject puffEffect;
	public GameObject parentToKill;

	public KeyScript keyScribu;


	public int timer;
	public float SecondsToWait;

	private Coroutine coroutineFlicking;
	private Coroutine coroutineExpanding;

	private KeyCode code = KeyCode.Escape;

	public float speed;


	float flickTime = 2f;

	// Use this for initialization
	void Start () {
		coroutineFlicking = StartCoroutine(flicking());
	}

	// Update is called once per frame
	void Update () {
		code = keyScribu.thisKeyCode;
		if (code == KeyCode.Escape) {
			return;
		}
<<<<<<< HEAD
	}


    IEnumerator endFlick()
    {
		
		//Color defual = image.color;
		float factor = 0.8f;
		StartCoroutine( endTap());
		for(int i = 0 ; i < timer;i++) {

					imageList [0].color = new Color (100, 100, 100,255);
				
			//image.color = defual;
			yield return new WaitForSeconds (this.SecondsToWait);
			//Debug.Log ("toimii");

					imageList [0].color = new Color (255, 0, 0);
				
			yield return new WaitForSeconds (this.SecondsToWait);

			this.SecondsToWait = this.SecondsToWait * factor;
=======
>>>>>>> 0820e214da8a1ddf15f3f3dab3dc9c9afb0d61ff

		if (Input.GetKeyDown(code)) {
			StopCoroutine(coroutineFlicking);
		} else if (Input.GetKeyUp(code)) {
			coroutineFlicking = StartCoroutine(flicking());
		}
	}

	void DestroyKey () {

		//var go = Instantiate(puffEffect);

		//.transform.position = this.transform.position;//Camera.main.ScreenToWorldPoint(this.transform.position);
		//Destroy(go, 1);


		Destroy(parentToKill);
	}

	IEnumerator flicking () {

		while (flickTime > 0) {
			imageList[0].color = new Color(100, 100, 100, 255);

			float sleepTime = Mathf.Clamp(flickTime / 8, 0.05f, 1);
			flickTime -= sleepTime*2;

			yield return new WaitForSeconds(sleepTime);

			imageList[0].color = new Color(255, 0, 0);

			yield return new WaitForSeconds(sleepTime);
		}

		DestroyKey();
	}

}
