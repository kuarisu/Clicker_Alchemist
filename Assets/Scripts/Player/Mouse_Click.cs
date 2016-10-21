using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Mouse_Click : MonoBehaviour {

    public Manager_Raycast m_InputManager;

    public GameObject m_MainScreen;
    public GameObject m_RessourcesScore;

    [HideInInspector]
    public int m_NbBOpened = 0;
    public int m_ClickGain;

    public List<Button_Opening> m_ButtonList = new List<Button_Opening>();

    bool m_isClickedList = false;
    bool m_isClickedRP = false;

    [HideInInspector]
    public GameObject m_stockedPostulant;

    int m_Score;
    
    void Awake()
    {
        m_NbBOpened = 0;
    }

    void Update ()
    {
        if (Input.GetMouseButtonDown(0))
            m_InputManager.RayCast();

        if (m_stockedPostulant != null && Input.GetMouseButtonUp(0) && m_stockedPostulant.GetComponent<Liste_ObjMoveable>().m_Dragged == true)
        {
            m_stockedPostulant.GetComponent<Liste_ObjMoveable>().m_Dragged = false;
            m_InputManager.RayCastUp();
        }
    }

    public void CheckRayCast()
    {
        #region Onglets
        if (m_InputManager.m_FoundTag == "TriggerList" || m_InputManager.m_FoundTag == "TriggerRP")
        {

            #region ClosingButtons
            if(m_NbBOpened != 0)
            {
                Debug.Log("NbOpened " + m_NbBOpened);
                while (m_NbBOpened > 0)
                {

                    foreach (Button_Opening Buttons in m_ButtonList)
                    {
                        if (Buttons.GetComponent<Button_Opening>().m_isOpened == true)
                        {
                            Buttons.GetComponent<Button_Opening>().Closing();
                            m_NbBOpened--;
                        }
                    }

                }

            }



            #endregion

            #region OngletsOpening
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

        }
        #endregion

        #region Buttons

        if (m_InputManager.m_FoundTag == "Ressources" || m_InputManager.m_FoundTag == "Potions" || m_InputManager.m_FoundTag == "Bonus" || m_InputManager.m_FoundTag == "StockEx")
        {
            m_InputManager.m_ObjectMet.GetComponent<Button_Opening>().Clicked();
        }

        if (m_InputManager.m_FoundTag == "ClickArea")
        {
            m_RessourcesScore.GetComponent<Manager_Score>().ChangeScore(m_ClickGain);
            m_InputManager.m_ObjectMet.GetComponent<Button_ClickArea>().Bounce();

        }

        #endregion

        #region Liste

        if(m_InputManager.m_FoundTag == "Movable")
        {
            m_stockedPostulant = m_InputManager.m_ObjectMet;

            if (m_stockedPostulant.GetComponent<Liste_ObjMoveable>().m_Movable == true)
            {
                m_stockedPostulant.GetComponent<Liste_ObjMoveable>().m_Dragged = true;
                m_stockedPostulant.GetComponent<Liste_ObjMoveable>().StartCoroutine("isMoving");
            }
        }

        #endregion
        
    }

    public void CheckRayCastUp()
    {
        if (m_stockedPostulant != null && m_InputManager.m_FoundTag == "Employe")
        {
            if ((int)m_stockedPostulant.GetComponent<Liste_ObjMoveable>().m_PostulanType == (int)m_InputManager.m_ObjectMet.GetComponent<Liste_EmployArea>().m_AreaType)
            {
                m_stockedPostulant.GetComponent<Liste_ObjMoveable>().BecomeEmploye();
            }

            else
            {
                m_stockedPostulant.GetComponent<Liste_ObjMoveable>().ResetPost();

            }

        }
        else if (m_stockedPostulant != null && m_InputManager.m_FoundTag != "Employe")
        {
            m_stockedPostulant.GetComponent<Liste_ObjMoveable>().ResetPost();
        }
    }
}

