using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Upgrade_UpPerCent : MonoBehaviour
{
    public Text m_TextName;
    public Text m_TextDescription;
    public Text m_TextPrice;

    public string m_NameUp;
    public string m_Description;
    public int m_BasePrice;
    public int m_BasePercent;

    private int m_PerCent;
    private int m_Price;

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


    void Start()
    {
        m_PerCent = m_BasePercent;
        m_Price = m_BasePrice;
        m_TextName.text = m_NameUp;
        m_TextDescription.text = m_Description;
        m_TextPrice.text = m_Price.ToString();
    }

    public void Action()
    {
        if (m_Price <= Manager_Gold.Instance.m_FinalScore)
        {
            Manager_Sparing.Instance.Sparing(m_Price);

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

            LevelUp();
        }
    }

    #region Actions
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
        Manager_Gold.Instance.m_MultActif += m_PerCent / 10;
    }
    void ActionOnOrPassive()
    {
        Manager_Gold.Instance.m_MultPassif += m_PerCent / 10;
    }
    void ActionOnBourse()
    {
        //Action sur la bourse
    }
    #endregion

    void LevelUp()
    {
        m_Level++;
        m_Price = (m_BasePrice * m_BasePrice) * m_Level;
        m_PerCent = m_BasePercent * m_Level;


        m_TextPrice.text = m_Price.ToString();
    }
}
