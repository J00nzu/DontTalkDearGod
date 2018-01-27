using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerScript : MonoBehaviour {

	public enum BreathingDifficulty { easy, medium, hard }; 

	public float oxygen = 60;
	public float lungFill = 100;
	public float breatheTime = 2f;

	float oxygenGain = 0.25f;

	float oxygenDecay = 0.15f;
	float breathMultiplier = 10f;

	bool breathingIn = false;



	// Use this for initialization
	void Start () {
		StartCoroutine(Breathing());
		SetBreathingDifficulty(BreathingDifficulty.easy);
	}
	
	// Update is called once per frame
	void Update () {

		oxygen = Mathf.Clamp(oxygen, 0, 100);
		
		if (Input.GetKeyDown(KeyCode.Space)) {
			BreatheIn();
		} else if (Input.GetKeyUp(KeyCode.Space)) {
			BreatheOut();
		}
	}

	void OnGUI () {
		GUI.Box(new Rect(20, 20, 160, 30), "oxygen: "+oxygen+"%");
		GUI.Box(new Rect(20, 60, 160, 30), "oxygenGain: " + oxygenGain + "%");
		GUI.Box(new Rect(20, 100, 160, 30), "lungFill: " + lungFill + "%");

	}

	public void SetBreathingDifficulty (BreathingDifficulty dificult) {
		switch (dificult) {
			case BreathingDifficulty.easy:
				oxygenGain = 0.35f;
				breathMultiplier = 20f;
				break;
			case BreathingDifficulty.medium:
				oxygenGain = 0.28f;
				breathMultiplier = 30;
				break;
			case BreathingDifficulty.hard:
				oxygenGain = 0.22f;
				breathMultiplier = 40;
				break;
			default:
				break;
		}
	}

	public void BreatheIn () {
		breathingIn = true;
	}

	public void BreatheOut () {
		breathingIn = false;
	}

	IEnumerator Breathing () {
		float timer = 0;

		while (true) {
			timer = 0;
			while (breathingIn) {
				timer += Time.deltaTime;
				if (timer < breatheTime * 0.50f) {
					oxygen -= oxygenDecay * Time.deltaTime * breathMultiplier;
				} else if (timer < breatheTime * 1f) {
					oxygen += oxygenGain * Time.deltaTime * breathMultiplier;
				} else {
					oxygen -= oxygenDecay * Time.deltaTime * breathMultiplier;
				}
				lungFill = Mathf.Clamp01(timer / breatheTime) * 100;

				yield return null;
			}
			timer = 0;
			while (!breathingIn) {
				timer += Time.deltaTime;
				if (timer < breatheTime * 0.50f) {
					oxygen -= oxygenDecay * Time.deltaTime * breathMultiplier;
				} else if (timer < breatheTime * 1f) {
					oxygen += oxygenGain * Time.deltaTime * breathMultiplier;
				} else {
					oxygen -= oxygenDecay * Time.deltaTime * breathMultiplier;
				}
				lungFill = (1-Mathf.Clamp01(timer / breatheTime)) * 100;
				yield return null;

			}
		}
	}
}
