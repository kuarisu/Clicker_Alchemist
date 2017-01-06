using UnityEngine;
using System.Collections;
using DG.Tweening;

public class Screen_Slide : MonoBehaviour
{

    public GameObject m_ClickArea;
    public GameObject m_Buttons;

    public void LerpList()
    {
        SetActiveFalse();
        transform.DOMoveX(-14.25f, 0.5f);
        m_ClickArea.transform.DOMoveX(-8f, 0.525f);

    }

    public void LerpRP()
    {
        SetActiveFalse();
        transform.DOMoveX(14.25f, 0.5f);
        m_ClickArea.transform.DOMoveX(8f, 0.525f);
        
    }

    public void LerpMain()
    {
        SetActiveTrue();
        transform.DOMoveX(0, 0.5f);
        m_ClickArea.transform.DOMoveX(0, 0.525f);

    }

    void SetActiveFalse()
    {
        m_Buttons.transform.DOMoveZ(1.2f, 0.1f); ;
    }

    void SetActiveTrue()
    {
        m_Buttons.transform.DOMoveZ(0, 0.1f); ; ;
    }
}
