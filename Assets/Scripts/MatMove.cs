using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatMove : MonoBehaviour
{
    // Variables públicas
    public float speedX = 0.1f; // Velocidad a la que se mueve el material
    public float speedY = 0.1f;

    // Variables privadas
    private float curX;
    private float curY;
    private Material mat;
    private Vector2 curPosition;

    // Metodos Monodevelop
    void Start()
    {
        mat = GetComponent<Renderer>().material;
        curX = mat.mainTextureOffset.x;
        curY = mat.mainTextureOffset.y;
        curPosition = new Vector2(curX, curY);
    }

    void Update()
    {
        curX += Time.deltaTime * speedX;
        curY += Time.deltaTime * speedY;
        curPosition.Set(curX, curY);

        mat.SetTextureOffset("_MainTex", curPosition);
    }
}