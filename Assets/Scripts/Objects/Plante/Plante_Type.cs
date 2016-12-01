using UnityEngine;
using System.Collections;

public class Plante_Type : MonoBehaviour {

	public enum Type
    {
        Type01,
        Type02,
        Type03,
    }

    public Type m_TypePlante;

    public int m_ClickGain;

    [HideInInspector]
    public int m_BonusActif = 0;
    //[HideInInspector]
    public int m_BonusPassif = 0;

    [HideInInspector]
    public int m_MultActif = 1;
    //[HideInInspector]
    public int m_MultPassif = 1;

    [HideInInspector]
    public int m_ScoreActif = 0;
    [HideInInspector]
    public int m_ScorePassif = 0;

    [HideInInspector]
    public int m_FinalScore = 0;

    int m_CurrentScore;

    void Awake()
    {
        m_MultActif = 1;
        m_MultPassif = 1;
        m_CurrentScore = m_FinalScore;
    }

    public void ScoreActif(int _score)
    {
        m_ScoreActif = m_FinalScore + (_score + m_BonusActif) * m_MultActif ;
        FinalScoreActif();
 
    }

    public void ScorePassif(int _score)
    {
        m_ScorePassif = m_FinalScore + (_score + m_BonusPassif) * m_MultPassif;
        FinalScorePassif();
    }

    public void FinalScoreActif()
    {
        m_FinalScore = m_CurrentScore + m_ScoreActif;
        Manager_Ressources.Instance.m_CurrentScore = m_FinalScore;
        Manager_Ressources.Instance.ChangeScoreClickArea();
    }
    public void FinalScorePassif()
    {
        m_FinalScore = m_CurrentScore + m_ScorePassif;
        switch (m_TypePlante)
        {
            case Type.Type01:
                Manager_Ressources.Instance.m_PlanteQuantiy01 = m_FinalScore;
                break;
            case Type.Type02:
                Manager_Ressources.Instance.m_PlanteQuantiy02 = m_FinalScore;
                break;
            case Type.Type03:
                Manager_Ressources.Instance.m_PlanteQuantiy03 = m_FinalScore;
                break;
            default:
                break;
        }
        //Manager_Ressources.Instance.m_CurrentScore = m_FinalScore;
        ChangeFinalScore();
    }

    public void FinalScorePotion()
    {
        switch (m_TypePlante)
        {
            case Type.Type01:
                Manager_Ressources.Instance.m_PlanteQuantiy01 = m_FinalScore;
                break;
            case Type.Type02:
                Manager_Ressources.Instance.m_PlanteQuantiy02 = m_FinalScore;
                break;
            case Type.Type03:
                Manager_Ressources.Instance.m_PlanteQuantiy03 = m_FinalScore;
                break;
            default:
                break;
        }

        ChangeFinalScore();
    }

    public void ChangeFinalScore()
    {
        Manager_Ressources.Instance.ChangeScore();
    }

}
