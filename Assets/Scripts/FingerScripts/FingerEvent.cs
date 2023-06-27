using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FingerEvent : MonoBehaviour 
{
	// Propiedades públicas
	[Header("Prefabs")]
	public FingerManager[] Keyboards;

	// Propiedades privadas
	private float seconds = 4f;   // Segundos que tarda en hacer un cambio
	private float slowRate = 6f; // Segundos que debes esperar antes de bajar la velocidad de nuevo
	private float nextSlow = 0f;  // Tiempo hasta el próximo slow de dedos

    // Métodos públicos
    public void MoreSeconds() // Añade segundos cuando el jugador se posa en el CTRL en dos intervalos de menos a más (depende velocidad actual)
    {
        if (Time.time > nextSlow)
        {
            if (seconds < 1.5f)
                seconds += seconds * 0.5f;
            else if (seconds < 0.7)
                seconds += seconds * 2f;

            nextSlow = Time.time + slowRate; //El siguiente punto de slow se pone 6 segundos por delante del momento actual
        }
    }

    // Métodos privados
    private void OnEnable() // Se ejecuta al activarse
    { 
		InvokeRepeating("LessSeconds", 1f, 5f);      // Inicia el aumento de dificultad
		StartCoroutine(FingerTap());                 // Inicia el tecleo
	}

    private void LessSeconds() 
	{
		if(SceneController.pause == false)   // Si el juego no está parado
        { 
											 // disminuye la velocidad gradualmente en base a un porcentaje
			if(seconds >= 2f)
				seconds -= Mathf.Round(((seconds * 15) / 100) * 100) / 100; //Redondea los decimales a dos
			else if(seconds >= 0.2f)
				seconds -= Mathf.Round(((seconds * 10) / 100) * 100) / 100;
		}
	}

	private IEnumerator FingerTap() // Cada itinerancia hace caer un dedo al teclado
	{
		yield return new WaitForSeconds(seconds);

		if(SceneController.pause == false) 
		{
			foreach(FingerManager keyboard in Keyboards) {
				if(keyboard)
					keyboard.TapFinger();
			}
		}
		StartCoroutine(FingerTap());        // Se llama a sí mismo para repetir el bucle
	}
}