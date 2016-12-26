using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Button_Opening : MonoBehaviour {

    public GameObject m_Screen;
    [SerializeField]
    Animator m_An;
    [HideInInspector]
    public bool m_isOpened = false;

    public GameObject m_textForThisButton;

    [SerializeField]
    Animator m_AnSquare;
    [SerializeField]
    BoxCollider m_FullButtonCollider;
    [SerializeField]
    Image m_IconButton;

    void Start()
    {
        m_An = m_Screen.GetComponent<Animator>();
        m_isOpened = false;
    }

    public void Clicked()
    {
        m_Screen.SetActive(true);
        if (m_isOpened == false)
        {
            Manager_Input.Instance.m_NbBOpened++;
            Opening();
            if(m_textForThisButton != null)
                Invoke("TextAppear", 0.2f);

        }

        else
        {
            Manager_Input.Instance.m_NbBOpened--;
            Closing();
            if (m_textForThisButton != null)
                Invoke("TextDisappear", 0.2f);

        }

    }

    void TextAppear()
    {
        m_textForThisButton.SetActive(true);
    }

    void TextDisappear ()
    {
        m_textForThisButton.SetActive(false);
    }

    public void Opening()
    {
        m_AnSquare.SetBool("m_ClosingButton", true);
        m_An.SetBool("IsOpen", true);
        m_FullButtonCollider.enabled = false;
        //Color _color = m_IconButton.color;
        //_color.a = 0.75f;
        //m_IconButton.color = _color;
        m_isOpened = true;


    }
    public void Closing()
    {
        m_AnSquare.SetBool("m_ClosingButton", false);
        m_An.SetBool("IsOpen", false);
        m_FullButtonCollider.enabled = true;
        //Color _color = m_IconButton.color;
        //_color.a = 1f;
        //m_IconButton.color = _color;
        m_isOpened = false;

    }
}
