using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StockEx_Flux : MonoBehaviour {


    [SerializeField]
    Text m_CurrentPriceText;
    [SerializeField]
    Text m_CurrentPerCent;
    [SerializeField]
    Image m_Up;
    [SerializeField]
    Image m_Down;


    int m_NbSelling;
    int m_Index;

    [SerializeField]
    float m_CurrentPrice;
    float m_NewPrice;

    [SerializeField]
    int m_TimeBtwChange;
    int m_CurrentTime = 0;

    int m_Percent;

    [SerializeField]
    enum TypePotion
    {
        Potion01,
        Potion02,
        Potion03,
        Potion04,
        Potion05,
        Potion06,
    }
    [SerializeField]
    TypePotion m_TypeOfPotion;

    public int m_BonusPerCent = 0;

    // Use this for initialization
    void Start () {
        m_Up.enabled = false;
        m_Down.enabled = false;
        m_CurrentPerCent.text = "+ " + m_Percent + "%";
       // m_CurrentPriceText.text = "Price: " + m_CurrentPrice + " Gold";
        StartCoroutine(m_Flux());
        m_BonusPerCent = 0;
    }
	

    IEnumerator m_Flux()
    {
        while (true)
        {
            
            int _RandomValue = Random.Range(0, 99);
            if (_RandomValue >= 0 && _RandomValue < 64)
            {
                m_Percent = 5 + this.GetComponentInParent<StockEx_BonusRequest>().m_CurrentBonus;
                if(_RandomValue < 33)
                {
                    m_NewPrice = m_CurrentPrice + Mathf.Round((m_CurrentPrice / 100) * m_Percent);
                    m_CurrentPerCent.text = "+ " + m_Percent + "%";
                    m_Up.enabled = true;
                    m_Down.enabled = false;
                    m_CurrentPrice = m_NewPrice;
                    // +5%
                }
                else
                {

                    m_NewPrice = m_CurrentPrice - Mathf.Round((m_CurrentPrice / 100) * m_Percent);
                    m_CurrentPerCent.text = "- " + m_Percent + "%";
                    m_Up.enabled = false;
                    m_Down.enabled = true;
                    m_CurrentPrice = m_NewPrice;
                    // -5%
                }
            }
            else if (_RandomValue >= 64 && _RandomValue < 88)
            {
                m_Percent = 10 + this.GetComponentInParent<StockEx_BonusRequest>().m_CurrentBonus;
                if(_RandomValue < 77)
                {

                    m_NewPrice = m_CurrentPrice + Mathf.Round((m_CurrentPrice / 100) * m_Percent);
                    m_CurrentPerCent.text = "+ " + m_Percent + "%";
                    m_Up.enabled = true;
                    m_Down.enabled = false;
                    m_CurrentPrice = m_NewPrice;
                    //+10%
                }
                else
                {
                    m_NewPrice = m_CurrentPrice - Mathf.Round((m_CurrentPrice / 100) * m_Percent);
                    m_CurrentPerCent.text = "- " + m_Percent + "%";
                    m_Up.enabled = false;
                    m_Down.enabled = true;
                    m_CurrentPrice = m_NewPrice;
                    //-10%
                }
            }   
            else if(_RandomValue >= 88 && _RandomValue < 96)
            {
                m_Percent = 20 + this.GetComponentInParent<StockEx_BonusRequest>().m_CurrentBonus;
                if (_RandomValue < 93)
                {
                    m_NewPrice = m_CurrentPrice + Mathf.Round((m_CurrentPrice / 100) * m_Percent);
                    m_CurrentPerCent.text = "+ " + m_Percent + "%";
                    m_Up.enabled = true;
                    m_Down.enabled = false;
                    m_CurrentPrice = m_NewPrice;

                    //+20%
                }
                else
                {
                    m_NewPrice = m_CurrentPrice - Mathf.Round((m_CurrentPrice / 100) * m_Percent);
                    m_CurrentPerCent.text = "- " + m_Percent + "%";
                    m_Up.enabled = false;
                    m_Down.enabled = true;
                    m_CurrentPrice = m_NewPrice;
                    //-20%
                }
            }  
            else if(_RandomValue >= 96 && _RandomValue <= 99)
            {
                m_Percent = 40 + this.GetComponentInParent<StockEx_BonusRequest>().m_CurrentBonus;
                if (_RandomValue < 98)
                {
                    m_NewPrice = m_CurrentPrice + Mathf.Round((m_CurrentPrice / 100) * m_Percent);
                    m_CurrentPerCent.text = "+ " + m_Percent + "%";
                    m_Up.enabled = true;
                    m_Down.enabled = false;
                    m_CurrentPrice = m_NewPrice;
                    //+40%
                }
                else
                {
                    m_NewPrice = m_CurrentPrice - Mathf.Round((m_CurrentPrice / 100) * m_Percent);
                    m_CurrentPerCent.text = "- " + m_Percent + "%";
                    m_Up.enabled = false;
                    m_Down.enabled = true;
                    m_CurrentPrice = m_NewPrice;
                    //-40%
                }
            }
            m_CurrentPriceText.text = "Price: " + m_NewPrice + " Gold";


            yield return new WaitForSeconds(m_TimeBtwChange);
        }
    }

    public void PotionSelling()
    {
        switch (m_TypeOfPotion)
        {
            case TypePotion.Potion01:
                m_NbSelling = Manager_Potions.Instance.m_ListPotion[0].GetComponent<Potion_Creation>().m_NbPotionCreated;
                m_Index = 0;
                break;
            case TypePotion.Potion02:
                m_NbSelling = Manager_Potions.Instance.m_ListPotion[1].GetComponent<Potion_Creation>().m_NbPotionCreated;
                m_Index = 1;
                break;
            case TypePotion.Potion03:
                m_NbSelling = Manager_Potions.Instance.m_ListPotion[2].GetComponent<Potion_Creation>().m_NbPotionCreated;
                m_Index = 2;
                break;
            case TypePotion.Potion04:
                m_NbSelling = Manager_Potions.Instance.m_ListPotion[3].GetComponent<Potion_Creation>().m_NbPotionCreated;
                m_Index = 3;
                break;
            case TypePotion.Potion05:
                m_NbSelling = Manager_Potions.Instance.m_ListPotion[4].GetComponent<Potion_Creation>().m_NbPotionCreated;
                m_Index = 4;
                break;
            case TypePotion.Potion06:
                m_NbSelling = Manager_Potions.Instance.m_ListPotion[5].GetComponent<Potion_Creation>().m_NbPotionCreated;
                m_Index = 5;
                break;
            default:
                break;
        }

        if (m_NbSelling > 0)
        {
            
            Manager_Potions.Instance.m_ListPotion[m_Index].GetComponent<Potion_Creation>().m_NbPotionCreated -= m_NbSelling;
            Manager_Potions.Instance.m_ListPotion[m_Index].GetComponent<Potion_Creation>().ChangeNb();
            Manager_Gold.Instance.m_CommandeGold += ((int) m_NewPrice * m_NbSelling);
            Debug.Log(((int)m_NewPrice * m_NbSelling));
            Manager_Gold.Instance.FinalScoreCommande();
        }
    }

}
