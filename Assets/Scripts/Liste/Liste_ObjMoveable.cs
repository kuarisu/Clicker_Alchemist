using UnityEngine;
using System.Collections;

public class Liste_ObjMoveable : MonoBehaviour {

    public GameObject m_Manager;

    [HideInInspector]
    public enum Postulant
    {
        Paysan,
        Apprenti,
        Alchemiste,
        ChefGuilde
    } //For GD, to choose the type

    public Postulant m_PostulanType; //To show the enum in Inspector



    public void BecomeEmploye()
    {
        Debug.Log("I'm an employee now");
        if (Manager_Raycast.Instance.m_ObjectMet.GetComponent<Liste_EmployArea>().m_EmployeInArea.Count != 0)
        {
            foreach (GameObject Employe in Manager_Raycast.Instance.m_ObjectMet.GetComponent<Liste_EmployArea>().m_EmployeInArea)
                Destroy(Employe);

            Manager_Raycast.Instance.m_ObjectMet.GetComponent<Liste_EmployArea>().m_EmployeInArea.Clear();
        }

        transform.position = Manager_Raycast.Instance.m_ObjectMet.transform.position;
        gameObject.GetComponent<Objects_Movable>().StockPos();
        Manager_Raycast.Instance.m_ObjectMet.GetComponent<Liste_EmployArea>().m_EmployeInArea.Add(this.gameObject);
        Manager_Input.Instance.GetComponent<Manager_Input>().m_StockedObject = null;
        gameObject.GetComponent<Objects_Movable>().m_Movable = false;
    }

}
