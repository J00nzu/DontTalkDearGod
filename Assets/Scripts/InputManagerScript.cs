using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InputManagerScript : MonoBehaviour {

	string[,] allowedKeys = 
		{	{"Q", "W" , "E", "R", "T", "Y", "U", "I", "O", "P" },
			{"A", "S" , "D", "F", "G", "H", "J", "K", "L", "" },
			{"Z", "X" , "C", "V", "B", "N", "M", "", "", "" }};

	bool[,] allowedKeysBools;

	public GameObject keyPrefab;
	public Transform canvas;


	// Use this for initialization
	void Start () {

		ResetAllowedKeys();
		StartCoroutine(GameLoop());
	}

	public void ResetAllowedKeys () {
		int width = allowedKeys.GetLength(0);
		int height = allowedKeys.GetLength(1);

		allowedKeysBools = new bool[width, height];
		for (int i = 0; i < width; i++) {
			for (int j = 0; j < height; j++) {
				allowedKeysBools[i, j] = true;
			}
		}
	}

	public string GetAllowedKey () {
		int width = allowedKeys.GetLength(0);
		int height = allowedKeys.GetLength(1);
		string key = "";
		while (key.Equals("")) {
			int x = Random.Range(0, width - 1);
			int y = Random.Range(0, height - 1);
			if (CheckKey(x, y)) {
				key = allowedKeys[x, y];
				allowedKeysBools[x, y] = false;
			}

		}

		return key;
	}

	public bool CheckKey (string key) {
		int width = allowedKeys.GetLength(0);
		int height = allowedKeys.GetLength(1);
		int ix = 0;
		int iy = 0;
		for (int i = 0; i < width; i++) {
			for (int j = 0; j < height; j++) {
				string s = allowedKeys[i, j];
				if (s.Equals(key)) {
					ix = i;
					iy = j;
				}
			}
		}
		return CheckKey(ix, iy);
	}

	public bool CheckKey (int x, int y) {
		return allowedKeysBools[x, y];
	}

	public void UnlockKey (string key) {
		int width = allowedKeys.GetLength(0);
		int height = allowedKeys.GetLength(1);
		int ix = 0;
		int iy = 0;
		for (int i = 0; i < width; i++) {
			for (int j = 0; j < height; j++) {
				string s = allowedKeys[i, j];
				if (s.Equals(key)) {
					ix = i;
					iy = j;
				}
			}
		}
		UnlockKey(ix, iy);
	}

	public void UnlockKey (int x, int y) {
		allowedKeysBools[x, y] = true;
	}

	public string GetAllowedKey (string nearTo) {
		int width = allowedKeys.GetLength(0);
		int height = allowedKeys.GetLength(1);
		int ix = 0;
		int iy = 0;
		for (int i = 0; i < width; i++) {
			for (int j = 0; j < height; j++) {
				string s = allowedKeys[i, j];
				if (s.Equals(nearTo)) {
					ix = i;
					iy = j;
				}
			}
		}

		string key = "";
		while (key.Equals("")) {
			int x = Random.Range(0, width - 1);
			int y = Random.Range(0, height - 1);
			if ((Mathf.Abs(ix - x) <= 1 && Mathf.Abs(iy - y) <= 1) && (ix != x || iy != y)) {
				if (CheckKey(x, y)) {
					key = allowedKeys[x, y];
					allowedKeysBools[x, y] = false;
				}
			}
		}
		return key;
	}

	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator GameLoop () {
		ResetAllowedKeys();
		for (int i = 0; i < 20; i++) {
			yield return new WaitForSeconds(4f);
			var go = Instantiate(keyPrefab, canvas);
			var keyScript = go.GetComponent<KeyScript>();

			if (i % 10 == 0) {
				ResetAllowedKeys();
			}

			GameObject grannySpawn = GameObject.FindGameObjectWithTag("GrannySpawner");

			if (grannySpawn != null) {
				go.transform.position = grannySpawn.transform.position;
			}
			keyScript.Initialize(GetAllowedKey());
		}

		SceneManager.LoadScene("Victory");
	}
}
