using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPressed : MonoBehaviour
{
    // Propiedades públicas
	private Animator anim;         // Animador de la tecla
    private AudioSource keySound;  // Sonido de tecla
		
    void Start()
    {
        anim = GetComponent<Animator>();         // Recupera los componentes
        keySound = GetComponent<AudioSource>();
    }
	
	public void Pressed() // Se llama desde los UnityEvent de cada tecla
	{
		anim.SetTrigger("pressed"); // Ejecuta su animación
        Invoke("SoundKey", 1.5f);   // Hace sonar el sonido de la tecla con un delay
	}

    void SoundKey() // Hace sonar el sonido de la tecla
    {
        keySound.Play();
    }
}