using UnityEngine.Audio;
using UnityEngine;

using System.Collections;
using System.Collections.Generic;

public class AudioManager : MonoBehaviour {

	public Sound[] sounds;
	// Use this for initialization


	void Awake(){

		foreach (Sound s in sounds) {
			s.source = gameObject.AddComponent<AudioSource> ();

			s.source.clip = s.clip;

			s.source.volume = s.volume;

			s.source.pitch = s.pitch;

			s.source.loop = s.loop;

		}
	}

	void Start () {
		
	}
	
	// Update is called once per frame
	public void Play(string name){
		Sound sound = new Sound();
		foreach (Sound s in sounds) {

			if (s.name.Equals (name)) {


				sound = s;
			}


		}
		if (sound == null) {
			return;

		}
		sound.source.Play ();
	}


	public IEnumerator RandomPlay(){
		
		int count = 0;

		while (true) {
			int num = Random.Range (1, 4);



				Debug.Log (num);
				switch (num) {
				case 1:
					Play ("granny1");
					count = 0;
					break;

				case 2:
					Play ("granny2");
					count = 0;
					break;

				case 3:
					Play ("granny3");
					count = 0;
					break;

				case 4:
					Play ("granny4");
					count = 0;
					break;



				}


			yield return new WaitForSeconds (55);
		}


	}
}
