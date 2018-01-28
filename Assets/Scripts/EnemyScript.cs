using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {


	private int energy = 6;
	private int reduceFactor= 1;
	public int damage = 2;
	public int candy = 5;
	// Use this for initialization
	void Start () {
		StartCoroutine (EnergyReduce());
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.LeftShift)) {
			while(Input.GetKeyUp(KeyCode.LeftShift)){


			}
			GainEnergy ();
		}


	}
	//gain energy from candy
	void GainEnergy(){
		if (candy > 0) {

			energy += 3;

			if (energy > 6) {
				energy = 6;
			}
			EnergyMeter ();
			candy--;

		}
	}

	//gain energy back when typeing right
	public void TypeSuccsesssss(){

		energy++;
	}

	void EnergyMeter(){
		if (energy < 0) {
			energy = 0;
		}

		FindObjectOfType<EnergyMeter> ().SetNewEnergyMeterStatus (energy);


	}

	public void EnergyTakesDamage(){

		energy -= damage;
		EnergyMeter ();
	}


	IEnumerator EnergyReduce(){


		do {




			yield return new WaitForSeconds (4);

			energy -= reduceFactor;
			EnergyMeter();



		} while (energy >= 0);




	}
}
