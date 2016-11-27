using UnityEngine;
using System.Collections;

public class Request_No : MonoBehaviour {

    void OnColliderEnter(Collider col)
    {
        if (col.tag == "Request")
        {
            col.gameObject.GetComponent<Request_Impact>().Accepted();
        }
    }
}
