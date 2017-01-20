using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;


public class Postulant_Bonus : MonoBehaviour {

    
    public GameObject m_ManagerSpawn;

    [SerializeField]
    Text m_TextBonus;

    [SerializeField]
    int m_Timer;

    [SerializeField]
    List<GameObject> m_ListPlant = new List<GameObject>();

    GameObject m_TypePlant;

    [SerializeField]
    enum Impact
    {
        Actif,
        Passif,
        OrActive,
        OrPassive,
    }
    [SerializeField]
    Impact m_Impact;


    [SerializeField]
    enum TypeBonus
    {
        PerCent,
        Multiplicator,
        Add,
    }
    [SerializeField]
    TypeBonus m_TypeBonus;

    [SerializeField]
    enum TypePlant
    {
        Greend,
        Red,
        Blue,
    }
    [SerializeField]
    TypePlant m_TypeOfPlant;

    [SerializeField]
    int m_Percent;
    [SerializeField]
    int m_Multiplicator;
    [SerializeField]
    int m_Addition;

    void Start()
    {
        switch (m_TypeBonus)
        {
            case TypeBonus.PerCent:
                m_TextBonus.text = "+ "+ m_Percent + "%";
                break;
            case TypeBonus.Multiplicator:
                m_TextBonus.text = "x " + m_Multiplicator;
                break;
            case TypeBonus.Add:
                m_TextBonus.text = "+ " + m_Addition;
                break;
            default:
                break;
        }

        switch (m_TypeOfPlant)
        {
            case TypePlant.Greend:
                m_TypePlant = m_ListPlant[0];
                break;
            case TypePlant.Red:
                m_TypePlant = m_ListPlant[1];
                break;
            case TypePlant.Blue:
                m_TypePlant = m_ListPlant[2];
                break;
            default:
                break;
        }

        StartCoroutine(TimerTimeLeft());
        m_ManagerSpawn = this.transform.parent.gameObject;
    }


    public void Action()
    {
            switch (m_Impact)
            {
                case Impact.Actif:
                    ActionOnActif(false);
                    break;
                case Impact.Passif:
                    ActionOnPassif(false);
                    break;
                case Impact.OrActive:
                    ActionOnOrActive(false);
                    break;
                case Impact.OrPassive:
                    ActionOnOrPassive(false);
                    break;
            }
    }

    #region Actions
    void ActionOnActif(bool _isCanceled)
    {
        if(!_isCanceled)
        {
            switch (m_TypeBonus)
            {
                case TypeBonus.PerCent:
                    m_TypePlant.GetComponent<Plante_Type>().m_MultActif += m_Percent / 10;
                    break;
                case TypeBonus.Multiplicator:
                    m_TypePlant.GetComponent<Plante_Type>().m_MultActif += m_Multiplicator;
                    break;
                case TypeBonus.Add:
                    m_TypePlant.GetComponent<Plante_Type>().m_BonusActif += m_Addition;
                    break;
                default:
                    break;
            }
        }
        else
        {
            switch (m_TypeBonus)
            {
                case TypeBonus.PerCent:
                    m_TypePlant.GetComponent<Plante_Type>().m_MultActif -= m_Percent / 10;
                    break;
                case TypeBonus.Multiplicator:
                    m_TypePlant.GetComponent<Plante_Type>().m_MultActif -= m_Multiplicator;
                    break;
                case TypeBonus.Add:
                    m_TypePlant.GetComponent<Plante_Type>().m_BonusActif -= m_Addition;
                    break;
                default:
                    break;
            }

        }
   
    }


    void ActionOnPassif(bool _isCanceled)
    {
        if (!_isCanceled)
        {
            switch (m_TypeBonus)
            {
                case TypeBonus.PerCent:
                    m_TypePlant.GetComponent<Plante_Type>().m_MultPassif += m_Percent / 10;
                    break;
                case TypeBonus.Multiplicator:
                    m_TypePlant.GetComponent<Plante_Type>().m_MultPassif += m_Multiplicator;
                    break;
                case TypeBonus.Add:
                    m_TypePlant.GetComponent<Plante_Type>().m_BonusPassif += m_Addition;
                    break;
                default:
                    break;
            }
        }
        else
        {
            switch (m_TypeBonus)
            {
                case TypeBonus.PerCent:
                    m_TypePlant.GetComponent<Plante_Type>().m_MultPassif -= m_Percent / 10;
                    break;
                case TypeBonus.Multiplicator:
                    m_TypePlant.GetComponent<Plante_Type>().m_MultPassif -= m_Multiplicator;
                    break;
                case TypeBonus.Add:
                    m_TypePlant.GetComponent<Plante_Type>().m_BonusPassif -= m_Addition;
                    break;
                default:
                    break;
            }

        }
     
    }

    void ActionOnOrActive(bool _isCanceled)
    {
        if (!_isCanceled)
        {
            switch (m_TypeBonus)
            {
                case TypeBonus.PerCent:
                    Manager_Gold.Instance.m_MultActif += m_Percent / 10;
                    break;
                case TypeBonus.Multiplicator:
                    Manager_Gold.Instance.m_MultActif += m_Multiplicator;
                    break;
                case TypeBonus.Add:
                    Manager_Gold.Instance.m_BonusActif += m_Addition;
                    break;
                default:
                    break;
            }
        }
        else
        {
            switch (m_TypeBonus)
            {
                case TypeBonus.PerCent:
                    Manager_Gold.Instance.m_MultActif -= m_Percent / 10;
                    break;
                case TypeBonus.Multiplicator:
                    Manager_Gold.Instance.m_MultActif -= m_Multiplicator;
                    break;
                case TypeBonus.Add:
                    Manager_Gold.Instance.m_BonusActif -= m_Addition;
                    break;
                default:
                    break;
            }

        }
   
    }


    void ActionOnOrPassive(bool _isCanceled)
    {
        if (!_isCanceled)
        {
            switch (m_TypeBonus)
            {
                case TypeBonus.PerCent:
                    Manager_Gold.Instance.m_MultPassif += m_Percent / 10;
                    break;
                case TypeBonus.Multiplicator:
                    Manager_Gold.Instance.m_MultPassif += m_Multiplicator;
                    break;
                case TypeBonus.Add:
                    Manager_Gold.Instance.m_BonusPassif += m_Addition;
                    break;
                default:
                    break;
            }
        }
        else
        {
            switch (m_TypeBonus)
            {
                case TypeBonus.PerCent:
                    Manager_Gold.Instance.m_MultPassif -= m_Percent / 10;
                    break;
                case TypeBonus.Multiplicator:
                    Manager_Gold.Instance.m_MultPassif -= m_Multiplicator;
                    break;
                case TypeBonus.Add:
                    Manager_Gold.Instance.m_BonusPassif -= m_Addition;
                    break;
                default:
                    break;
            }

        }
        
    }
    #endregion

    IEnumerator TimerTimeLeft()
    {
        float _currentTime = 0;

        while (_currentTime < m_Timer)
        {
            _currentTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        if (this.transform.tag == "Movable")
        {
            Destroy(this.gameObject);
        }
        
        m_ManagerSpawn.GetComponent<Postulant_Spawn>().m_CurrentNbPostulant--;
        yield break;
    }

    public void Cancel()
    {
        switch (m_Impact)
        {
            case Impact.Actif:
                ActionOnActif(true);
                break;
            case Impact.Passif:
                ActionOnPassif(true);
                break;
            case Impact.OrActive:
                ActionOnOrActive(true);
                break;
            case Impact.OrPassive:
                ActionOnOrPassive(true);
                break;
        }
    }
}
