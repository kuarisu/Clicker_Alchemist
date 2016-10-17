using UnityEngine;
using System.Collections;
using DG.Tweening;

public class Screen_Slide : MonoBehaviour {

//Quand click sur TriggerList: lerp de -14.5 et quand click sur TriggerRP: lerp de 14.5


    public void LerpList()
    {
        transform.DOMoveX(-14.25f, 0.5f);
    }

    public void LerpRP()
    {
        transform.DOMoveX(14.25f, 0.5f);
    }

    public void LerpMain()
    {
        transform.DOMoveX(0, 0.5f);
    }
}
