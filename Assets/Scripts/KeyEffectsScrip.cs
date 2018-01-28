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
	float expandTime = 5f;

	float expandRatio = 0.7f;

	PlayerScript player;


	// Use this for initialization
	void Start () {
		coroutineFlicking = StartCoroutine(flicking());
		player = FindObjectOfType<PlayerScript>();
	}

	// Update is called once per frame
	void Update () {
		code = keyScribu.thisKeyCode;
		if (code == KeyCode.Escape) {
			return;
		}

		if (Input.GetKeyDown(code)) {
			StopCoroutine(coroutineFlicking);
			coroutineExpanding = StartCoroutine(expanding());
		} else if (Input.GetKeyUp(code)) {
			coroutineFlicking = StartCoroutine(flicking());
			StopCoroutine(coroutineExpanding);
		}
	}

	void DestroyKey (bool success) {

		if (success) {

		} else {
			player.IncreaseAnxiety();
		}

		//var go = Instantiate(puffEffect);

		//.transform.position = this.transform.position;//Camera.main.ScreenToWorldPoint(this.transform.position);
		//Destroy(go, 1);


		Destroy(parentToKill);
	}

	IEnumerator expanding () {
		imageList[0].color = new Color(100, 100, 100, 255);
		float targetScale = parentToKill.transform.localScale.x * expandRatio;
		while (expandTime > 0) {
			expandTime -= Time.deltaTime;
			float originalScale = parentToKill.transform.localScale.x;
			float nuScale = Mathf.Lerp(originalScale, targetScale, Time.deltaTime);
			parentToKill.transform.localScale = new Vector3(nuScale, nuScale, nuScale);
			yield return null;
		}
		DestroyKey(true);
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

		DestroyKey(false);
	}

}
