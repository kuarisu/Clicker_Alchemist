using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Manager_Ressources : MonoBehaviour
{
    [HideInInspector]
    public int m_PreviousScoreP1 = 0;
    [HideInInspector]
    public int m_PreviousScoreP2 = 0;
    [HideInInspector]
    public int m_PreviousScoreP3 = 0;
    [HideInInspector]
    public int m_PreviousScoreGold = 0;

    [HideInInspector]
    public string m_CurrentRessource;

    [HideInInspector]
    public int m_CurrentScore;

    [HideInInspector]
    public int m_CurrentGoldScore;

    public Text m_TextPlant01;
    public Text m_TextPlant02;
    public Text m_TextPlant03;
    public Text m_TextGold;

    [HideInInspector]
    public int m_TypePlant;

    string m_Score01;
    string m_Score02;
    string m_Score03;
    string m_ScoreGolde;

    public static Manager_Ressources Instance;
    private void Awake()
    {
        if (Manager_Ressources.Instance != null)
        {
            Destroy(this.gameObject);
            return;
        }

        Manager_Ressources.Instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    void Start()
    {
        m_Score01 = m_TextPlant01.text;
        m_Score02 = m_TextPlant02.text;
        m_Score03 = m_TextPlant03.text;
        m_ScoreGolde = m_TextGold.text;
    }

    public void ChangeRessources()
    {
        switch (m_TypePlant)
        {
            case 0:
                m_CurrentRessource = m_Score01;
                break;
            case 1:
                m_CurrentRessource = m_Score02;
                break;
            case 2:
                m_CurrentRessource = m_Score03;
                break;
            default:
                break;
        }

    }


    public void ChangeScore()
    {
        
        switch (m_TypePlant)
        {
            case 0:
                m_TextPlant01.text = m_CurrentRessource + m_CurrentScore;
                break;
            case 1:
                m_TextPlant02.text = m_CurrentRessource + m_CurrentScore;
                break;
            case 2:
                m_TextPlant03.text = m_CurrentRessource + m_CurrentScore;
                break;
            default:
                break;

        }
    }

    public void ChangeGoldScore()
    {
        m_TextGold.text = m_ScoreGolde + m_CurrentGoldScore;
    }
}

