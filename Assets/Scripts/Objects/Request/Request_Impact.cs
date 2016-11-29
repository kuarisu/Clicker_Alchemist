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
        // do stuff about the quest
        Debug.Log("hello yes");
        this.GetComponentInParent<Request_MainSpawn>().Destroying();
        this.GetComponentInParent<Request_MainSpawn>().StartingTimers();

    }

    public void Declined()
    {
        Debug.Log("hello no");
        this.GetComponentInParent<Request_MainSpawn>().Destroying();

    }
}
