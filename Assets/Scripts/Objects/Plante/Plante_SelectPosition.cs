using UnityEngine;
using DG.Tweening;
using System.Collections;

public class Plante_SelectPosition : MonoBehaviour {


    public GameObject m_Plante01;
    public GameObject m_Plante02;
    public GameObject m_Plante03;

    [HideInInspector]
    public Vector3 m_position01;
    [HideInInspector]
    public Vector3 m_position02;
    [HideInInspector]
    public Vector3 m_position03;
    // Use this for initialization
    void Start () {

        m_position01 = m_Plante01.transform.position;
        m_position02 = m_Plante02.transform.position;
        m_position03 = m_Plante03.transform.position;

	}
	

    public void Position01()
    {
        transform.DOMove(m_position01 + new Vector3(0,0,0.01f), 0.2f);
    }

    public void Position02()
    {
        transform.DOMove(m_position02 + new Vector3(0, 0, 0.01f), 0.2f);
    }

    public void Position03()
    {
        transform.DOMove(m_position03 + new Vector3(0,0, 0.01f), 0.2f);
    }


}
