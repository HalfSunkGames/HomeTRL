using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardPosition : MonoBehaviour
{

    public static List<Vector3> positions = new List<Vector3>();

    void Start()
    {
        FillPositionList(positions);
    }

    //Rellena el array con las posiciones de las teclas
    void FillPositionList(List<Vector3> positions)
    {
        
        Vector3 pos1 = new Vector3(-7.68f, 1, -15.5f);    //0
        Vector3 pos2 = new Vector3(-7.68f, 1, -13.69f);   //1
        Vector3 pos3 = new Vector3(-7.68f, 1, -11.88f);   //2
        Vector3 pos4 = new Vector3(-7.68f, 1, -10.03f);   //3
        Vector3 pos5 = new Vector3(-7.68f, 1, -8.21f);    //4
        Vector3 pos6 = new Vector3(-7.68f, 1, -6.44f);    //5
        Vector3 pos7 = new Vector3(-7.68f, 1, -4.53f);    //6
        Vector3 pos8 = new Vector3(-7.68f, 1, -2.71f);    //7
        Vector3 pos9 = new Vector3(-7.68f, 1, -0.93f);    //8
        Vector3 pos0 = new Vector3(-7.68f, 1, 0.9f);      //9
        Vector3 posQ = new Vector3(-5.45f, 1, -14.57f);   //10
        Vector3 posW = new Vector3(-5.45f, 1, -12.8f);    //11
        Vector3 posE = new Vector3(-5.45f, 1, -10.95f);   //12
        Vector3 posR = new Vector3(-5.45f, 1, -9.14f);    //13
        Vector3 posT = new Vector3(-5.45f, 1, -7.29f);    //14
        Vector3 posY = new Vector3(-5.45f, 1, -5.55f);    //15
        Vector3 posU = new Vector3(-5.45f, 1, -3.69f);    //16
        Vector3 posI = new Vector3(-5.45f, 1, -1.87f);    //17
        Vector3 posO = new Vector3(-5.45f, 1, -0.01f);    //18
        Vector3 posP = new Vector3(-5.45f, 1, 1.77f);     //19
        Vector3 posA = new Vector3(-3.22f, 1, -13.76f);   //20
        Vector3 posS = new Vector3(-3.22f, 1, -11.96f);   //21
        Vector3 posD = new Vector3(-3.22f, 1, -10.13f);   //22
        Vector3 posF = new Vector3(-3.22f, 1, -8.33f);    //23
        Vector3 posG = new Vector3(-3.22f, 1, -6.52f);    //24
        Vector3 posH = new Vector3(-3.22f, 1, -4.7f);     //25
        Vector3 posJ = new Vector3(-3.22f, 1, -2.9f);     //26
        Vector3 posK = new Vector3(-3.22f, 1, -1.09f);    //27
        Vector3 posL = new Vector3(-3.22f, 1, 0.76f);     //28
        Vector3 posZ = new Vector3(-1.04f, 1, -13.36f);   //29
        Vector3 posX = new Vector3(-1.04f, 1, -11.58f);   //30
        Vector3 posC = new Vector3(-1.04f, 1, -9.76f);    //31
        Vector3 posV = new Vector3(-1.04f, 1, -7.9f);     //32
        Vector3 posB = new Vector3(-1.04f, 1, -6.15f);    //33
        Vector3 posN = new Vector3(-1.04f, 1, -4.28f);    //34
        Vector3 posM = new Vector3(-1.04f, 1, -2.56f);    //35
        Vector3 posCTRL = new Vector3(1.22f, 1, -17.11f); //36

        positions.Add(pos1);
        positions.Add(pos2);
        positions.Add(pos3);
        positions.Add(pos4);
        positions.Add(pos5);
        positions.Add(pos6);
        positions.Add(pos7);
        positions.Add(pos8);
        positions.Add(pos9);
        positions.Add(pos0);
        positions.Add(posQ);
        positions.Add(posW);
        positions.Add(posE);
        positions.Add(posR);
        positions.Add(posT);
        positions.Add(posY);
        positions.Add(posU);
        positions.Add(posI);
        positions.Add(posO);
        positions.Add(posP);
        positions.Add(posA);
        positions.Add(posS);
        positions.Add(posD);
        positions.Add(posF);
        positions.Add(posG);
        positions.Add(posH);
        positions.Add(posJ);
        positions.Add(posK);
        positions.Add(posL);
        positions.Add(posZ);
        positions.Add(posX);
        positions.Add(posC);
        positions.Add(posV);
        positions.Add(posB);
        positions.Add(posN);
        positions.Add(posM);
        positions.Add(posCTRL);

    }

}
