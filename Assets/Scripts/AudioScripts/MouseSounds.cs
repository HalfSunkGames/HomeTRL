using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseSounds : MonoBehaviour
{
    // Propiedades públicas
    public AudioSource click; // Sonido de click
    public AudioSource wheel; // Sonido de rueda de ratón

    // Propiedades privadas
    private bool canStart = false; // Bloqueador de sonido

    private void Start()
    {
        Invoke("StartSound", 1.5f); // Retraso del inicio del sonido
    }

    public void ClickSound() // Llamado desde la animación de la mano
    {
        if (canStart) // Si puede sonar (retraso de unos segundos)
        {
            click.Play(); // Lo hace sonar
        }
    }

    public void WheelSound()
    {
        if (canStart)
        {
            wheel.Play();
        }
    }

    private void StartSound() // Bloqueador
    {
        canStart = true;
    }
}