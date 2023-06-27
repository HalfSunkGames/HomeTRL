using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightAudio : MonoBehaviour {
	// Propiedades públicas
	public Material lightOffMat;
	public Material lightOnMat;
	public MeshRenderer[] lightRenderers;

	public void ChangeAudioLights(int vol) // Desde SceneController. Al pulsar espacio, se ilumina según el volumen
	{
		for(int i = lightRenderers.Length-1; i >= 0; i--) 
		{
			lightRenderers[i].material = (vol > i) ? lightOnMat : lightOffMat;
		}
	}
}