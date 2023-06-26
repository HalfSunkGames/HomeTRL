using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class SceneController : MonoBehaviour {

    // Propiedades públicas

    [Header("Canvas")]
	public GameObject gameOverCanvas; // Canvas del monitor
	public GameObject startCanvas;    // Panel del menú inicial
	public GameObject inGameCanvas;   // UI del juego
	public GameObject pauseCanvas;    // Panel de pausa
    public GameObject skinCanvas;      // Panel de cambios de skin
	public GameObject eraseCanvas;
	public GameObject eraseConfirmCanvas;

    [Header("Sonidos")]
	public AudioSource music;      // BGM
	public AudioSource deadSound;  // Sonido de bicho aplastado

    [Header("Cámaras")]
    public new Camera camera;      // Cámara de juego

    public static bool pause = true;          // Detecta si estás en el control
    public static bool pauseEsc = false;      // Detecta si tienes el juego pausado desde ESC
    public static bool musicStopped = false;  // Detecta si la música está parada
    public static bool isThereTrash = false;  // Detecta si hay trash en el teclado
    public static bool started = false;       // Detecta si el juego ha empezado o no
    public static bool canTutorial = false;      // Bloqueador de poder abrir el tutorial o no
	public static bool tutorialCanEnd = false;

	public static bool tutorialfase1 = false;
	public static bool tutorialfase2 = false;
	public static bool tutorialfase3 = false;
	public static bool tutorialfase4 = false;

	public GameObject light;

    [Header("Unity Events")]
	public LightAudio audioLightManager; // Para cambiar las luces según el volumen
	public UnityEvent savePoints;        // Para guardar el highscore
    public UnityEvent activeSprite;      // Para matar al jugador
    public UnityEvent canChangeSkin;
	public UnityEvent spacePressed;
	public UnityEvent controlPressed;
	public UnityEvent escPressed;

    // Propiedades privadas
    private bool canRestart = false;      // Bloqueador de poder reiniciar o no
    private bool skinActive = false;       
    private bool canSkin = true;          // Bloqueador de poder abrir las skins o no
	[SerializeField]private bool eraseOpen = false;
	[SerializeField]private bool eraseConfirm = false;
	private bool canErase = true;
    private Animator camAnim;             // Animador de la cámara

	private static int m_currentVolume = 4;
	private readonly float[] musicVolumes = new float[] { 0.8f, 0.6f, 0.3f, 0.15f, 0f }; // Volumenes de la música
	private Animator menu;
	private TutorialDisplay tD;
    private Animator lightAnim;
	private bool isDead = false;

    // Métedos MonoBehaviour
    private void Start() {
		camera.depth = 0;                            // Deja activada la cámara principal
		gameOverCanvas.SetActive(false);             // Deja desactivados todos los canvas menos el del menú
		inGameCanvas.SetActive(false);
		pauseCanvas.SetActive(false);
		eraseCanvas.SetActive(false);

		camAnim = camera.GetComponent<Animator>();   // Recupera el componente del animator
		//Cursor.visible = false;                      // Quita el cursor. DEVOLVER EN LAS OPCIONES
		UpdateMusicVolume();                         // Actualiza el volumen respecto a la partida anterior
        pause = true;
        started = false;
		TutorialFirstTime();   // ESTE METODO ESTARÁ QUITADO PARA LA VERSIÓN DE LA INDIE DEV DAY, PARA TENER SIEMPRE EL TUTORIAL (ALTERNATIVA PARA SALTARSELO RÁPIDO)

		menu = GameObject.Find("MENU").GetComponent<Animator>();
		tD = GameObject.Find("TutorialDisplay").GetComponent<TutorialDisplay>();
		lightAnim = light.GetComponent<Animator>();
	}

	private void TutorialFirstTime()
	{
		if (!PlayerPrefs.HasKey("tutorialDone"))
		{
			canTutorial = true;
			tutorialfase1 = true;
            PlayerPrefs.SetInt("tutorialDone", 0);
        }
		else
		{
			tutorialfase1 = false;
			tutorialfase2 = false;
			tutorialfase3 = false;
			tutorialfase4 = false;
			canTutorial = false;
			tutorialfase1 = false;
		}
    }

	private void ControlPress() // Se ejecuta al pulsar CTRL
	{
        if (!isDead)
		{
            if (canRestart) // Si está el Game Over, reinicia el juego
                Restart();

            if (!started && !skinActive && !eraseOpen) // Si se puede empezar el juego lo empieza
            {
                StartGame();
                controlPressed.Invoke();
            }

            if (tutorialCanEnd)
            {
                canTutorial = false;
                PlayOrPauseFingers();
                tutorialCanEnd = false;
            }

            if (eraseOpen && !eraseConfirm)
            {
                Invoke("EraseConfirm", 0.1f);
            }

            if (eraseConfirm)
            {
                EraseData();
            }
        }
	}
	private void PauseUpdate() // Cuando se pausa el juego en el ESC
	{
		Time.timeScale = pauseEsc ? 0 : 1;
		pauseCanvas.SetActive(pauseEsc);
	}

	private void SkinUpdate() // REVISAR
	{
		startCanvas.SetActive(!skinActive);
		skinCanvas.SetActive(skinActive);
		canChangeSkin.Invoke();
	}

	private void Update() 
	{
		if (Input.GetKeyDown(KeyCode.F1))
			EraseMenu();

		if(Input.GetKeyDown(KeyCode.LeftControl))
            ControlPress();

		if (Input.GetKeyDown(KeyCode.Escape))
			EscapePressed();

		if(Input.GetKeyDown(KeyCode.Space)) 
			SpacePressed();

		if (Input.GetKeyDown(KeyCode.LeftShift))
			ShiftPressed();
	}

	private void ShiftPressed()
	{
        if (!started && canSkin && !eraseOpen)
        {
            skinActive = !skinActive;
            SkinUpdate();
        }

        if (eraseOpen)
        {
            RestartTutorial();
        }
    }

	private void EscapePressed()
	{
        if (!started && !skinActive)
        {
            escPressed.Invoke();
            Application.Quit();
        }
        else if (!started && skinActive)
        {
            skinActive = !skinActive;
            SkinUpdate();
        }
        else
        {
            pauseEsc = !pauseEsc;
            PauseUpdate();
        }
        if (eraseConfirm)
            EraseConfirm();
		if (eraseOpen)
			EraseMenu();

    }

	private void SpacePressed()
	{
        if (!started)
        {
            spacePressed.Invoke();
        }
        m_currentVolume--;
        if (m_currentVolume == 0)
            m_currentVolume = musicVolumes.Length;
        UpdateMusicVolume();
    }

	// Métodos públicos
	public static void PlayOrPauseFingers() // Para o reactiva el juego
	{
		if(pause == false)
			pause = true;
		else
			pause = false;
	}

	public static void Restart() // Resetea la escena
    {
        pause = true; 
        isThereTrash = false; 
        started = false; 
        SceneManager.LoadScene("GameScene");
    }

    public void GameOver() // Muerte del jugador, fin del juego
    {
		isDead = true;
		CancelInvoke();                    // Elimina los dedos que están por venir
        DestroyAllFingers();               // Elimina los juegos ya aparecidos
        PlayOrPauseFingers();              // Dejan de salir más dedos
        started = false;                   
        deadSound.Play();                  // Sonido del bicho aplastado        
        gameOverCanvas.SetActive(true);    // Activa HUD del final
        inGameCanvas.SetActive(false);     // Desactiva el HUD del juego
        music.Stop();                      // Para la música
        activeSprite.Invoke();             // Aparece el bicho chafado
        camera.depth = -2;                 // Cambia las cámara a la cámara del Game Over
        savePoints.Invoke();               // Guarda el Score
        Invoke("EndDelay", 4f);            // Delay de 4 segundos antes de poder reiniciar
    }

    public void StartGame() // Inicia el juego
    {
        canSkin = false;                  // Bloquea abrir el menú de Skins
		canErase = false;
        camAnim.SetTrigger("start");      // Mueve la cámara al juego
		menu.SetTrigger("start");         //Quita el menú
		lightAnim.SetTrigger("start");
		Invoke("UnableMenuByAnim", 1.1f);
        Invoke("StartDelay", 2.8f);       // Empieza el juego tras un delay
    }

	public void UnableMenuByAnim()
	{
        startCanvas.SetActive(false);  // Desactiva el HUD del menú
    }

	public void Xibalboys() // Abre la Web del Equipo
	{
		Application.OpenURL("https://halfsunkgames.itch.io");
	}

	// Métodos privados
	private void UpdateMusicVolume() // Actualiza el volumen (Actualmente desde el Espacio, puede cambiar)
	{
		music.volume = musicVolumes[m_currentVolume - 1];
		audioLightManager.ChangeAudioLights(musicVolumes.Length - m_currentVolume);
	}

	void DestroyAllFingers() // Elimina los dedos ya aparecidos al final de la partida
	{
		foreach(GameObject finger in GameObject.FindGameObjectsWithTag("Finger")) 
			Destroy(finger);
	}

	void StartDelay() // Retraso del inicio del juego (Invoke)
	{
		inGameCanvas.SetActive(true);
		started = true;

		if (tutorialfase1)
			tD.DisplayFase1(1);
	}

	void EndDelay() // Retraso del poder reiniciar tras el Game Over (Invoke)
	{
		canRestart = true;
		isDead = false;
	}

	void EraseMenu()
	{
		if (!started && !skinActive && !eraseOpen && canErase)
		{
			eraseOpen = true;
            startCanvas.SetActive(!eraseOpen);
            eraseCanvas.SetActive(true);
        }
		else if (eraseOpen)
		{
            startCanvas.SetActive(eraseOpen);
			eraseCanvas.SetActive(false);
			eraseOpen = false;
        }
	}

	void EraseConfirm()
	{
        eraseCanvas.SetActive(!eraseCanvas.activeInHierarchy);
        eraseConfirmCanvas.SetActive(!eraseConfirmCanvas.activeInHierarchy);
        eraseConfirm = !eraseConfirm;
    }

	void EraseData()
	{
		PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("GameScene");
    }

	void RestartTutorial()
	{
		PlayerPrefs.DeleteKey("tutorialDone");
        SceneManager.LoadScene("GameScene");
    }
}