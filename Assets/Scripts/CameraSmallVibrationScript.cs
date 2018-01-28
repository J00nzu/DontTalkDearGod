using UnityEngine;
using System.Collections;

public class CameraSmallVibrationScript : MonoBehaviour {
	// Transform of the camera to shake. Grabs the gameObject's transform
	// if null.
	public Transform camTransform;

	// How long the object should shake for.
	public float shakeDuration = 0f;
	public float shakeWait = 0f;
	public float shakeDurationThreshold = 0.01f;

	// Amplitude of the shake. A larger value shakes the camera harder.
	public float shakeAmount = 0.7f;
	public float decreaseFactor = 1.0f;


	Vector3 originalPos;
	bool shakeDone = false;
	float originalDuration = 0f;
	float waitingTimeLapsed = 0f;

	void Awake() {
		if (camTransform == null)
		{
			//camTransform = GetComponent(typeof(Transform)) as Transform;
			camTransform  = transform.Find("Main Camera").GetComponent<Camera>().transform;
		}
	}

	void OnEnable() {
		originalPos = camTransform.localPosition;
		originalDuration = shakeDuration;

		waitingTimeLapsed = shakeWait;
	}

	void Shake() {
		if (shakeDuration > 0) {
			camTransform.localPosition = originalPos + Random.insideUnitSphere * shakeAmount;

			shakeDuration -= Time.deltaTime * decreaseFactor;
		}
		else {
			shakeDuration = originalDuration;
			camTransform.localPosition = originalPos;
			shakeDone = true;
		}
	}

	void Update() {
		waitingTimeLapsed += Time.deltaTime;
		if (waitingTimeLapsed > shakeWait) {
			Shake ();
		}
		if (shakeDone) {
			waitingTimeLapsed = 0;
			shakeDone = false;
		}
	}
}
