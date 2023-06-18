using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour {
	// Propiedades públicas
	public Text deadtext;        // Texto de UI de deadfrase
	public Text retrytext;       // Texto informativo de tecla de restart
	public Text storedtext;       // Texto informativo de tecla de restart
	public Text totalPointsTxt;  // Puntos totales obtenidos
	private int unlockedKeys = 0;    // Define cuantos teclados nuevos has desbloqueado
	private bool isWhite = true;

	// Propiedaes privadas
	private string deadfrase = "You were smashed. Wanna try it again?"; // Frase que se escribe en la pantalla del monitor

	// Métodos MonoBehaviour
	void Start() {
		Destroy(GameObject.Find("FingerEvent"));
		StartCoroutine(PrintText());      // Empieza a escribir el deadtext en pantalla
		retrytext.enabled = false;        // No muestra inicialmente el retrytext
		storedtext.enabled = false;        // No muestra inicialmente el retrytext
		totalPointsTxt.enabled = false;   // Ni la puntuación obtenida
		Invoke("Retry", 3.5f);            // Lo mostrará pasados 3.5 segundos (El tiempo que tarda en escribirse la deadfrase)
	}

	// Métodos privados
	void Retry() // Método activado con retraso para no poder reiniciar de golpe
	{
		retrytext.enabled = true;                                   // Muestra el retrytext en el monitor
		storedtext.enabled = true;                                   // Muestra el retrytext en el monitor
		totalPointsTxt.enabled = true;                              // Muestra la puntuación obtenida
		totalPointsTxt.text = PointsController.points.ToString();
		PointsController.points = 0;                                // Limpia los puntos totales
	}

	IEnumerator PrintText() // Método para escribir letra a letra deadfrase
	{
		if (unlockedKeys != 0)
		{
			if (unlockedKeys > 1)
				deadfrase = "You unlocked " + unlockedKeys.ToString() + " new Keyboards!\nWanna try it again?";
			else
                deadfrase = "You unlocked " + unlockedKeys.ToString() + " new Keyboard!\nWanna try it again?";
            foreach (char caracter in deadfrase)
            {
                deadtext.text += caracter;
                yield return new WaitForSeconds(0.07f);
            }
            StartCoroutine(ColorBlinking());
        }
		else
		{
            foreach (char caracter in deadfrase)
            {
                deadtext.text += caracter;
                yield return new WaitForSeconds(0.07f);
            }
        }
	}

	IEnumerator ColorBlinking()
	{
		int index = deadfrase.IndexOf("W");
		string colorChange = deadfrase.Substring(0, index);
		string colorNoChange = deadfrase.Substring(index);
		if (isWhite)
		{
			isWhite = false;
			deadtext.text = "<color=orange>" + colorChange + "</color>" + colorNoChange;
		}
		else
		{
			isWhite = true;
            deadtext.text = "<color=white>" + colorChange + "</color>" + colorNoChange;
        }
        yield return new WaitForSeconds(0.3f);
        StartCoroutine(ColorBlinking());
		
	}

	public void UnlockedKeyboard(int hmk)
	{
		unlockedKeys = hmk;
	}
}