using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Potion_Creation : MonoBehaviour
{
    public Text m_TextName;
    public Text m_TextPrice;
    public Text m_TextNbPotion;

    public string m_NameUp;

    public int m_NbPotionCreated = 0;

    public int m_BasePrice;
    private int m_PriceMain;
    private int m_PriceSecondary;
    private int m_NbPotion;



    private GameObject m_MainPlante;
    private GameObject m_SecondaryPlante;


    public List<GameObject> m_ListPlante = new List<GameObject>();



    public enum FirstPlante
    {
        Type01,
        Type02,
        Type03,
    }

    public FirstPlante m_FirstPlante;

    public enum SecondPlante
    {
        Type01,
        Type02,
        Type03,
    }

    public SecondPlante m_SecondPlante;


    void Start()
    {
        switch (m_FirstPlante)
        {
            case FirstPlante.Type01:
                m_MainPlante = m_ListPlante[0];
                break;
            case FirstPlante.Type02:
                m_MainPlante = m_ListPlante[1];
                break;
            case FirstPlante.Type03:
                m_MainPlante = m_ListPlante[2];
                break;
            default:
                break;
        }

        switch (m_SecondPlante)
        {
            case SecondPlante.Type01:
                m_SecondaryPlante = m_ListPlante[0];
                break;
            case SecondPlante.Type02:
                m_SecondaryPlante = m_ListPlante[1];
                break;
            case SecondPlante.Type03:
                m_SecondaryPlante = m_ListPlante[2];
                break;
            default:
                break;
        }

        m_TextName.text = m_NameUp;
        m_TextNbPotion.text = "x" + m_NbPotionCreated;
        m_TextPrice.text = m_PriceMain + " " + m_MainPlante.name + "\n" + m_PriceSecondary + " " + m_SecondaryPlante.name;

    }

    public void Action()
    {
        if (m_PriceMain <= m_MainPlante.GetComponent<Plante_Type>().m_FinalScore && m_PriceSecondary <= m_SecondaryPlante.GetComponent<Plante_Type>().m_FinalScore)
        {
            m_MainPlante.GetComponent<Plante_Type>().m_FinalScore -= m_PriceMain;
            m_SecondaryPlante.GetComponent<Plante_Type>().m_FinalScore -= m_PriceSecondary;
            m_NbPotionCreated++;
            m_TextNbPotion.text = "x " + m_NbPotionCreated;
        }
    }


    void Add()
    {

    }

}
