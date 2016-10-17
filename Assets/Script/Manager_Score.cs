using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Manager_Score : MonoBehaviour
{
    public int m_PreviousScore;
    Text m_Text;                      // Reference to the Text component.


    void Awake()
    {
        m_Text = GetComponent<Text>();
        m_PreviousScore = 0;
        ChangeScore(0);
    }


    public void ChangeScore(int _score)
    {
        
        int _currentScore = m_PreviousScore + _score;
        m_Text.text = "Ressources: " + _currentScore;
        m_PreviousScore = _currentScore;
    }
}

