using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Manager_Input : MonoBehaviour {

    public static Manager_Input Instance;

    public GameObject m_MainScreen;
    public GameObject m_Plante;
    public GameObject m_Selection;
    public GameObject m_SellingButton;

    public List<Button_Opening> m_ButtonList = new List<Button_Opening>();

    [HideInInspector]
    public GameObject m_StockedObject;
    [HideInInspector]
    public int m_NbTypePlante;
    [HideInInspector]
    public int m_NbBOpened = 0;

    bool m_isClickedList = false;
    bool m_isClickedRP = false;

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


        if (Input.GetMouseButtonDown(1))
            Manager_Raycast.Instance.RayCastRightClick();

        if (m_StockedObject != null && Input.GetMouseButtonUp(0) && m_StockedObject.GetComponent<Objects_Movable>().m_Dragged == true)
        {
            m_StockedObject.GetComponent<Objects_Movable>().m_Dragged = false;
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
                while (m_NbBOpened > 1)
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
            m_StockedObject = Manager_Raycast.Instance.m_ObjectMet;

            if (m_StockedObject.GetComponent<Objects_Movable>().m_Movable == true)
            {
                m_StockedObject.GetComponent<Objects_Movable>().StockPos();
                m_StockedObject.GetComponent<Objects_Movable>().m_Dragged = true;
                m_StockedObject.GetComponent<Objects_Movable>().StartCoroutine("isMoving");
            }
        }

        #endregion

        #region Plantes
        if (Manager_Raycast.Instance.m_FoundTag == "Plante")
        {
            if (m_Selection.activeSelf == false)
                m_Selection.SetActive(true);
        
           m_Plante = Manager_Raycast.Instance.m_ObjectMet;
           Manager_Ressources.Instance.m_TypePlant = (int)Manager_Raycast.Instance.m_ObjectMet.GetComponent<Plante_Type>().m_TypePlante;
           Manager_Ressources.Instance.ChangeRessources();
            m_SellingButton.GetComponent<Plante_Selling>().ChangeText();

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
        }

        if (Manager_Raycast.Instance.m_FoundTag == "UpgradeAdd")
        {

            Manager_Raycast.Instance.m_ObjectMet.GetComponent<Upgrade_UpAdd>().Action();
        }

        if (Manager_Raycast.Instance.m_FoundTag == "UpgradePercent")
        {

            Manager_Raycast.Instance.m_ObjectMet.GetComponent<Upgrade_UpPerCent>().Action();
        }
        #endregion

        #region Potions

        if (Manager_Raycast.Instance.m_FoundTag == "PotionBuy")
        {
            Manager_Raycast.Instance.m_ObjectMet.GetComponent<Potion_Creation>().Action();
        }
        #endregion

    }

    public void CheckRayCastUp()
    {
        if (m_StockedObject != null && Manager_Raycast.Instance.m_FoundTag == "Employe")
        {
            if ((int)m_StockedObject.GetComponent<Liste_ObjMoveable>().m_PostulanType == (int)Manager_Raycast.Instance.m_ObjectMet.GetComponent<Liste_EmployArea>().m_AreaType)
            {
                m_StockedObject.GetComponent<Liste_ObjMoveable>().BecomeEmploye();
            }

            else
            {
                m_StockedObject.GetComponent<Objects_Movable>().ResetPost();

            }

        }
        else if (m_StockedObject != null && Manager_Raycast.Instance.m_FoundTag != "Employe")
        {
            m_StockedObject.GetComponent<Objects_Movable>().ResetPost();
        }
    }

    public void RayCastRight()
    {
        if (Manager_Raycast.Instance.m_FoundTag == "Selling")
        {
            Manager_Raycast.Instance.m_ObjectMet.GetComponent<Plante_Selling>().ChangeValues();
            Manager_Raycast.Instance.m_ObjectMet.GetComponent<Plante_Selling>().ChangeText();
        }
    }
}

