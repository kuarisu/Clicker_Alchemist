using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Request_MainSpawn : MonoBehaviour {

    public List<GameObject> m_RequestList = new List<GameObject>();
    private GameObject m_CurrentRequest;

    [SerializeField]
    private float m_TimerSpawn; //Temps avant qu'une nouvelle commande spawn
    [SerializeField]
    private float m_TimerLasting; //Temps pendant laquelle la commande reste
    public float m_CurrentTime; 

    // Spawn tous les X secondes des commandes random selon liste (si commande une fois plus du tout après ?) au transform de l'empty game object Request.


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
        while (m_CurrentTime < m_TimerLasting)
        {
            m_CurrentTime++;
            yield return new WaitForSeconds(1);
        }
        Destroying();
        StartingTimers();
    }

    void SpawnNewRequest()
    {
        m_CurrentRequest = (GameObject) Instantiate(m_RequestList[Random.Range(0, m_RequestList.Count - 1)], new Vector3(transform.position.x, transform.position.y, transform.position.z - 0.1f), transform.rotation);
        m_CurrentRequest.transform.parent = this.transform;
    }

    public void Destroying()
    {
        if(m_CurrentRequest != null)
        Destroy(m_CurrentRequest);
    }
}
