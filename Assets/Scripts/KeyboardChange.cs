using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class KeyboardChange : MonoBehaviour
{
    // Propiedades públicas
    [Header("Desbloqueos")]
	public bool[] unlocked; // Para detectar cuantos teclados están desbloqueados

    [Header("Teclados")]
	public GameObject[] keyboards; // Todos los teclados

    [Header("UI")]
    public GameObject[] keyPanels;    // Imagenes de los distintos teclados
    public string[] recordsLocked;    // El texto en gris (Sin desbloquar)
    public string[] recordsUnlocked;  // El texto en blanco (Bloqueado)
    public TextMeshProUGUI infotext;  // Texto con la información de puntos necesarios para desbloquear
    public Sprite[] pressedPanel;     // Variaciones del menú de skins según la tecla pulsada
    public Image skinPanel;           // Menú de skins
    public bool canChange = false;

    // Propiedades privadas
    public int unlockLvl = 1;      // Esto indica los teclados desbloqueados que tienes.
    private int keyPanCounter = 1; // Indica por cual iteración del menú de skins vamos al seleccionar
    

    // Métodos MonoBehaviour
    void Awake()
    {
        UnlocksUpdate();   // Recoge los teclados debloqueados
        KeyboardAtStart(); // Inicia con el mismo teclado que la partida anterior
        UpdateSkin();      // Actualiza el menú y el teclado seleccionado
    }

    private void Update()
    {
        if (canChange == true)
        {
            if (unlockLvl > 1)
            {
                if (Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    keyPanCounter--;
                    if (keyPanCounter == 0)
                    {
                        if (unlockLvl == 8)
                            keyPanCounter = 8;
                        else
                            keyPanCounter = unlockLvl;
                    }
                    LeftArrow();
                    UpdateSkin();
                }
                else if (Input.GetKeyDown(KeyCode.RightArrow))
                {
                    keyPanCounter++;
                    if (keyPanCounter == 9)
                        keyPanCounter = 1;
                    if (unlocked[keyPanCounter - 1] == false)
                        keyPanCounter = 1;
                    RightArrow();
                    UpdateSkin();
                }
            }         
        }
    }

    private void UnlocksUpdate()  // Recupera los teclados desbloqueados
    {
        if (!PlayerPrefs.HasKey("unlockLvl"))
        {
            PlayerPrefs.SetInt("unlockLvl", 1);
        }

        unlockLvl = PlayerPrefs.GetInt("unlockLvl");
        for (int i = 0; i <= unlockLvl - 1; i++)
        {
            unlocked[i] = true;
        }
    }

    public void Change()
    {
        if (canChange)
        {
            canChange = false;
        }
        else
        {
            canChange = true;
        }
    }

    public void KeyboardAtStart()
    {
        if (!PlayerPrefs.HasKey("currentKey"))
        {
            keyPanCounter = 1;
        }            
        else
        {
            keyPanCounter = PlayerPrefs.GetInt("currentKey");
        }
            
        UpdateSkin();
    }

    public void UnlockKeyboard(int hS)
    {
        if (hS > 99 && hS < 200)  // 99 - 200
        {
            // teclado 2 black
            unlockLvl = 2;
        }
        else if (hS >= 200 && hS < 350) // 200 - 350
        {
            // teclado 3 rubber
            unlockLvl = 3;
        } 
        else if (hS >= 350 && hS < 500) // 350 - 500
        {
            // teclado 4 apple
            unlockLvl = 4;
        }
        else if (hS >= 500 && hS < 750) // 500 - 750
        {
            // teclado 5 gaming
            unlockLvl = 5;
        }
        else if (hS >= 750 && hS < 1250) // 750 - 1250
        {
            // teclado 6 customs
            unlockLvl = 6;
        }
        else if (hS >= 1250 && hS < 3000) // 1250 - 3000
        {
            // teclado 7 gaming pro
            unlockLvl = 7;
        }
        else if (hS >= 3000)
        {
            // teclado 8 
            unlockLvl = 8;
        }
        GameObject.Find("GameOverCanvas").GetComponent<GameOver>().UnlockedKeyboard(HowManyKeyboards(unlockLvl));
        PlayerPrefs.SetInt("unlockLvl", unlockLvl);
        UnlocksUpdate();
    }

    private void DisableAllKeyboards()
    {
        for (int i = 0; i < keyboards.Length; i++)
        {
            keyboards[i].SetActive(false);
        }
    }

    private void DisableAllKeyPanels()
    {
        for (int i = 0; i < keyPanels.Length; i++)
        {
            keyPanels[i].SetActive(false);
        }
    }

    private void UpdateSkin()
    {
        DisableAllKeyboards();
        DisableAllKeyPanels();
        InfoSkins();
        switch (keyPanCounter)
        {
            case 1:
                keyPanels[0].SetActive(true);
                keyboards[0].SetActive(true);
                break;
            case 2:
                keyboards[1].SetActive(true);
                keyPanels[1].SetActive(true);
                break;
            case 3:
                keyboards[2].SetActive(true);
                keyPanels[2].SetActive(true);
                break;
            case 4:
                keyboards[3].SetActive(true);
                keyPanels[3].SetActive(true);
                break;
            case 5:
                keyboards[4].SetActive(true);
                keyPanels[4].SetActive(true);
                break;
            case 6:
                keyboards[5].SetActive(true);
                keyPanels[5].SetActive(true);
                break;
            case 7:
                keyboards[6].SetActive(true);
                keyPanels[6].SetActive(true);
                break;
            case 8:
                keyboards[7].SetActive(true);
                keyPanels[7].SetActive(true);
                break;
            default:
                break;
        }
        PlayerPrefs.SetInt("currentKey", keyPanCounter);
    }

    private int HowManyKeyboards(int uL)
    {
        int hmk = PlayerPrefs.GetInt("unlockLvl");
        hmk = uL - hmk;
        Debug.Log(hmk);
        return hmk;
    }

    private void InfoSkins()
    {
        switch (unlockLvl)
        {
            case 1:
                infotext.text = recordsUnlocked[0] + "\n" + recordsLocked[1] + "\n" + recordsLocked[2] + "\n" + recordsLocked[3] + "\n" + recordsLocked[4] + "\n" + 
                    recordsLocked[5] + "\n" + recordsLocked[6] + "\n" + recordsLocked[7];
                break;
            case 2:
                infotext.text = recordsUnlocked[0] + "\n" + recordsUnlocked[1] + "\n" + recordsLocked[2] + "\n" + recordsLocked[3] + "\n" + recordsLocked[4] + "\n" + 
                    recordsLocked[5] + "\n" + recordsLocked[6] + "\n" + recordsLocked[7];
                break;            
            case 3:
                infotext.text = recordsUnlocked[0] + "\n" + recordsUnlocked[1] + "\n" + recordsUnlocked[2] + "\n" + recordsLocked[3] + "\n" + recordsLocked[4] + "\n" + 
                    recordsLocked[5] + "\n" + recordsLocked[6] + "\n" + recordsLocked[7];
                break;            
            case 4:
                infotext.text = recordsUnlocked[0] + "\n" + recordsUnlocked[1] + "\n" + recordsUnlocked[2] + "\n" + recordsUnlocked[3] + "\n" + recordsLocked[4] + "\n" + 
                    recordsLocked[5] + "\n" + recordsLocked[6] + "\n" + recordsLocked[7];
                break;            
            case 5:
                infotext.text = recordsUnlocked[0] + "\n" + recordsUnlocked[1] + "\n" + recordsUnlocked[2] + "\n" + recordsUnlocked[3] + "\n" + recordsUnlocked[4] + "\n" + 
                    recordsLocked[5] + "\n" + recordsLocked[6] + "\n" + recordsLocked[7];
                break;            
            case 6:
                infotext.text = recordsUnlocked[0] + "\n" + recordsUnlocked[1] + "\n" + recordsUnlocked[2] + "\n" + recordsUnlocked[3] + "\n" + recordsUnlocked[4] + "\n" + 
                    recordsUnlocked[5] + "\n" + recordsLocked[6] + "\n" + recordsLocked[7];
                break;            
            case 7:
                infotext.text = recordsUnlocked[0] + "\n" + recordsUnlocked[1] + "\n" + recordsUnlocked[2] + "\n" + recordsUnlocked[3] + "\n" + recordsUnlocked[4] + "\n" + 
                    recordsUnlocked[5] + "\n" + recordsUnlocked[6] + "\n" + recordsLocked[7];
                break;            
            case 8:
                infotext.text = recordsUnlocked[0] + "\n" + recordsUnlocked[1] + "\n" + recordsUnlocked[2] + "\n" + recordsUnlocked[3] + "\n" + recordsUnlocked[4] + "\n" + 
                    recordsUnlocked[5] + "\n" + recordsUnlocked[6] + "\n" + recordsUnlocked[7];
                break;
            default:
                break;
        }
    }

    private void LeftArrow() // Hace que en el menú esté pulsada la tecla izquierda 0.3 segundos
    {
        skinPanel.sprite = pressedPanel[1];
        Invoke("Restore", 0.3f);
    }

    private void RightArrow() // Hace lo propio con la derecha
    {
        skinPanel.sprite = pressedPanel[2];
        Invoke("Restore", 0.3f);
    }

    private void Restore()
    {
        skinPanel.sprite = pressedPanel[0];
    }
}