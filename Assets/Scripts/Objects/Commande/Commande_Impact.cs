using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Commande_Impact : MonoBehaviour {

    [SerializeField]
    Text m_NameCommandeText;
    [SerializeField]
    Text m_DescriptionText;
    [SerializeField]
    Text m_PriceText;

    [SerializeField]
    int m_Price;
    [SerializeField]
    string m_NameCommande;
    [SerializeField]
    string m_Description;

    public Button M_YesButton;

    GameObject m_PotionNeeded;

    [SerializeField]
    int m_GainGold;

    [SerializeField]
    enum PotionType
    {
        T_01,
        T_02,
        T_03,
        T_04,
        T_05,
        T_06
    }

    [SerializeField]
    PotionType m_PotionTypeNeeded;

    void Awake()
    {
        
    }



    // Use this for initialization
    void Start () {

        switch (m_PotionTypeNeeded)
        {
            case PotionType.T_01:
                m_PotionNeeded = Manager_Potions.Instance.m_ListPotion[0];
                break;
            case PotionType.T_02:
                m_PotionNeeded = Manager_Potions.Instance.m_ListPotion[1];
                break;
            case PotionType.T_03:
                m_PotionNeeded = Manager_Potions.Instance.m_ListPotion[2];
                break;
            case PotionType.T_04:
                m_PotionNeeded = Manager_Potions.Instance.m_ListPotion[3];
                break;
            case PotionType.T_05:
                m_PotionNeeded = Manager_Potions.Instance.m_ListPotion[4];
                break;
            case PotionType.T_06:
                m_PotionNeeded = Manager_Potions.Instance.m_ListPotion[5];
                break;
            default:
                break;
        }

        m_NameCommandeText.text = m_NameCommande;
        m_DescriptionText.text = m_Description;
        m_PriceText.text = "Require: " + m_Price + " " + m_PotionNeeded.name;
	}
	
	// Update is called once per frame
	void Update () {
        if (m_Price <= m_PotionNeeded.GetComponent<Potion_Creation>().m_NbPotionCreated)
        {
            M_YesButton.GetComponent<Button>().interactable = true;
        }
        else
            M_YesButton.GetComponent<Button>().interactable = false;


    }

    public void Accepted()
    {
        Manager_Gold.Instance.m_CommandeGold = m_GainGold;
        Manager_Gold.Instance.FinalScoreCommande();
        m_PotionNeeded.GetComponent<Potion_Creation>().m_NbPotionCreated -= m_Price;
        this.GetComponentInParent<Commande_Spawn>().Destroying();
        this.GetComponentInParent<Commande_Spawn>().StartingTimers();
    }

}
