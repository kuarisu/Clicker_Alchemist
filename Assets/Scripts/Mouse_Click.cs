using UnityEngine;
using System.Collections;

public class Mouse_Click : MonoBehaviour {

    public Manager_Input m_InputManager;

    public GameObject m_MainScreen;
    public GameObject m_RessourcesScore;
    public int m_ClickGain;

    bool m_isClickedList = false;
    bool m_isClickedRP = false;

    int m_Score;

    void Update ()
    {
        if (Input.GetMouseButtonDown(0))
            m_InputManager.RayCast();
            
    }

    public void CheckRayCast()
    {
        #region Onglets
        if (m_InputManager.m_FoundTag == "TriggerList")
        {
            if (m_isClickedList == false)
            {
                m_MainScreen.GetComponent<Screen_Slide>().LerpList();
                m_isClickedList = true;
            }

            else
            {
                m_MainScreen.GetComponent<Screen_Slide>().LerpMain();
                m_isClickedList = false;
            }


        }

        if (m_InputManager.m_FoundTag == "TriggerRP")
        {
            if (m_isClickedRP == false)
            {
                m_MainScreen.GetComponent<Screen_Slide>().LerpRP();
                m_isClickedRP = true;
            }

            else
            {
                m_MainScreen.GetComponent<Screen_Slide>().LerpMain();
                m_isClickedRP = false;
            }
        }
        #endregion

        if (m_InputManager.m_FoundTag == "Ressources")
            Debug.Log("hellowowowowowow");

        if (m_InputManager.m_FoundTag == "ClickArea")
        {
            m_RessourcesScore.GetComponent<Manager_Score>().ChangeScore(m_ClickGain);
        }
    }
}

