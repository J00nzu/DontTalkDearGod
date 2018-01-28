using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Thermometer : MonoBehaviour {

	public Sprite[] sprites;

	Image img;
	PlayerScript player;

	int lastThing = -1;

	// Use this for initialization
	void Start () {
		img = GetComponent<Image>();
		player = FindObjectOfType<PlayerScript>();
	}
	
	// Update is called once per frame
	void Update () {
		if (player.GetAnxiety() != lastThing) {

			img.overrideSprite = sprites[player.GetAnxiety()];

			lastThing = player.GetAnxiety();
		}
	}
}
