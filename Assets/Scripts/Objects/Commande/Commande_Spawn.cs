using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Commande_Spawn : MonoBehaviour
{

    public List<GameObject> m_CommandeList = new List<GameObject>();
    private GameObject m_CurrentCommande;

    [SerializeField]
    private float m_TimerSpawn; //Temps avant qu'une nouvelle commande spawn
    [SerializeField]
    private float m_TimerLasting; //Temps pendant laquelle la commande reste
    private float m_CurrentTime;
    // Spawn tous les X secondes des commandes random selon liste (si commande une fois plus du tout après ?) au transform de l'empty game object Request.


    // Use this for initialization
    void Start()
    {

        StartingTimers();

    }

    public void StartingTimers()
    {
        m_CurrentTime = 0;
        StartCoroutine(TimeBeforeSpawn());
    }

    IEnumerator TimeBeforeSpawn()
    {
        while (m_CurrentTime < m_TimerSpawn)
        {
            m_CurrentTime++;
            yield return new WaitForSeconds(1);
        }

        m_CurrentTime = 0;
        SpawnNewCommande();
        StartCoroutine(TimeBeforeDestroy());
    }

    IEnumerator TimeBeforeDestroy()
    {
        Image _visualTimer = m_CurrentCommande.GetComponent<Commande_Impact>().m_VisualButton.GetComponent<Image>();
        while (m_CurrentTime < m_TimerLasting)
        {
            m_CurrentTime+= Time.deltaTime;
            _visualTimer.fillAmount = 1- (((m_CurrentTime * 100) / m_TimerLasting) / 100);
            
            yield return new WaitForEndOfFrame();
        }
        Destroying();
        StartingTimers();
    }

    void SpawnNewCommande()
    {
        m_CurrentCommande = (GameObject)Instantiate(m_CommandeList[Random.Range(0, m_CommandeList.Count - 1)], new Vector3(0, transform.position.y, 0), transform.rotation);
        m_CurrentCommande.transform.SetParent(this.transform, false);
    }

    public void Destroying()
    {
        if (m_CurrentCommande != null)
            Destroy(m_CurrentCommande);
    }
}
