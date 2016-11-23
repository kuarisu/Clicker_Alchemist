using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Plante_Selling : MonoBehaviour {

    public List<GameObject> m_TypePlanteList = new List<GameObject>();

    public int m_NbSold = 1;
    [HideInInspector]
    public int m_NbSoldMult = 1;

    public int m_NbGold = 10;
    [HideInInspector]
    public int m_NbGoldMult = 1;

    [HideInInspector]
    public int m_NbClick = 1;

    [HideInInspector]
    public int m_Score = 0;

    [SerializeField]
    public Text m_SellingText;

    [SerializeField]
    public Plante_SellingValues m_CurrentPlante;
   
    //Manager_Ressources.Instance.m_TypePlant

    public void Selling()
    {
        if (Manager_Input.Instance.m_Plante.GetComponent<Plante_Type>().m_FinalScore >= m_CurrentPlante.m_NbSold  * m_CurrentPlante.m_MultiplicatorList[m_CurrentPlante.m_NbClick])
        {

            Manager_Input.Instance.m_Plante.GetComponent<Plante_Type>().m_FinalScore -= m_CurrentPlante.m_NbSold * m_CurrentPlante.m_MultiplicatorList[m_CurrentPlante.m_NbClick];
            Manager_Ressources.Instance.m_CurrentScore = Manager_Input.Instance.m_Plante.GetComponent<Plante_Type>().m_FinalScore;
            Manager_Ressources.Instance.ChangeScoreClickArea();
            m_Score = m_CurrentPlante.m_NbGoldForOne * m_CurrentPlante.m_MultiplicatorList[m_CurrentPlante.m_NbClick];
            Manager_Gold.Instance.IncreaseGoldActif(m_Score);
        }
    }

    public void ChangeText()
    {

        switch (Manager_Ressources.Instance.m_TypePlant)
        {
            case 0:               
                m_CurrentPlante = m_TypePlanteList[0].GetComponent<Plante_SellingValues>();
                break;
            case 1:
                m_CurrentPlante = m_TypePlanteList[1].GetComponent<Plante_SellingValues>();
                break;
            case 2:
                m_CurrentPlante = m_TypePlanteList[2].GetComponent<Plante_SellingValues>();

                break;
        }

        m_SellingText.text = "Selling " + m_CurrentPlante.m_NbSold * m_CurrentPlante.m_MultiplicatorList[m_CurrentPlante.m_NbClick] + " plant(s) for " + m_CurrentPlante.m_NbGoldForOne * m_CurrentPlante.m_MultiplicatorList[m_CurrentPlante.m_NbClick] + " Golds";
    }

    public void ChangeValues()
    {
        m_CurrentPlante.ChangeNbSold();
    }
}
