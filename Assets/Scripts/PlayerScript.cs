using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerScript : MonoBehaviour {

	public enum BreathingDifficulty { easy, medium, hard }; 

	public float oxygen = 100;
	public float lungFill = 100;
	public float breatheTime = 2f;

	float oxygenGain = 0.25f;

	float oxygenDecay = 0.15f;
	float breathMultiplier = 10f;

	bool breathingIn = false;

	public KeyCode breathKey = KeyCode.RightShift;

	private int anxiety = 0;
	private int maxAnxiety = 5;


	// Use this for initialization
	void Start () {
		StartCoroutine(Breathing());
		SetBreathingDifficulty(BreathingDifficulty.easy);
	}
	
	// Update is called once per frame
	void Update () {
		if (oxygen < 0) {
			GameOver();
		}
		oxygen = Mathf.Clamp(oxygen, 0, 100);
		
		if (Input.GetKeyDown(breathKey)) {
			BreatheIn();
		} else if (Input.GetKeyUp(breathKey)) {
			BreatheOut();
		}
	}

	public int GetAnxiety () {
		return anxiety;
	}

	public void IncreaseAnxiety () {
		anxiety++;
		switch (anxiety) {
			case 2:
				SetBreathingDifficulty(BreathingDifficulty.medium);
				break;
			case 4:
				SetBreathingDifficulty(BreathingDifficulty.hard);
				break;
		}
		if (anxiety >= maxAnxiety) {
			GameOver();
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

	void GameOver () {
		SceneManager.LoadScene("GameOver");
	}
}
