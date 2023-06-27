using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FingerKeySound : MonoBehaviour
{
    // Variables públicas
    public AudioSource keySound; // Sonido de la tecla

    // Métodos públicos
    public void KeyBoardSoundDelay()
    {
        Invoke("SoundKey", 1.5f);   // Hace sonar el sonido de la tecla con un delay
    }

    // Métodos privados
    void SoundKey() // Hace sonar el sonido de la tecla
    {
        keySound.Play();
    }
}