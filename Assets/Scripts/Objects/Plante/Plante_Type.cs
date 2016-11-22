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
    [HideInInspector]
    public int m_BonusPassif = 0;

    [HideInInspector]
    public int m_MultActif = 1;
    [HideInInspector]
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
        Debug.Log(m_MultPassif);
        m_ScorePassif = m_FinalScore + (_score + m_BonusPassif) * m_MultPassif;
        FinalScorePassif();
    }

    public void FinalScoreActif()
    {
        m_FinalScore = m_CurrentScore + m_ScoreActif;
        Manager_Ressources.Instance.m_CurrentScore = m_FinalScore;
        Manager_Ressources.Instance.ChangeScore();
    }
    public void FinalScorePassif()
    {
        m_FinalScore = m_CurrentScore + m_ScorePassif;
        Manager_Ressources.Instance.m_CurrentScore = m_FinalScore;
        Manager_Ressources.Instance.ChangeScore();
    }

}
