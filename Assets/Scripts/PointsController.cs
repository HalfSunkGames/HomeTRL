using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PointsController : MonoBehaviour
{
    // Propiedades públicas
    [Header("UI Texts")]        // Los textos del UI
    public TextMeshProUGUI tempPointsTxt;
    public TextMeshProUGUI pointsTxt;
    public Text highScoreTxt;

    [Header("Multiplier")]
    public Sprite[] multiplierSprites;
    public GameObject multiplierDisplay;
    public GameObject p_multiplierDisplay;
    public Shake shake;
    public UnityEvent animPMulti;
    public float[] shakeForce;

    public GameObject dorito;
    // Propiedes privadas
    [HideInInspector]public static int points = 0;     // Puntos totales del jugador (Stored)
    private int temporalPoints = 0;   // Puntos temporales que lleva el jugador encima (Carrying)
    private int multiplier = 1;       // Multiplicador de puntos
    public int highScore = 1000;     // Puntuación máxima obtenida
    private int newScore;             // Variable para guardar la puntuación obtenida en cada partida para guardar 
    private Animator doritoAnim;
    private Animator multiplierDisplayAnim;
    private Animator p_multiplierDisplayAnim;
    private bool canShowAnimation = false;
	
    // Métodos MonoBehaviour
    private void Start()
    {
        highScore = (PlayerPrefs.GetInt("highscore") == 0f) ? int.MinValue : PlayerPrefs.GetInt("highscore");
        doritoAnim = dorito.GetComponent<Animator>();
        multiplierDisplayAnim = multiplierDisplay.GetComponent<Animator>();
        p_multiplierDisplayAnim = p_multiplierDisplay.GetComponent<Animator>();
    }

    // Métodos públicos
    public void SavePoints() // Método llamado desde UnityEvent al morir, para guaradr el highscore
    {
        newScore = points;    // Guarda en variable newScore la puntuación del SceneController

        if (newScore > highScore)   // Si se ha llegado al final antes que el record actual...
        {
            highScore = newScore;                               // La puntuación actual se guarda en la máxima posición
            PlayerPrefs.SetInt("highscore", highScore);         // Guarda el highScore en datos
            PlayerPrefs.Save();                                 // Guarda los datos nuevos
            GameObject.Find("KeyboardController").GetComponent<KeyboardChange>().UnlockKeyboard(highScore); // Desbloquea posibles teclados
        }

        highScoreTxt.text = highScore.ToString();  // Lo muestra en pantalla
    }

    // Métodos privados

    private void AddPoints() // Método para sumar puntos guardados en el CTRL
    {
        if (temporalPoints != 0)
            doritoAnim.SetTrigger("points");// Muestra la animación del dorito
        points += temporalPoints; // Guarda en los puntos totales los puntos temporales iguales
        multiplier = 1;           // Resetea el multiplicador
        temporalPoints = 0;       // Resetea los puntos temporales
        multiplierDisplay.GetComponent<Image>().sprite = null; // Limpia el multiplier
        multiplierDisplay.GetComponent<Image>().color = Color.clear;
        p_multiplierDisplay.GetComponent <Image>().color = Color.clear;
        UpdateHUD();              // Muestra por pantalla
    }

    private void AddTemporalPoints() // Método para sumar puntos temporales
    {
        temporalPoints += 1*multiplier; // Los puntos puntuan el multiplicador actual

        if(temporalPoints % 5 == 0)     // Cada cinco puntos recogidos...
        {
            multiplier *= 2;            // El multiplicador se duplica (x2, x4, x8, x16, x32...)
            canShowAnimation = true;    // Para mostrar solo una vez la animación de un nuevo multiplicador
        }
        
        UpdateHUD();  // Muestra por pantalla
    }

    private void UpdateHUD() // Método para mostrar por pantalla los cambios
    {
        tempPointsTxt.text = temporalPoints.ToString();         // Muestra por pantalla los puntos temporales
        pointsTxt.text = points.ToString();                     // Muestra por pantalla los puntos totales
        if (multiplier > 1)                                     // Si el multiplicador no es un (Solo sale a partir del x2)
        {
            int multIndex = 0;
            switch (multiplier)
            {
                case 2:
                    multIndex = 0;
                    shake.ShakeInput(shakeForce[1]);
                    break;
                case 4:
                    multIndex = 1;
                    shake.ShakeInput(shakeForce[2]);
                    break;                
                case 8:
                    multIndex = 2;
                    shake.ShakeInput(shakeForce[3]);
                    break;                
                case 16:
                    multIndex = 3;
                    shake.ShakeInput(shakeForce[4]);
                    break;                
                case 32:
                    multIndex = 4;
                    shake.ShakeInput(shakeForce[5]);
                    break;                
                case 64:
                    multIndex = 5;
                    shake.ShakeInput(shakeForce[6]);
                    break;
                default:
                    multIndex = 5;
                    shake.ShakeInput(shakeForce[6]);
                    break;
            }
            p_multiplierDisplay.GetComponent<Image>().sprite = multiplierSprites[multIndex];
            p_multiplierDisplay.GetComponent<Image>().color = Color.white;
            if (canShowAnimation)
            {
                animPMulti.Invoke();
                canShowAnimation = false;
            }   

            multiplierDisplay.GetComponent<Image>().sprite = multiplierSprites[multIndex];
            multiplierDisplay.GetComponent<Image>().color = Color.white;
        }   
        else
            shake.ShakeInput(shakeForce[0]);

    }
}