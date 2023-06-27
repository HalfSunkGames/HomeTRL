using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shake : MonoBehaviour
{
    // Propiedades p�blicas
    public float shakeValue = 0;      // Valor de vibraci�n
    public Vector2 originalPosition;  // Posici�n original
    public Vector2 newPos;            // Posici�n a la que se mueve
    
    // Propiedades privadas
    private RectTransform rT;

    // M�todos Monodevelop
    void Start()     // Start is called before the first frame update
    {
        rT = GetComponent<RectTransform>();        
        originalPosition = rT.anchoredPosition;   // Guarda la posici�n original para vibrar
    }

    // Update is called once per frame
    void Update()
    {   // En cada frame, se mueve a una posici�n cercana aleatoria, m�s lejana seg�n la intensidad que le entra
        newPos.x = Random.Range(originalPosition.x - 1 * shakeValue, originalPosition.x + 2 * shakeValue);        
        newPos.y = Random.Range(originalPosition.y - 1 * shakeValue, originalPosition.y + 2 * shakeValue);
        rT.anchoredPosition = newPos;
    }

    // M�todos public
    public void ShakeInput(float input) // Determina la intensidad de la vibraci�n
    {
        shakeValue = input;
    }
}
