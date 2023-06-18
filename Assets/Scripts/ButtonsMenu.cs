using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonsMenu : MonoBehaviour
{
    [Header("Sprites")]
    public Sprite ctrl;
    public Sprite ctrlPress;
    public Sprite shift;
    public Sprite shiftPress;
    public Sprite esc;
    public Sprite escPress;
    public Sprite space;
    public Sprite spacePress;

    [Header("Canvas")]
    public GameObject start;
    public GameObject skins;
    public GameObject exit;
    public GameObject volume;

    public void PressCtrl()
    {
        start.GetComponent<Image>().sprite = ctrlPress;
        Invoke("UnpressCtrl", 0.3f);
    }

    private void UnpressCtrl()
    {
        start.GetComponent<Image>().sprite = ctrl;
    }    
    public void PressShift()
    {
        skins.GetComponent<Image>().sprite = shiftPress;
        Invoke("UnpressShift", 0.3f);
    }

    private void UnpressShift()
    {
        skins.GetComponent<Image>().sprite = shift;
    }    
    
    public void PressEsc()
    {
        exit.GetComponent<Image>().sprite = escPress;
        Invoke("UnpressEsc", 0.3f);
    }

    private void UnpressEsc()
    {
        exit.GetComponent<Image>().sprite = esc;
    }    
    
    public void PressSpace()
    {
        volume.GetComponent<Image>().sprite = spacePress;
        Invoke("UnpressSpace", 0.3f);
    }

    private void UnpressSpace()
    {
        volume.GetComponent<Image>().sprite = space;
    }
}
