using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DestroyFinger : MonoBehaviour
{
    // Propiedades públicas
    public GameObject pref; // Prefab del dedo completo


    // Métodos privados
    private void Destroy()
    {
        Destroy(this.pref.gameObject); // Destruye el dedo cayendo
    }

    private void OnTriggerEnter(Collider other) //Se ejecuta cuando la punta del dedo toque un trigger
    {
        if (other.CompareTag("Keyboard")) // Si es el teclado...
        {
            Invoke("Destroy", 0.38f); // Destruye el dedo pasado un tiempo concreto
        } 
    }
}