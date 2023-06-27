using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonsMenu : MonoBehaviour
{
    // Variables públicas
    [Header("Sprites")] // Imagenes a sustituir
    public Sprite ctrl;
    public Sprite ctrlPress;
    public Sprite shift;
    public Sprite shiftPress;
    public Sprite esc;
    public Sprite escPress;
    public Sprite space;
    public Sprite spacePress;

    [Header("Canvas")] // Componente a cambiar
    public Image start;
    public Image skins;
    public Image exit;
    public Image volume;

    // Métodos públicos
    public void PressCtrl() // Al pulsar el Control
    {
        start.sprite = ctrlPress; // Cambia el sprite
        Invoke("UnpressCtrl", 0.3f);
    }

   
    public void PressShift() // Al pulsar el Shift
    {
        skins.sprite = shiftPress;
        Invoke("UnpressShift", 0.3f);
    }  
    
    public void PressEsc() // Al pulsar el escape
    {
        exit.sprite = escPress;
        Invoke("UnpressEsc", 0.3f);
    }   
    
    public void PressSpace() // Al pulsar el espacio
    {
        volume.sprite = spacePress;
        Invoke("UnpressSpace", 0.3f);
    }

    // Métodos privados
    private void UnpressSpace()
    {
        volume.sprite = space;
    }

    private void UnpressCtrl()
    {
        start.sprite = ctrl;
    }

    private void UnpressShift()
    {
        skins.sprite = shift;
    }

    private void UnpressEsc()
    {
        exit.sprite = esc;
    }
}