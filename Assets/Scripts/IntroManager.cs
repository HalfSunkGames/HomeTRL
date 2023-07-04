using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class IntroManager : MonoBehaviour
{
    // Métodos privados
    [SerializeField] private VideoPlayer intro;      // Video de intro
    [SerializeField] private AudioSource introAudio; // Sonido de intro


    void Start()  // Start is called before the first frame update
    {
        intro.Play();             // Reproduce el video
        Invoke("StartGame", 8.5f);  // Inicia el juego al terminar
    }

    private void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            StartGame();
    }
}