﻿using UnityEngine;
using System.Collections;

public class Button_Opening : MonoBehaviour {

    public GameObject m_Screen;
    [SerializeField]
    Animator m_An;
    [HideInInspector]
    public bool m_isOpened = false;

    public GameObject m_textForThisButton;

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
        m_An.SetBool("IsOpen", true);
        m_isOpened = true;


    }
    public void Closing()
    {
        m_An.SetBool("IsOpen", false);
        m_isOpened = false;

    }
}
