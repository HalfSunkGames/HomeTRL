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
    public Image start;
    public Image skins;
    public Image exit;
    public Image volume;

    public void PressCtrl()
    {
        start.sprite = ctrlPress;
        Invoke("UnpressCtrl", 0.3f);
    }

    private void UnpressCtrl()
    {
        start.sprite = ctrl;
    }    
    public void PressShift()
    {
        skins.sprite = shiftPress;
        Invoke("UnpressShift", 0.3f);
    }

    private void UnpressShift()
    {
        skins.sprite = shift;
    }    
    
    public void PressEsc()
    {
        exit.sprite = escPress;
        Invoke("UnpressEsc", 0.3f);
    }

    private void UnpressEsc()
    {
        exit.sprite = esc;
    }    
    
    public void PressSpace()
    {
        volume.sprite = spacePress;
        Invoke("UnpressSpace", 0.3f);
    }

    private void UnpressSpace()
    {
        volume.sprite = space;
    }
}