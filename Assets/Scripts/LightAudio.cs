using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightAudio : MonoBehaviour {
	// Propiedades públicas
	public Material lightOffMat;
	public Material lightOnMat;

	//Reemplazo light1-4 con una sola raiz de lights. -Felisa
	public GameObject[] lights;

	// Propiedades privadas

	//Reemplazo light1-4rend con una sola raiz de MeshRenderer. -Felisa
	private MeshRenderer[] lightRenderers;

	// Se ejecuta al iniciar la escena
	void Awake() {

		// Seteo el tamaño de lightRenderers igual al de lights y busco los MeshRenderer de cada light y los asigno a su valor en la raiz.
		lightRenderers = new MeshRenderer[lights.Length];

		for(int i = 0; i < lightRenderers.Length; i++) 
		{
			lightRenderers[i] = lights[i].GetComponent<MeshRenderer>();
		}
	}

	public void ChangeAudioLights(int vol) {
		for(int i = lights.Length-1; i >= 0; i--) 
		{
			lightRenderers[i].material = (vol > i) ? lightOnMat : lightOffMat;
		}
	}
}