using UnityEngine.Audio;
using UnityEngine;

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
}
