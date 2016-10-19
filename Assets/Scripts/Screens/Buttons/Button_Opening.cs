using UnityEngine;
using System.Collections;

public class Button_Opening : MonoBehaviour {

    public GameObject m_Screen;
    [SerializeField]
    Animator m_An;
    bool m_isOpened = false;

    void Start()
    {
        m_An = m_Screen.GetComponent<Animator>();
        m_isOpened = false;
    }

    public void Clicked()
    {
        m_Screen.SetActive(true);
        if (m_isOpened == false)
            Opening();

        else
            Closing();

    }

    public void Opening()
    {
        m_An.SetBool("IsOpen", true);
        m_isOpened = true;
    }
    public void Closing()
    {
        m_An.SetBool("IsOpen", false);
        m_isOpened = false;
    }
}
