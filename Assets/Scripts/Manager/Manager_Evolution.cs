using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager_Evolution : MonoBehaviour {

    [SerializeField]
    private List<GameObject> m_ListEvolve = new List<GameObject>();
    [SerializeField]
    private List<int> m_ListGoldMini = new List<int>();


    [SerializeField]
    private GameObject m_TriggerList;

    private int m_IndexNbEvolve;
    private int m_IndexNbGold;

    // Use this for initialization
    void Start ()
    {
        m_IndexNbEvolve = 0;
        StartCoroutine(CheckingGold());
	}
	
    IEnumerator CheckingGold()
    {
        while (true)
        {
            if(Manager_Gold.Instance.m_FinalScore > m_ListGoldMini[m_IndexNbGold] )
            {
                if(m_IndexNbEvolve == 4 || m_IndexNbEvolve == 6 )
                {
                    m_TriggerList.GetComponent<Trigger_Notification>().EnableNotification();
                }
                m_ListEvolve[m_IndexNbEvolve].gameObject.SetActive(true);
                m_IndexNbEvolve++;
                m_IndexNbGold++;
            }
            
            yield return new WaitForSeconds(0.2f);
        }
    }
	
}
