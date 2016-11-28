using UnityEngine;
using System.Collections;

public class Request_No : MonoBehaviour {

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Movable")
        {
            col.gameObject.GetComponent<Request_Impact>().m_isActivated = true;
            col.gameObject.GetComponent<Request_Impact>().m_isAccepted = false;
        }
    }
    void OnTriggerExit(Collider col)
    {
        if (col.tag == "Movable")
        {
            col.gameObject.GetComponent<Request_Impact>().m_isActivated = false;
        }
    }
}
