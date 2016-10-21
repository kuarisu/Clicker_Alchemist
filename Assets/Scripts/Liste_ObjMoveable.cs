using UnityEngine;
using System.Collections;

public class Liste_ObjMoveable : MonoBehaviour {

    public GameObject m_Manager;
       // m_MouseClick; //To access data from MouseClick
   // public Manager_Raycast

    [HideInInspector]
    public bool m_Dragged = false; //Used to know if the Object is moving or not
    [HideInInspector]
    public bool m_Movable = true; //Used to know if the Object can move or not (if Postulant: can move, if Employé: can't move) 
    [HideInInspector]
    public Vector3 m_NewPos; //Used to update the position of the object while moving

    [HideInInspector]
    public enum Postulant
    {
        Paysan,
        Apprenti,
        Alchemiste,
        ChefGuilde
    } //For GD, to choose the type

    public Postulant m_PostulanType; //To show the enum in Inspector

    Vector3 m_PreviousPos; //Used to stock the origine position

    void Start()
    {
        StockPos();
        m_Dragged = false;
    }

    void StockPos()
    {
        m_PreviousPos = this.transform.position;
    }

    public IEnumerator isMoving()
    {
        this.gameObject.layer = 2;

        while (m_Dragged == true)
        {
            m_Manager.GetComponent<Manager_Raycast>().UpdateRayCast();
            gameObject.transform.position = m_NewPos;
            yield return new WaitForEndOfFrame();
        }
        this.gameObject.layer = 0;
    }

    public void BecomeEmploye()
    {
        Debug.Log("I'm an employee now");
        if (m_Manager.GetComponent<Manager_Raycast>().m_ObjectMet.GetComponent<Liste_EmployArea>().m_EmployeInArea.Count != 0)
        {
            foreach (GameObject Employe in m_Manager.GetComponent<Manager_Raycast>().m_ObjectMet.GetComponent<Liste_EmployArea>().m_EmployeInArea)
                Destroy(Employe);

            m_Manager.GetComponent<Manager_Raycast>().m_ObjectMet.GetComponent<Liste_EmployArea>().m_EmployeInArea.Clear();
        }

        transform.position = m_Manager.GetComponent<Manager_Raycast>().m_ObjectMet.transform.position;
        StockPos();
        m_Manager.GetComponent<Manager_Raycast>().m_ObjectMet.GetComponent<Liste_EmployArea>().m_EmployeInArea.Add(this.gameObject);
        m_Manager.GetComponent<Mouse_Click>().m_stockedPostulant = null;
        m_Movable = false;
    }

    public void ResetPost()
    {
        Debug.Log("Back to position !");
        transform.position = m_PreviousPos;
        m_Manager.GetComponent<Mouse_Click>().m_stockedPostulant = null;
    }

}
