using UnityEngine;
using System.Collections;

public class Mouse_Click : MonoBehaviour {


    public GameObject m_MainScreen;
    public GameObject m_RessourcesScore;
    public int m_ClickGain;

    bool m_isClickedList = false;
    bool m_isClickedRP = false;

    int m_Score;


    void Update () {
        if (Input.GetMouseButtonDown(0))
            CheckRayCast();
    }

    void CheckRayCast()
    {
        Ray _ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit _hit;

        if (Physics.Raycast(_ray, out _hit))
        {
            #region Onglets
            if (_hit.collider.tag == "TriggerList")
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

            if (_hit.collider.tag == "TriggerRP")
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

            if (_hit.collider.tag == "ClickArea")
            {
                m_RessourcesScore.GetComponent<Manager_Score>().ChangeScore(m_ClickGain);
            }
        }
    }
}
