using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FingerKeySound : MonoBehaviour
{
    // Variables p�blicas
    public AudioSource keySound; // Sonido de la tecla

    // M�todos p�blicos
    public void KeyBoardSoundDelay()
    {
        Invoke("SoundKey", 1.5f);   // Hace sonar el sonido de la tecla con un delay
    }

    // M�todos privados
    void SoundKey() // Hace sonar el sonido de la tecla
    {
        keySound.Play();
    }
}