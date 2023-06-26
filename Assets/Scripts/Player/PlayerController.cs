using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour {
	// Propiedades públicas
    [Header("Sonidos")]
	public AudioSource jumpSound;
	public AudioSource trashSound;
	public AudioSource storeSound;

    [Header("GameObjects")]
	public GameObject mesh;        // Bicho en 3D
	public GameObject deadSprite;  // Bicho aplastado en 2D
	public GameObject particle;   

    [Header("UnityEvents")]
    public UnityEvent gameOver;           // Invoca comandos relacionados con la muerte del jugador
    public UnityEvent temporalPoints;   // Suma puntos temporales
    public UnityEvent points;           // Suma puntos totales
	public UnityEvent continueTutorial;

	[Header("Referencias")]
	public FingerEvent fingerEvent;     // Referencia al script de los dedos para poder bajar la velocidad
	public DetectDeathKey dK;
	public int lastPosition;

    // Propiedades privadas
    private Animator anim;   // Animador del personaje
	private TutorialDisplay tD;
	
    // Métodos MonoBehaviour
	private void Start() {
		anim = GetComponent<Animator>();                     // Recupera el componente del animador
		transform.position = KeyboardPosition.positions[36]; // Deja inicialmente el ácaro en el CTRL
		mesh.SetActive(true);                                // Deja el bicho en 3D activo
		deadSprite.SetActive(false);                         // Deja el bicho en 2D invisible
		tD = GameObject.Find("TutorialDisplay").GetComponent<TutorialDisplay>();
	}

	void Update() 
	{
		if(SceneController.started == true) 
		{
			StartCoroutine(MiteMovement(0.4f));  // El bicho puede moverse siempre y cuando el juego haya empezado
		}
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Finger")) // Si el personaje colisiona con un dedo,
        {
            gameOver.Invoke(); // Activa todos los comandos de la muerte en SceneController
        }
        else if (other.CompareTag("Trash")) // Si el personaje colisiona con una trash
        {
            Destroy(other.gameObject);             // Destruye la trash
            SceneController.isThereTrash = false;  // Indica que no hay trash en el teclado
            trashSound.Play();                     // Sonido de recogida
            temporalPoints.Invoke();               // Suma puntos temporales
        }
    }

    // Métodos públicos
    public void SpriteDead() // Activado cuando el jugador muere
    {
        mesh.SetActive(false);       // Desactiva el modelo 3D
        deadSprite.SetActive(true);  // Activa el bicho apalstado en 2D
		particle.SetActive(true);
		dK.DeadSprite(lastPosition);
    }

    public void JumpSound() // Llamado desde animación cuando el bicho salta
    {
        jumpSound.Play();   // Hace sonar el salto
    }

	public void AnimMultiplayer()
	{
		anim.SetTrigger("multi");
	}

	// Corutinas

	#region Movimiento

	private IEnumerator MiteMovement_01(int position, float seconds) 
	{
		if (SceneController.tutorialfase1)
		{
			if (position == 25)
			{
                anim.SetTrigger("Jump");
                yield return new WaitForSeconds(seconds);
                transform.position = KeyboardPosition.positions[position];
				SceneController.tutorialfase1 = false;
				SceneController.tutorialfase2 = true;
				tD.DisplayFase1(2);
            }
        }
		else if (SceneController.tutorialfase2)
        {
            if (position == 18)
            {
                anim.SetTrigger("Jump");
                yield return new WaitForSeconds(seconds);
                transform.position = KeyboardPosition.positions[position];
                SceneController.tutorialfase2 = false;
                SceneController.tutorialfase3 = true;
                tD.DisplayFase1(3);
            }
        }
        else if (SceneController.tutorialfase3)
        {
            if (position == 35)
            {
                anim.SetTrigger("Jump");
                yield return new WaitForSeconds(seconds);
                transform.position = KeyboardPosition.positions[position];
                SceneController.tutorialfase3 = false;
                SceneController.tutorialfase4 = true;
                tD.DisplayFase1(4);
            }
        }        
		else if (SceneController.tutorialfase4)
        {
            if (position == 12)
            {
                anim.SetTrigger("Jump");
                yield return new WaitForSeconds(seconds);
                transform.position = KeyboardPosition.positions[position];
                SceneController.tutorialfase4 = false;
				continueTutorial.Invoke();
				tD.ClearDisplays();
            }
        }
        else
		{
            anim.SetTrigger("Jump");
            yield return new WaitForSeconds(seconds);
            transform.position = KeyboardPosition.positions[position];
            if (SceneController.pause == true && (!SceneController.canTutorial))
                SceneController.PlayOrPauseFingers();
        }

		lastPosition = position;
    }

	private IEnumerator MiteMovement(float seconds) { //Escoge la posición a la que mover el bicho basándose en la entrada por teclado. Espera x segundos

		if(Input.GetKeyDown(KeyCode.Alpha1))
			yield return MiteMovement_01(0, seconds);
	    else if(Input.GetKeyDown(KeyCode.Alpha2))
			yield return MiteMovement_01(1, seconds);
		 else if(Input.GetKeyDown(KeyCode.Alpha3))
			yield return MiteMovement_01(2, seconds);
		 else if(Input.GetKeyDown(KeyCode.Alpha4)) 
			yield return MiteMovement_01(3, seconds);
		 else if(Input.GetKeyDown(KeyCode.Alpha5)) 
			yield return MiteMovement_01(4, seconds);
		 else if(Input.GetKeyDown(KeyCode.Alpha6)) 
			yield return MiteMovement_01(5, seconds);
		 else if(Input.GetKeyDown(KeyCode.Alpha7)) 
			yield return MiteMovement_01(6, seconds);
		 else if(Input.GetKeyDown(KeyCode.Alpha8)) 
			yield return MiteMovement_01(7, seconds);
		 else if(Input.GetKeyDown(KeyCode.Alpha9)) 
			yield return MiteMovement_01(8, seconds);
		 else if(Input.GetKeyDown(KeyCode.Alpha0)) 
			yield return MiteMovement_01(9, seconds);
		 else if(Input.GetKeyDown(KeyCode.Q)) 
			yield return MiteMovement_01(10, seconds);
		 else if(Input.GetKeyDown(KeyCode.W)) 
			yield return MiteMovement_01(11, seconds);
		 else if(Input.GetKeyDown(KeyCode.E)) 
			yield return MiteMovement_01(12, seconds);
		 else if(Input.GetKeyDown(KeyCode.R)) 
			yield return MiteMovement_01(13, seconds);
		 else if(Input.GetKeyDown(KeyCode.T)) 
			yield return MiteMovement_01(14, seconds);
		 else if(Input.GetKeyDown(KeyCode.Y)) 
			yield return MiteMovement_01(15, seconds);
		 else if(Input.GetKeyDown(KeyCode.U)) 
			yield return MiteMovement_01(16, seconds);
		 else if(Input.GetKeyDown(KeyCode.I)) 
			yield return MiteMovement_01(17, seconds);
		 else if(Input.GetKeyDown(KeyCode.O)) 
			yield return MiteMovement_01(18, seconds);
		 else if(Input.GetKeyDown(KeyCode.P))
			yield return MiteMovement_01(19, seconds);
		 else if(Input.GetKeyDown(KeyCode.A))
			yield return MiteMovement_01(20, seconds);
		 else if(Input.GetKeyDown(KeyCode.S))
			yield return MiteMovement_01(21, seconds);
		 else if(Input.GetKeyDown(KeyCode.D))
			yield return MiteMovement_01(22, seconds);
		 else if(Input.GetKeyDown(KeyCode.F))
			yield return MiteMovement_01(23, seconds);
		 else if(Input.GetKeyDown(KeyCode.G))
			yield return MiteMovement_01(24, seconds);
		 else if(Input.GetKeyDown(KeyCode.H))
			yield return MiteMovement_01(25, seconds);
		 else if(Input.GetKeyDown(KeyCode.J))
			yield return MiteMovement_01(26, seconds);
		 else if(Input.GetKeyDown(KeyCode.K))
			yield return MiteMovement_01(27, seconds);
		 else if(Input.GetKeyDown(KeyCode.L))
			yield return MiteMovement_01(28, seconds);
		 else if(Input.GetKeyDown(KeyCode.Z))
			yield return MiteMovement_01(29, seconds);
		 else if(Input.GetKeyDown(KeyCode.X))
			yield return MiteMovement_01(30, seconds);
		 else if(Input.GetKeyDown(KeyCode.C))
			yield return MiteMovement_01(31, seconds);
		 else if(Input.GetKeyDown(KeyCode.V))
			yield return MiteMovement_01(32, seconds);
		 else if(Input.GetKeyDown(KeyCode.B))
			yield return MiteMovement_01(33, seconds);
		 else if(Input.GetKeyDown(KeyCode.N))
			yield return MiteMovement_01(34, seconds);
		 else if(Input.GetKeyDown(KeyCode.M))
			yield return MiteMovement_01(35, seconds);
		 else if(Input.GetKeyDown(KeyCode.LeftControl)) // En el CTRL, además guarda las puntuaciones
         { 
				storeSound.Play();
				anim.SetTrigger("Jump");
				yield return new WaitForSeconds(seconds);
				transform.position = KeyboardPosition.positions[36];
				points.Invoke();
				fingerEvent.MoreSeconds();	//Baja la velocidad de los dedos
				if(SceneController.pause == false) 
					SceneController.PlayOrPauseFingers();
		 }
	}
    #endregion
}