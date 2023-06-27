using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shake : MonoBehaviour
{
    // Propiedades públicas
    public float shakeValue = 0;      // Valor de vibración
    public Vector2 originalPosition;  // Posición original
    public Vector2 newPos;            // Posición a la que se mueve
    
    // Propiedades privadas
    private RectTransform rT;

    // Métodos Monodevelop
    void Start()     // Start is called before the first frame update
    {
        rT = GetComponent<RectTransform>();        
        originalPosition = rT.anchoredPosition;   // Guarda la posición original para vibrar
    }

    // Update is called once per frame
    void Update()
    {   // En cada frame, se mueve a una posición cercana aleatoria, más lejana según la intensidad que le entra
        newPos.x = Random.Range(originalPosition.x - 1 * shakeValue, originalPosition.x + 2 * shakeValue);        
        newPos.y = Random.Range(originalPosition.y - 1 * shakeValue, originalPosition.y + 2 * shakeValue);
        rT.anchoredPosition = newPos;
    }

    // Métodos public
    public void ShakeInput(float input) // Determina la intensidad de la vibración
    {
        shakeValue = input;
    }
}
