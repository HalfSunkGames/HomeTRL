using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightAudio : MonoBehaviour {
	// Propiedades públicas
	public Material lightOffMat;
	public Material lightOnMat;

	//Reemplazo light1-4 con una sola raiz de lights. -Felisa
	public GameObject[] lights;

	public GameObject light1;
	public GameObject light2;
	public GameObject light3;
	public GameObject light4;

	// Propiedades privadas

	//Reemplazo light1-4rend con una sola raiz de MeshRenderer. -Felisa
	private MeshRenderer[] lightRenderers;
	private MeshRenderer light1rend;
	private MeshRenderer light2rend;
	private MeshRenderer light3rend;
	private MeshRenderer light4rend;

	// Se ejecuta al iniciar la escena
	void Awake() {

		// Seteo el tamaño de lightRenderers igual al de lights y busco los MeshRenderer de cada light y los asigno a su valor en la raiz.
		lightRenderers = new MeshRenderer[lights.Length];

		for(int i = 0; i < lightRenderers.Length; i++) {
			lightRenderers[i] = lights[i].GetComponent<MeshRenderer>();
		}

		//light1rend = light1.GetComponent<MeshRenderer>(); // Recupera los componentes MeshRenderer (para cmaibar el material)
		//light2rend = light2.GetComponent<MeshRenderer>();
		//light3rend = light3.GetComponent<MeshRenderer>();
		//light4rend = light4.GetComponent<MeshRenderer>();
	}

	// Métodos públicos

	// Usa un int para setear el material a On o Off dependiendo del valor. Si el int es 0, todos los materiales seran cambiados a off, y si es 4 viceversa.
	// -Felisa
	public void ChangeAudioLights(int vol) {
		for(int i = lights.Length-1; i >= 0; i--) {
			// (condicion) ? valorA : valorB -- es como un elseif pero metido en una sola linea, si la condicion entre ()
			// es cierta devuelve el valor antes de ':' y si es falsa el que haya despues de ':'
			// -Felisa
			lightRenderers[i].material = (vol > i) ? lightOnMat : lightOffMat;
		}
	}

	/*public void Vol0() // Se ejecuta cuando el volumen se pone a 0/4
	{
		light1rend.material = lightOffMat; // Apaga todas las luces
		light2rend.material = lightOffMat;
		light3rend.material = lightOffMat;
		light4rend.material = lightOffMat;
	}

	public void Vol1() // Se ejecuta cuando el volumen se pone a 1/4
	{
		light1rend.material = lightOnMat;  // Enciende una luz
		light2rend.material = lightOffMat;
		light3rend.material = lightOffMat;
		light4rend.material = lightOffMat;
	}

	public void Vol2() // Se ejecuta cuando el volumen se pone a 2/4
	{
		light1rend.material = lightOnMat;
		light2rend.material = lightOnMat; // Enciende dos luces
		light3rend.material = lightOffMat;
		light4rend.material = lightOffMat;
	}

	public void Vol3() // Se ejecuta cuando el volumen se pone a 3/4
	{
		light1rend.material = lightOnMat;
		light2rend.material = lightOnMat;
		light3rend.material = lightOnMat; // Enciende tres luces
		light4rend.material = lightOffMat;
	}

	public void Vol4() // Se ejecuta cuando el volumen se pone a 4/4
	{
		light1rend.material = lightOnMat;
		light2rend.material = lightOnMat;
		light3rend.material = lightOnMat;
		light4rend.material = lightOnMat; // Enciende cuatro luces
	}*/
}