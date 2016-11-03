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

    void Awake()
    {
        m_MultActif = 1;
        m_MultPassif = 1;

    }

    public void ScoreActif(int _score)
    {
        m_ScoreActif = m_FinalScore + (_score + m_BonusActif) * m_MultActif ;
        FinalScore();
 
    }

    public void ScorePassif(int _score)
    {
        m_ScorePassif = m_FinalScore + (_score + m_BonusPassif) * m_MultPassif;
    }

    public void FinalScore()
    {
        m_FinalScore = m_ScoreActif + m_ScorePassif;
        Manager_Ressources.Instance.m_CurrentScore = m_FinalScore;
        Manager_Ressources.Instance.ChangeScore();
    }

}
