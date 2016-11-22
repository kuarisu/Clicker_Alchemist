using UnityEngine;
using System.Collections;

public class Manager_Gold : MonoBehaviour {

    public static Manager_Gold Instance;

    public int m_ScoreActif;
    public int m_BonusActif = 0;
    public int m_MultActif = 1;

    public int m_ScorePassif;
    public int m_BonusPassif;
    public int m_MultPassif;

    [HideInInspector]
    public int m_FinalScore = 0;

    int m_CurrentScore;

    private void Awake()
    {
        if (Manager_Gold.Instance != null)
        {
            Destroy(this.gameObject);
            return;
        }

        Manager_Gold.Instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    {
        m_MultActif = 1;
        m_CurrentScore = m_FinalScore;
    }

    public void IncreaseGoldActif(int _score)
    {
        m_ScoreActif = m_FinalScore + (_score + m_BonusActif) * m_MultActif;
        FinalScoreActif();

    }

    public void IncreaseGoldPassif(int _score)
    {
        m_ScorePassif = m_FinalScore + (_score + m_BonusPassif) * m_MultPassif;
        FinalScorePassif();
    }


    public void FinalScoreActif()
    {
        m_FinalScore = m_CurrentScore + m_ScoreActif;
        Manager_Ressources.Instance.m_CurrentGoldScore = m_FinalScore;
        Manager_Ressources.Instance.ChangeGoldScore();
    }
    public void FinalScorePassif()
    {
        m_FinalScore = m_CurrentScore + m_ScorePassif;
        Manager_Ressources.Instance.m_CurrentGoldScore = m_FinalScore;
        Manager_Ressources.Instance.ChangeGoldScore();
    }
}
