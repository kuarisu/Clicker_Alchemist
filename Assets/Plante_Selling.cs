using UnityEngine;
using System.Collections;

public class Plante_Selling : MonoBehaviour {

    
    public int m_NbSold = 1;
    [HideInInspector]
    public int m_NbSoldMult = 1;

    public int m_NbGold = 10;
    [HideInInspector]
    public int m_NbGoldMult = 1;

    [HideInInspector]
    public int m_Score = 0;
   


    public void Selling()
    {
        if (Manager_Input.Instance.m_Plante.GetComponent<Plante_Type>().m_FinalScore >= m_NbSold * m_NbSoldMult)
        {

            Manager_Input.Instance.m_Plante.GetComponent<Plante_Type>().m_FinalScore -= m_NbSold * m_NbSoldMult;
            Manager_Ressources.Instance.m_CurrentScore = Manager_Input.Instance.m_Plante.GetComponent<Plante_Type>().m_FinalScore;
            Manager_Ressources.Instance.ChangeScore();
            m_Score = m_NbGold * m_NbGoldMult;
            Manager_Gold.Instance.IncreaseGoldActif(m_Score);
        }
    }
}
