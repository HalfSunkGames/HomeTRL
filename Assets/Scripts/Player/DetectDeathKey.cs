using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class DetectDeathKey : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject[] allkeys;
    private GameObject deathkey;

    private int lastPosition;

    private ParentConstraint parentConstraint;
    public GameObject deathSprite;

    private ConstraintSource constraintSource;

    public void DeadSprite(int lP)
    {
        lastPosition = lP;
        AssignKey();
        Debug.Log(deathkey.name);

        constraintSource.sourceTransform = deathkey.transform;
        parentConstraint = deathSprite.GetComponent<ParentConstraint>();
        parentConstraint.constraintActive = true;
        constraintSource.weight = 1f;
        parentConstraint.SetSource(0, constraintSource);
        parentConstraint.constraintActive = true;
        parentConstraint.SetRotationOffset(0, new Vector3(90, 0, 0));
        parentConstraint.SetTranslationOffset(0, KeyboardPosition.offsets[lastPosition]);
    }

    private void AssignKey()
    {
        switch (lastPosition)
        {
            case 0:
                deathkey = GameObject.Find("Alpha1").gameObject;
                break;            
            case 1:
                deathkey = GameObject.Find("Alpha2").gameObject;
                break;            
            case 2:
                deathkey = GameObject.Find("Alpha3").gameObject;
                break;            
            case 3:
                deathkey = GameObject.Find("Alpha4").gameObject;
                break;            
            case 4:
                deathkey = GameObject.Find("Alpha5").gameObject;
                break;            
            case 5:
                deathkey = GameObject.Find("Alpha6").gameObject;
                break;            
            case 6:
                deathkey = GameObject.Find("Alpha7").gameObject;
                break;            
            case 7:
                deathkey = GameObject.Find("Alpha8").gameObject;
                break;            
            case 8:
                deathkey = GameObject.Find("Alpha9").gameObject;
                break;            
            case 9:
                deathkey = GameObject.Find("Alpha0").gameObject;
                break;            
            case 10:
                deathkey = GameObject.Find("Q").gameObject;
                break;            
            case 11:
                deathkey = GameObject.Find("W").gameObject;
                break;            
            case 12:
                deathkey = GameObject.Find("E").gameObject;
                break;            
            case 13:
                deathkey = GameObject.Find("R").gameObject;
                break;            
            case 14:
                deathkey = GameObject.Find("T").gameObject;
                break;            
            case 15:
                deathkey = GameObject.Find("Y").gameObject;
                break;            
            case 16:
                deathkey = GameObject.Find("U").gameObject;
                break;            
            case 17:
                deathkey = GameObject.Find("I").gameObject;
                break;            
            case 18:
                deathkey = GameObject.Find("O").gameObject;
                break;            
            case 19:
                deathkey = GameObject.Find("P").gameObject;
                break;            
            case 20:
                deathkey = GameObject.Find("A").gameObject;
                break;            
            case 21:
                deathkey = GameObject.Find("S").gameObject;
                break;            
            case 22:
                deathkey = GameObject.Find("D").gameObject;
                break;            
            case 23:
                deathkey = GameObject.Find("F").gameObject;
                break;            
            case 24:
                deathkey = GameObject.Find("G").gameObject;
                break;            
            case 25:
                deathkey = GameObject.Find("H").gameObject;
                break;            
            case 26:
                deathkey = GameObject.Find("J").gameObject;
                break;            
            case 27:
                deathkey = GameObject.Find("K").gameObject;
                break;            
            case 28:
                deathkey = GameObject.Find("L").gameObject;
                break;            
            case 29:
                deathkey = GameObject.Find("Z").gameObject;
                break;            
            case 30:
                deathkey = GameObject.Find("X").gameObject;
                break;            
            case 31:
                deathkey = GameObject.Find("C").gameObject;
                break;            
            case 32:
                deathkey = GameObject.Find("V").gameObject;
                break;            
            case 33:
                deathkey = GameObject.Find("B").gameObject; 
                break;            
            case 34:
                deathkey = GameObject.Find("N").gameObject; 
                break;            
            case 35:
                deathkey = GameObject.Find("M").gameObject; 
                break;
            default:
                break;
        }
    }
}