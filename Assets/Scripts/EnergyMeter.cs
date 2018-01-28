using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyMeter : MonoBehaviour {

	public Image displayMeter;
	public Sprite[] EnergyMeterImages;

	// Use this for initialization
	void Start () {

		displayMeter = this.gameObject.GetComponent<Image>();

		if (displayMeter != null) {
			Debug.Log ("Found da meter");
		}

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SetNewEnergyMeterStatus(int status){

		displayMeter.sprite = EnergyMeterImages [status-1];

	}
}
