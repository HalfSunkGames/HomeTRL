using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class IntroManager : MonoBehaviour
{

    [SerializeField] private VideoPlayer intro;
    [SerializeField] private AudioSource introAudio;


    void Start()  // Start is called before the first frame update
    {
        intro.Play();
        Invoke("IntroSound", 1f);
        Invoke("StartGame", 7f);
    }

    private void IntroSound()
    {
        introAudio.Play();
    }

    private void StartGame()
    {
        SceneManager.LoadScene(1);
    }
}