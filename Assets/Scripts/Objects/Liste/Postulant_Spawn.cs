using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Postulant_Spawn : MonoBehaviour {

    private int m_NbMaxPostulant = 4;
    [HideInInspector]
    public int m_CurrentNbPostulant = 0;

    [SerializeField]
    List<Image> m_ListPostulant = new List<Image>();

    [SerializeField]
    int m_TimerSpawn;
    private int m_CurrentTime;

    List<Image> m_ListOfCurrentPostulant = new List<Image>();

    void Start ()
    {
        StartCoroutine(SpawnCoroutine());
    }


    IEnumerator SpawnCoroutine()
    {
        while (true)
        {
            while (m_CurrentNbPostulant < m_NbMaxPostulant)
            {
                Image _newPostulant = Instantiate(m_ListPostulant[Random.Range(0, m_ListPostulant.Count - 1)]);
                _newPostulant.transform.parent = this.transform;
                //m_ListOfCurrentPostulant.Insert(m_CurrentNbPostulant - 1, _newPostulant);
                m_CurrentNbPostulant++;
                yield return new WaitForSeconds(m_TimerSpawn);
            }
            yield return new WaitForSeconds(0.5f);
        }
    }

	
}
