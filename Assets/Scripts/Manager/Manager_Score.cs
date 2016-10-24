using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Manager_Score : MonoBehaviour
{
    [HideInInspector]
    public int m_PreviousScoreP1 = 0;
    [HideInInspector]
    public int m_PreviousScoreP2 = 0;
    [HideInInspector]
    public int m_PreviousScoreP3 = 0;

    [HideInInspector]
    public string m_CurrentRessource;

    public Text m_TextPlant01;
    public Text m_TextPlant02;
    public Text m_TextPlant03;


    public int m_ClickGainP1;
    public int m_ClickGainP2;
    public int m_ClickGainP3;

    [HideInInspector]
    public int m_TypePlant;

    public void ChangeRessources()
    {
        switch (m_TypePlant)
        {
            case 0:
                m_CurrentRessource = m_TextPlant01.text;
                break;
            case 1:
                m_CurrentRessource = m_TextPlant02.text;
                break;
            case 2:
                m_CurrentRessource = m_TextPlant03.text;
                break;
            default:
                break;
        }

    }


    public void ChangeScore()
    {
        int _currentScoreP1;
        int _currentScoreP2;
        int _currentScoreP3;

        switch (m_TypePlant)
        {
            case 0:
                _currentScoreP1 = m_PreviousScoreP1 + m_ClickGainP1;
                m_TextPlant01.text = m_CurrentRessource + _currentScoreP1;
                m_PreviousScoreP1 = _currentScoreP1;
                break;
            case 1:
                _currentScoreP2 = m_PreviousScoreP2 + m_ClickGainP2;
                m_TextPlant02.text = m_CurrentRessource + _currentScoreP2;
                m_PreviousScoreP2 = _currentScoreP2;
                break;
            case 2:
                _currentScoreP3 = m_PreviousScoreP3 + m_ClickGainP3;
                m_TextPlant03.text = m_CurrentRessource + _currentScoreP3;
                m_PreviousScoreP3 = _currentScoreP3;
                break;
            default:
                break;

        }
    }
}

