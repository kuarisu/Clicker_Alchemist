using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class Request_Impact : MonoBehaviour {
    // Tout ce qui constitue la request (nom, description, demande, timer, impact sur le jeu si remplie)
    public bool m_isAccepted = true;
    public bool m_isActivated = false;



    [SerializeField]
    Text m_NameRequestText;
    [SerializeField]
    Text m_DescriptionText;

    [SerializeField]
    string m_NameRequest;
    [SerializeField]
    string m_Description;

    [SerializeField]
    int m_Bonus;
    [SerializeField]
    int m_TimerBonus;
    [SerializeField]
    enum TypeEffect
    {
        Good,
        Bad,
        Neutral,
    }
    [SerializeField]
    TypeEffect m_TypeOfEffect;



    // Use this for initialization
    void Start () {
        m_NameRequestText.text = m_NameRequest;
        m_DescriptionText.text = m_Description;

    }

    public void Accepted()
    {
        // do stuff about the quest
        switch (m_TypeOfEffect)
        {
            case TypeEffect.Good:
                m_Bonus *= 1;
                break;
            case TypeEffect.Bad:
                m_Bonus *= -1;
                break;
            case TypeEffect.Neutral:
                m_Bonus = 0;
                break;
            default:
                break;
        }
        Debug.Log("hello yes");
        this.GetComponentInParent<Request_MainSpawn>().m_TimerBonus = m_TimerBonus;
        this.GetComponentInParent<Request_MainSpawn>().m_TempBonus = m_Bonus;
        this.GetComponentInParent<Request_MainSpawn>().TimerTempo();
        this.GetComponentInParent<Request_MainSpawn>().StartingTimers();
        this.GetComponentInParent<Request_MainSpawn>().Destroying();

    }

    public void Declined()
    {
        Debug.Log("hello no");
 
        this.GetComponentInParent<Request_MainSpawn>().StartingTimers();
        this.GetComponentInParent<Request_MainSpawn>().Destroying();

    }


}
