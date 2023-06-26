using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FingerKeySound : MonoBehaviour
{
    public AudioSource keySound;

    public void KeyBoardSoundDelay()
    {
        Invoke("SoundKey", 1.5f);   // Hace sonar el sonido de la tecla con un delay
    }

    void SoundKey() // Hace sonar el sonido de la tecla
    {
        keySound.Play();
    }
}
