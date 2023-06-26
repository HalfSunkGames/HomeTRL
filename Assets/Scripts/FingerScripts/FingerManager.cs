using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FingerManager : MonoBehaviour {
	public UnityEvent[] press;   // Array de UnityEvents
	public GameObject[] finger;    // Prefab del dedo

	private void Awake() {
		var allKeys = GetComponentsInChildren<KeyPressed>();
		press = new UnityEvent[allKeys.Length];

		for(int i = 0; i < press.Length; i++) {
			press[i] = new UnityEvent();
			press[i].AddListener(new UnityAction(allKeys[i].Pressed));
		}
	}

	public void TapFinger() {
		if(!gameObject.activeInHierarchy) {
			return;
		}

		int randomPosition = UnityEngine.Random.Range(0, press.Length);   // Coge una posición aleatoria de caída de dedo
		int randomRotation = UnityEngine.Random.Range(0, 360);            // Coge una rotación aleatoria de dedo

		int randomFinger = Random.Range(0, 2);
		Instantiate(finger[randomFinger], KeyboardPosition.positions[randomPosition], Quaternion.Euler(0, randomRotation, 0)); // Instancia el dedo en una posición

		press[randomPosition].Invoke();
	}
}