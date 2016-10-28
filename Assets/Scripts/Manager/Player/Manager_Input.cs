using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Manager_Input : MonoBehaviour {

    public static Manager_Input Instance;

    public GameObject m_MainScreen;

    [HideInInspector]
    public int m_NbBOpened = 0;

    public List<Button_Opening> m_ButtonList = new List<Button_Opening>();

    bool m_isClickedList = false;
    bool m_isClickedRP = false;

    [HideInInspector]
    public GameObject m_stockedPostulant;
    [HideInInspector]
    public int m_NbTypePlante;

    public GameObject m_Plante;

    int m_Score;


    private void Awake()
    {
        if (Manager_Input.Instance != null)
        {
            Destroy(this.gameObject);
            return;
        }

        Manager_Input.Instance = this;
        DontDestroyOnLoad(this.gameObject);

        m_NbBOpened = 0;
    }

    void Update ()
    {
        if (Input.GetMouseButtonDown(0))
            Manager_Raycast.Instance.RayCast();

        if (m_stockedPostulant != null && Input.GetMouseButtonUp(0) && m_stockedPostulant.GetComponent<Liste_ObjMoveable>().m_Dragged == true)
        {
            m_stockedPostulant.GetComponent<Liste_ObjMoveable>().m_Dragged = false;
            Manager_Raycast.Instance.RayCastUp();
        }
    }

    public void CheckRayCast()
    {
        #region Onglets
        if (Manager_Raycast.Instance.m_FoundTag == "TriggerList" || Manager_Raycast.Instance.m_FoundTag == "TriggerRP")
        {

            #region ClosingButtons
            if(m_NbBOpened != 0)
            {
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
            if (Manager_Raycast.Instance.m_FoundTag == "TriggerList")
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

            if (Manager_Raycast.Instance.m_FoundTag == "TriggerRP")
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

        if (Manager_Raycast.Instance.m_FoundTag == "Ressources" || Manager_Raycast.Instance.m_FoundTag == "Potions" || Manager_Raycast.Instance.m_FoundTag == "Bonus" || Manager_Raycast.Instance.m_FoundTag == "StockEx")
        {
            Manager_Raycast.Instance.m_ObjectMet.GetComponent<Button_Opening>().Clicked();
        }
        else if (Manager_Raycast.Instance.m_FoundTag == "ClickArea")
        {
            if (m_Plante!=null)
                m_Plante.GetComponent<Plante_Type>().ScoreActif(m_Plante.GetComponent<Plante_Type>().m_ClickGain);
            Manager_Raycast.Instance.m_ObjectMet.GetComponent<Button_ClickArea>().Bounce();

        }

        #endregion

        #region Liste

        if(Manager_Raycast.Instance.m_FoundTag == "Movable")
        {
            m_stockedPostulant = Manager_Raycast.Instance.m_ObjectMet;

            if (m_stockedPostulant.GetComponent<Liste_ObjMoveable>().m_Movable == true)
            {
                m_stockedPostulant.GetComponent<Liste_ObjMoveable>().m_Dragged = true;
                m_stockedPostulant.GetComponent<Liste_ObjMoveable>().StartCoroutine("isMoving");
            }
        }

        #endregion

        #region Plantes
        if (Manager_Raycast.Instance.m_FoundTag == "Plante")
        {
           m_Plante = Manager_Raycast.Instance.m_ObjectMet;
           Manager_Ressources.Instance.m_TypePlant = (int)Manager_Raycast.Instance.m_ObjectMet.GetComponent<Plante_Type>().m_TypePlante;
           Manager_Ressources.Instance.ChangeRessources();
        }


        if (Manager_Raycast.Instance.m_FoundTag == "Selling")
        {
            Manager_Raycast.Instance.m_ObjectMet.GetComponent<Plante_Selling>().Selling();
        }
        #endregion

        #region UpGrade
        if (Manager_Raycast.Instance.m_FoundTag == "UpgradeMult")
        {

            Manager_Raycast.Instance.m_ObjectMet.GetComponent<Upgrade_UpMult>().Action();
            Debug.Log(Manager_Gold.Instance.m_FinalScore);
        }

        if (Manager_Raycast.Instance.m_FoundTag == "UpgradeAdd")
        {

            Manager_Raycast.Instance.m_ObjectMet.GetComponent<Upgrade_UpAdd>().Action();
            Debug.Log(Manager_Gold.Instance.m_FinalScore);
        }

        if (Manager_Raycast.Instance.m_FoundTag == "UpgradePercent")
        {

            Manager_Raycast.Instance.m_ObjectMet.GetComponent<Upgrade_UpPerCent>().Action();
            Debug.Log(Manager_Gold.Instance.m_FinalScore);
        }
        #endregion

    }

    public void CheckRayCastUp()
    {
        if (m_stockedPostulant != null && Manager_Raycast.Instance.m_FoundTag == "Employe")
        {
            if ((int)m_stockedPostulant.GetComponent<Liste_ObjMoveable>().m_PostulanType == (int)Manager_Raycast.Instance.m_ObjectMet.GetComponent<Liste_EmployArea>().m_AreaType)
            {
                m_stockedPostulant.GetComponent<Liste_ObjMoveable>().BecomeEmploye();
            }

            else
            {
                m_stockedPostulant.GetComponent<Liste_ObjMoveable>().ResetPost();

            }

        }
        else if (m_stockedPostulant != null && Manager_Raycast.Instance.m_FoundTag != "Employe")
        {
            m_stockedPostulant.GetComponent<Liste_ObjMoveable>().ResetPost();
        }
    }
}

