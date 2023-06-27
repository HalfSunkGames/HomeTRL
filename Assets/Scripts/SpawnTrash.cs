using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTrash : MonoBehaviour {
    // Propiedades públicas
	public GameObject[] trashes;                    // Array pública donde meter variantes de trash
	public int[] tutorialPosition;                  // Teclas donde aparecerán las trashes del tutorial
    public TutorialDisplay tD;
    [SerializeField] private int currentOrder = 0;  // Pasos del tutorial

	// Propiedades privadas
	

    // Métodos públicos
    public void ContinueTutorial() // Empieza a aparecer la trash
    {
        Invoke("DelayTutorialPanel", 3f);
        StartCoroutine(TutorialTrash());
    }

    // Métodos privados
    private void Start() 
	{
		StartCoroutine(SpawnChip()); // Inicia el bucle
	}

	IEnumerator SpawnChip() {
		yield return new WaitForSeconds(3f);                                            // Cada tres segundos
		
		if(SceneController.pause == false && SceneController.isThereTrash == false) {   // Si no está en pausa y no hay ya una trash...
			int randomPosition = Random.Range(0, 36);                                   // Elige una posición del teclado
			int randomTrash = Random.Range(0, trashes.Length);                          // Elige una trash

			Instantiate(trashes[randomTrash], KeyboardPosition.positions[randomPosition], Quaternion.identity).tag = "Trash"; // Y la hace aparecer

			SceneController.isThereTrash = true; // Detecta que hay una trash en pantalla (para el bucle enumerator)
		}
        StartCoroutine(SpawnChip()); // Se llama a sí mismo
	}

	public IEnumerator TutorialTrash()
	{
        yield return new WaitForSeconds(3f);                                            // Cada tres segundos
        if (SceneController.isThereTrash == false)
        {
            
            int randomTrash = Random.Range(0, trashes.Length);                          // Elige una trash

			if (currentOrder < 7)
			{
                Instantiate(trashes[randomTrash], KeyboardPosition.positions[tutorialPosition[currentOrder]], Quaternion.identity).tag = "Trash"; // Y la hace aparecer
            }
			currentOrder++;

            SceneController.isThereTrash = true; // Detecta que hay una trash en pantalla (para el bucle enumerator)
        }
		if (currentOrder < 8)
		{
            StartCoroutine(TutorialTrash()); // Se llama a sí mismo
        }
			
		if (currentOrder == 2)
			tD.ClearDisplays();
		if (currentOrder == 5)
			tD.DisplayFase3();
		if (currentOrder == 7)
			tD.ClearDisplays();
		if (currentOrder == 8)
			tD.DisplayFase4();
		else if (currentOrder >= 8)
		{
            SceneController.tutorialCanEnd = true;
			SceneController.isThereTrash = false;
        }
			
    }

	private void DelayTutorialPanel()
	{
        tD.DisplayFase2();
    }
}