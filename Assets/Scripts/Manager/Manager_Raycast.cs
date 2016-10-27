using UnityEngine;
using System.Collections;

public class Manager_Raycast : MonoBehaviour
{
    [HideInInspector]
    public Classe_RayCast m_Instance;
    [HideInInspector]
    public string m_FoundTag;
    [HideInInspector]
    public GameObject m_ObjectMet;

    public static Manager_Raycast Instance;
    private void Awake()
    {
        if (Manager_Raycast.Instance != null)
        {
            Destroy(this.gameObject);
            return;
        }

        Manager_Raycast.Instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

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

            Manager_Input.Instance.CheckRayCast();

        }

    }

    public void RayCastUp()
    {
        Ray _ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit _hit;

        if (Physics.Raycast(_ray, out _hit))
        {
            m_FoundTag = _hit.collider.tag;
            m_ObjectMet = _hit.collider.gameObject;

            m_Instance.m_ObjectMet = m_ObjectMet;
            m_Instance.m_tag = m_FoundTag;

            Manager_Input.Instance.CheckRayCastUp();

        }

    }


    public void UpdateRayCast()
    {
        Ray _ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit m_HitUpdateRC;

        if (Physics.Raycast(_ray, out m_HitUpdateRC))
        {
            Manager_Input.Instance.m_stockedPostulant.GetComponent<Liste_ObjMoveable>().m_NewPos = m_HitUpdateRC.point;
        }

    }

}
