﻿
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Request_MainSpawn : MonoBehaviour {

    public List<GameObject> m_RequestList = new List<GameObject>();
    private GameObject m_CurrentRequest;

    [SerializeField]
    private float m_TimerSpawn; //Temps avant qu'une nouvelle commande spawn
    [SerializeField]
    private float m_TimerLasting; //Temps pendant laquelle la commande reste
    public float m_CurrentTime;


    [SerializeField]
    Canvas m_StockEx;
    public int m_TimerBonus;
    public int m_TempBonus;
    // Spawn tous les X secondes des commandes random selon liste (si commande une fois plus du tout après ?) au transform de l'empty game object Request.

    public GameObject m_TriggerRequest;

	// Use this for initialization
	void Start () {

        StartingTimers();    
	
	}
	
    public void StartingTimers()
    {
        m_CurrentTime = 0;
        StartCoroutine(TimeBeforeSpawn());
    }

    IEnumerator TimeBeforeSpawn()
    {
        while (m_CurrentTime < m_TimerSpawn )
        {
            m_CurrentTime++;
            yield return new WaitForSeconds(1);
        }

        m_CurrentTime = 0;
        SpawnNewRequest();
        StartCoroutine(TimeBeforeDestroy());
    }

    IEnumerator TimeBeforeDestroy()
    {
        
        Image _visualTimer = m_CurrentRequest.GetComponent<Request_Impact>().m_VisualTimer.GetComponent<Image>();
        while (m_CurrentTime < m_TimerLasting)
        {
            m_CurrentTime += Time.deltaTime;
            if(_visualTimer != null)
                _visualTimer.fillAmount = 1 - (((m_CurrentTime * 100) / m_TimerLasting) / 100);
            yield return new WaitForEndOfFrame();
        }
        Destroying();
        StartingTimers();
    }

    void SpawnNewRequest()
    {
        m_TriggerRequest.GetComponent<Trigger_Notification>().EnableNotification();
        m_CurrentRequest = (GameObject) Instantiate(m_RequestList[Random.Range(0, m_RequestList.Count - 1)], new Vector3(transform.position.x, transform.position.y, transform.position.z - 0.1f), transform.rotation);
        m_CurrentRequest.transform.parent = this.transform;
    }

    public void Destroying()
    {
        if (m_CurrentRequest != null)
        {
            m_TriggerRequest.GetComponent<Trigger_Notification>().DisableNotification();
            Destroy(m_CurrentRequest);
        }
    }

    public void TimerTempo()
    {
        StartCoroutine(TimerBonus());
    }

    IEnumerator TimerBonus()
    {
     
           m_StockEx.GetComponent<StockEx_BonusRequest>().m_CurrentBonus = m_TempBonus;

        yield return new WaitForSeconds(m_TimerBonus);

        m_StockEx.GetComponent<StockEx_BonusRequest>().m_CurrentBonus = 0;

        yield return null;
    }
}
