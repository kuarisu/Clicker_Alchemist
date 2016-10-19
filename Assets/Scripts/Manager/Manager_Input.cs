using UnityEngine;
using System.Collections;

public class Manager_Input : MonoBehaviour
{
    public Classe_RayCast m_Instance;
    public Mouse_Click m_MouseClick;
    public string m_FoundTag;
    public GameObject m_ObjectMet;

    void Start()
    {
        m_Instance = new Classe_RayCast();
    }

    public void RayCast()
    {
        Ray _ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit _hit;

        if (Physics.Raycast(_ray, out _hit))
        {
            m_FoundTag = _hit.collider.tag;
            m_ObjectMet = _hit.collider.gameObject;

            m_Instance.m_ObjectMet = m_ObjectMet;
            m_Instance.m_tag = m_FoundTag;

            m_MouseClick.CheckRayCast();

        }

    }

}
