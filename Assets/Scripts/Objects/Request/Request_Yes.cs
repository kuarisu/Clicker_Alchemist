using UnityEngine;
using System.Collections;

public class Request_Yes : MonoBehaviour {

    void OnColliderEnter (Collider col)
    {
        if(col.tag == "Request")
        {
            col.gameObject.GetComponent<Request_Impact>().Accepted();
        }
    }


}
