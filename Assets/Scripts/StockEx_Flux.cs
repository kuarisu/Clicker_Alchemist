using UnityEngine;
using System.Collections;

public class StockEx_Flux : MonoBehaviour {

    int m_Percent;
    int m_NbSelling;

    [SerializeField]
    int m_CurrentPrice;

    int m_NewPrice;

    [SerializeField]
    int m_TimeBtwChange;
    int m_CurrentTime = 0;


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

    TypePotion m_TypeOfPotion;

    // Use this for initialization
    void Start () {

        switch (m_TypeOfPotion)
        {
            case TypePotion.Potion01:
                m_NbSelling = Manager_Potions.Instance.m_ListPotion[0].GetComponent<Potion_Creation>().m_NbPotionCreated;
                break;
            case TypePotion.Potion02:
                m_NbSelling = Manager_Potions.Instance.m_ListPotion[1].GetComponent<Potion_Creation>().m_NbPotionCreated;
                break;
            case TypePotion.Potion03:
                m_NbSelling = Manager_Potions.Instance.m_ListPotion[2].GetComponent<Potion_Creation>().m_NbPotionCreated;
                break;
            case TypePotion.Potion04:
                m_NbSelling = Manager_Potions.Instance.m_ListPotion[3].GetComponent<Potion_Creation>().m_NbPotionCreated;
                break;
            case TypePotion.Potion05:
                m_NbSelling = Manager_Potions.Instance.m_ListPotion[4].GetComponent<Potion_Creation>().m_NbPotionCreated;
                break;
            case TypePotion.Potion06:
                m_NbSelling = Manager_Potions.Instance.m_ListPotion[5].GetComponent<Potion_Creation>().m_NbPotionCreated;
                break;
            default:
                break;
        }


	}
	

    IEnumerator m_Flux()
    {
        while (true)
        {
            yield return new WaitForSeconds(30);
            int _RandomValue = Random.Range(0, 99);
            if (_RandomValue >= 0 && _RandomValue < 64)
            {
                if(_RandomValue < 33)
                {
                    // +5%
                }
                else
                {
                    // -5%
                }
            }
            else if (_RandomValue >= 64 && _RandomValue < 88)
            {
                if(_RandomValue < 77)
                {
                    //+10%
                }
                else
                {
                    //-10%
                }
            }   
            else if(_RandomValue >= 88 && _RandomValue < 96)
            {
                if(_RandomValue < 93)
                {
                    //+20%
                }
                else
                {
                    //-20%
                }
            }  
            else if(_RandomValue >= 96 && _RandomValue <= 99)
            {
                if(_RandomValue < 98)
                {
                    //+40%
                }
                else
                {
                    //-40%
                }
            }



            yield return new WaitForEndOfFrame();
        }
    }

}
