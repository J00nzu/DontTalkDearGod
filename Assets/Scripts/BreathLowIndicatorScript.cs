using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BreathLowIndicatorScript : MonoBehaviour {

	PlayerScript player;
	Image img;

	float a = 0;

	// Use this for initialization
	void Start () {
		player = FindObjectOfType<PlayerScript>();
		img = GetComponent<Image>();
		StartCoroutine(BreathFlash());
	}


	// Update is called once per frame
	void Update () {
		a = 1-Mathf.Clamp01((player.oxygen*1.5f)/100.0f);
	}

	IEnumerator BreathFlash () {
		float maxTimer = 1;

		while (true) {
			float t = 0;
			float timer = maxTimer - (a * maxTimer);
			float minA = a / 2;
			float maxA = a;
			float cA;
			while (t <= timer) {
				t += Time.deltaTime;
				cA = maxA - ((t / maxTimer) * (maxA - minA));
				cA = Mathf.Clamp01(cA);

				img.color = new Color(0, 0, 0, cA);
				yield return null;
			}

			while (t >= 0) {
				t -= Time.deltaTime;
				cA = maxA - ((t / maxTimer) * (maxA - minA));
				cA = Mathf.Clamp01(cA);

				img.color = new Color(0, 0, 0, cA);
				yield return null;
			}


		}
	}
}
