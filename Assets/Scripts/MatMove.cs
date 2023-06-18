using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatMove : MonoBehaviour
{
    public float speedX = 0.1f;
    public float speedY = 0.1f;

    private float curX;
    private float curY;
    private Material mat;
    private Vector2 curPosition;

    // Use this for initialization
    void Start()
    {
        mat = GetComponent<Renderer>().material;
        curX = mat.mainTextureOffset.x;
        curY = mat.mainTextureOffset.y;
        curPosition = new Vector2(curX, curY);
    }

    // Update is called once per frame
    void Update()
    {
        curX += Time.deltaTime * speedX;
        curY += Time.deltaTime * speedY;
        curPosition.Set(curX, curY);

        mat.SetTextureOffset("_MainTex", curPosition);
    }
}
