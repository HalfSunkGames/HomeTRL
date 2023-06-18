using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialDisplay : MonoBehaviour
{
    public List<GameObject> fases;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 6; i++)
        {
            fases.Add(gameObject.transform.GetChild(i).gameObject);
        }
    }

    public void DisplayFase1(int stage)
    {
        fases[0].SetActive(true);
        switch (stage)
        {
            case 1:
                fases[0].GetComponent<RectTransform>().anchoredPosition = new Vector2(-48f, 11f);
                break;
            case 2:
                fases[0].GetComponent<RectTransform>().anchoredPosition = new Vector3(61f, 50f);
                break;
            case 3:
                fases[0].GetComponent<RectTransform>().anchoredPosition = new Vector3(4.1f, -28.2f);
                break;
            case 4:
                fases[0].GetComponent<RectTransform>().anchoredPosition = new Vector3(-193.8f, 58f);
                break;
            default:
                break;
        }
        
    }

    public void DisplayFase2()
    {
        fases[0].SetActive(false);
        fases[1].SetActive(true);
        Invoke("ClearDisplays", 4f);
    }

    public void DisplayFase3()
    {
        fases[2].SetActive(true);
    }

    public void DisplayFase4()
    {
        fases[3].SetActive(true);
        Invoke("DisplayFase5", 5f);
    }

    public void DisplayFase5()
    {
        fases[3].SetActive(false);
        fases[4].SetActive(true);
        Invoke("DisplayFase6", 4f);
    }    
    public void DisplayFase6()
    {
        fases[4].SetActive(false);
        fases[5].SetActive(true);
        Invoke("ClearDisplays", 5f);
        SceneController.canTutorial = false;
        SceneController.tutorialCanEnd = false;
        SceneController.isThereTrash = false;
    }
    
    public void ClearDisplays()
    {
        for (int i = 0; i < fases.Count; i++)
        {
            fases[i].SetActive(false);
        }
    }    
    
    public void ClearDisplaysDelay()
    {
        Invoke("ClearDisplays", 3f);
    }
}
