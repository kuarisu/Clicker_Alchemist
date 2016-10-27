using UnityEngine;
using System.Collections;

public class Upgrade_UpPerCent : MonoBehaviour
{

    public string m_Name;
    public string m_Description;
    public int m_PerCent;
    public int m_Price;

    public GameObject m_TypePlant;

    [SerializeField]
    private int m_Level;

    public enum Impact
    {
        Actif,
        Passif,
        Employe,
        OrActive,
        OrPassive,
        Bourse,

    }

    public Impact m_Impact;


    public void Action()
    {
        switch (m_Impact)
        {
            case Impact.Actif:
                ActionOnActif();
                break;
            case Impact.Passif:
                ActionOnPassif();
                break;
            case Impact.Employe:
                ActionOnEmploye();
                break;
            case Impact.OrActive:
                ActionOnOrActive();
                break;
            case Impact.OrPassive:
                ActionOnOrPassive();
                break;
            case Impact.Bourse:
                ActionOnBourse();
                break;
        }
    }

    void ActionOnActif()
    {
        m_TypePlant.GetComponent<Plante_Type>().m_MultActif += m_PerCent / 10;
    }


    void ActionOnPassif()
    {
        m_TypePlant.GetComponent<Plante_Type>().m_MultPassif += m_PerCent / 10;
    }

    void ActionOnEmploye()
    {
        //Action sur la bourse
    }
    void ActionOnOrActive()
    {
        //Action sur l'or
    }
    void ActionOnOrPassive()
    {
        //Action sur l'or
    }
    void ActionOnBourse()
    {
        //Action sur la bourse
    }

}
