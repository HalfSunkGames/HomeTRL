using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPressed : MonoBehaviour
{
    // Propiedades públicas
	private Animator anim;         // Animador de la tecla
    public FingerKeySound fks;

    // Métodos de Unity
    void Start()
    { 
        anim = GetComponent<Animator>();         // Recupera los componentes
    }
	
    // Métodos privados
	public void Pressed() // Se llama desde los UnityEvent de cada tecla
	{
		anim.SetTrigger("pressed"); // Ejecuta su animación
        fks.KeyBoardSoundDelay();
    }
}