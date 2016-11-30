using UnityEngine;
using System.Collections;
using UnityEngine.UI;

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
    enum TypeEffect
    {
        Good,
        Bad,
        Neutral,
    }

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
                //Lawl
                break;
            case TypeEffect.Bad:
                //Je m'amuse
                break;
            case TypeEffect.Neutral:
                //Much Fun Such Wow
                break;
            default:
                break;
        }
        Debug.Log("hello yes");
        this.GetComponentInParent<Request_MainSpawn>().Destroying();
        this.GetComponentInParent<Request_MainSpawn>().StartingTimers();

    }

    public void Declined()
    {
        Debug.Log("hello no");
        this.GetComponentInParent<Request_MainSpawn>().Destroying();

    }
}
