using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shake : MonoBehaviour
{
    public float shakeValue = 0;
    private RectTransform rT;
    public Vector2 originalPosition;
    public Vector2 newPos;
    // Start is called before the first frame update
    void Start()
    {
        rT = GetComponent<RectTransform>();
        originalPosition = rT.anchoredPosition;
    }

    // Update is called once per frame
    void Update()
    {    
        newPos.x = Random.Range(originalPosition.x - 1 * shakeValue, originalPosition.x + 2 * shakeValue);        
        newPos.y = Random.Range(originalPosition.y - 1 * shakeValue, originalPosition.y + 2 * shakeValue);
        rT.anchoredPosition = newPos;
    }

    public void ShakeInput(float input)
    {
        shakeValue = input;
    }
}
