using UnityEngine;
using System.Collections;

public class Request_Impact : MonoBehaviour {
    // Tout ce qui constitue la request (nom, description, demande, timer, impact sur le jeu si remplie)

    public bool m_isAccepted = true;
    public bool m_isActivated = false;

    // Use this for initialization
    void Start () {


    }
	
	// Update is called once per frame
	void Update () {

        
    }

    public void Accepted()
    {
        Debug.Log("hello yes");
    }

    public void Declined()
    {
        Debug.Log("hello no");
    }
}
