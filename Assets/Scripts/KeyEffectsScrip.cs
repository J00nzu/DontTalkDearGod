using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyEffectsScrip : MonoBehaviour {

	private Image image;

	public List<Image> imageList;


	public GameObject puffEffect;

	public GameObject parentToKill;


	public int timer;
	public float SecondsToWait;


	private IEnumerator coroutine;

	public float speed;
	// Use this for initialization
	void Start () {

		//image =  this.GetComponent<Image>();


		//coroutine =;//redFlick();

		StartCoroutine(endFlick());


	}

	// Update is called once per frame
	void Update () {

	}

	void DestroyKey () {

		var go = Instantiate(puffEffect);

		go.transform.position = this.transform.position;//Camera.main.ScreenToWorldPoint(this.transform.position);
		Destroy(go, 1);
		Destroy(parentToKill);

	}

	IEnumerator endTap () {
		if (imageList.Count > 1) {

			while (true) {

				imageList[1].color = new Color(100, 100, 100, 0);
				yield return new WaitForSeconds(0.5f);
				imageList[1].color = new Color(100, 100, 100, 255);
				yield return new WaitForSeconds(0.5f);

			}
		}
	}


	IEnumerator endFlick () {

		//Color defual = image.color;
		float factor = 0.8f;
		StartCoroutine(endTap());
		for (int i = 0; i < timer; i++) {

			imageList[0].color = new Color(100, 100, 100, 255);

			//image.color = defual;
			yield return new WaitForSeconds(this.SecondsToWait);

			imageList[0].color = new Color(255, 0, 0);

			yield return new WaitForSeconds(this.SecondsToWait);

			this.SecondsToWait = this.SecondsToWait * factor;

		}

		imageList[0].color = new Color(255, 0, 0);
		yield return new WaitForSeconds(1);
		imageList[0].color = new Color(0, 0, 0, 0);

		DestroyKey();


	}

}
