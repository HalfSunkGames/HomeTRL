using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class KeyboardChange : MonoBehaviour
{
    [Header("Desbloqueos")]
	public bool[] unlocked;

	public GameObject[] keyboards;

    [Header("UI")]
    public GameObject[] keyPanels;
    public string[] recordsLocked;
    public string[] recordsUnlocked;
    public TextMeshProUGUI infotext;
    public Sprite[] pressedPanel;
    public Image skinPanel;
    public bool canChange = false;

    // Propiedades privadas
    public int unlockLvl = 1; // Esto indica los teclados desbloqueados que tienes.

    [SerializeField]private int keyPanCounter = 1;
    

    // Métodos MonoBehaviour
    void Awake()
    {
        UnlocksUpdate();
        KeyboardAtStart();
        UpdateSkin();
    }

    void UnlocksUpdate()
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
        if (hS > 99 && hS < 200)  // Se desbloquea con 75
        {
            // teclado 2 black
            unlockLvl = 2;
        }
        else if (hS >= 200 && hS < 350)
        {
            // teclado 3 rubber
            unlockLvl = 3;
        }
        else if (hS >= 350 && hS < 500)
        {
            // teclado 4 apple
            unlockLvl = 4;
        }
        else if (hS >= 500 && hS < 750)
        {
            // teclado 5 gaming
            unlockLvl = 5;
        }
        else if (hS >= 750 && hS < 1250)
        {
            // teclado 6 customs
            unlockLvl = 6;
        }
        else if (hS >= 1250 && hS < 3000)
        {
            // teclado 7 gaming pro
            unlockLvl = 7;
        }
        else if (hS >= 1500)
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

    void LeftArrow()
    {
        skinPanel.sprite = pressedPanel[1];
        Invoke("Restore", 0.3f);
    }

    void RightArrow()
    {
        skinPanel.sprite = pressedPanel[2];
        Invoke("Restore", 0.3f);
    }

    void Restore()
    {
        skinPanel.sprite = pressedPanel[0];
    }
}