using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpacebarButtonScript : MonoBehaviour {

	Vector3 originalScale;
	PlayerScript player;

	float scaleVariant = 0.2f;
	float notBreathedTime = 0f;
	float notBreathedTimeShakingTreshold = 1.1f;
	float shakeTime = 0.06f;
	float shakeAngle = 0.5f;

	bool shaking = false;

	// Use this for initialization
	void Start () {
		player = FindObjectOfType<PlayerScript>();
		originalScale = transform.localScale;
	}
	
	// Update is called once per frame
	void Update () {
		notBreathedTime += Time.deltaTime;

		transform.localScale = originalScale * (1 + (scaleVariant * (player.lungFill/100f)));

		if (notBreathedTime > player.breatheTime * notBreathedTimeShakingTreshold && !shaking) {
			StartCoroutine(ShakeShakeItGirl());
		}

		if (Input.GetKeyDown(player.breathKey) || Input.GetKeyUp(player.breathKey)) {
			notBreathedTime = 0f;
		}
	}

	IEnumerator ShakeShakeItGirl () {
		shaking = true;
		float timer = 0;
		while (notBreathedTime > player.breatheTime * notBreathedTimeShakingTreshold) {

			while (timer < shakeTime) {
				timer += Time.deltaTime;
				float i = timer / shakeTime;
				transform.rotation = Quaternion.Euler(new Vector3(0,0,i*shakeAngle));

				yield return null;
			}
			while (timer > -shakeTime) {
				timer -= Time.deltaTime;
				float i = timer / shakeTime;
				transform.rotation = Quaternion.Euler(new Vector3(0, 0, i * shakeAngle));

				yield return null;
			}
		}

		while (timer != 0) {
			timer = Mathf.MoveTowards(timer, 0, Time.deltaTime);
			float i = timer / shakeTime;
			transform.rotation = Quaternion.Euler(new Vector3(0, 0, i * shakeAngle));
			yield return null;
		}

		transform.rotation = Quaternion.identity;
		shaking = false;
	}
}
