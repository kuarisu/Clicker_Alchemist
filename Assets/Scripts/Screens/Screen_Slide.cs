using UnityEngine;
using System.Collections;
using DG.Tweening;

public class Screen_Slide : MonoBehaviour
{

    public GameObject m_ClickArea;

    public void LerpList()
    {
        transform.DOMoveX(-14.25f, 0.5f);
        m_ClickArea.transform.DOMoveX(-8f, 0.525f);
    }

    public void LerpRP()
    {
        transform.DOMoveX(14.25f, 0.5f);
        m_ClickArea.transform.DOMoveX(8f, 0.525f);
    }

    public void LerpMain()
    {
        transform.DOMoveX(0, 0.5f);
        m_ClickArea.transform.DOMoveX(0, 0.525f);
    }
}
