
using UnityEngine;
using System.Collections;

public class Button_Potions : MonoBehaviour {

    public GameObject m_ScreenPotions;
    [SerializeField]
    Animator m_An;
    bool m_isOpened = false;

    void Start()
    {
        m_An = m_ScreenPotions.GetComponent<Animator>();
        m_isOpened = false;
    }

    public void Clicked()
    {

        if (m_isOpened == false)
            Opening();

        else
            Closing();

    }

    public void Opening()
    {
        m_ScreenPotions.SetActive(true);
        m_An.SetBool("IsOpen", true);
        m_isOpened = true;
    }
    public void Closing()
    {
        m_An.SetBool("IsOpen", false);
        m_isOpened = false;
    }
}
