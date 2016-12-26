using UnityEngine;
using System.Collections;

public class Liste_ObjMoveable : MonoBehaviour {

    public GameObject m_Manager;

    
    public enum Postulant
    {
        Paysan,
        Apprenti,
        Alchemiste,
        ChefGuilde
    } //For GD, to choose the type

    
    public Postulant m_PostulanType; //To show the enum in Inspector

    [SerializeField]
    int m_Timer;

    bool m_UseTimer;



    public void BecomeEmploye()
    {
        this.transform.SetParent(Manager_Raycast.Instance.m_ObjectMet.transform);
        this.GetComponent<Postulant_Bonus>().Action();

        if (Manager_Raycast.Instance.m_ObjectMet.GetComponent<Liste_EmployArea>().m_EmployeInArea.Count != 0)
        {
            foreach (GameObject Employe in Manager_Raycast.Instance.m_ObjectMet.GetComponent<Liste_EmployArea>().m_EmployeInArea)
            {
                Employe.GetComponent<Postulant_Bonus>().Cancel();
                Destroy(Employe);
            }

            Manager_Raycast.Instance.m_ObjectMet.GetComponent<Liste_EmployArea>().m_EmployeInArea.Clear();
        }

        transform.position = Manager_Raycast.Instance.m_ObjectMet.transform.position;
        gameObject.GetComponent<Objects_Movable>().StockPos();

        Manager_Raycast.Instance.m_ObjectMet.GetComponent<Liste_EmployArea>().m_EmployeInArea.Add(this.gameObject);
        Manager_Input.Instance.GetComponent<Manager_Input>().m_StockedObject = null;

        gameObject.GetComponent<Objects_Movable>().m_Movable = false;
    }

    public void UseTimer()
    {
        StartCoroutine(UsingTimer());
    }

    IEnumerator UsingTimer()
    {
        float _currentTimer = 0;
        while (_currentTimer <= m_Timer)
        {
            if (m_UseTimer)
            {
                _currentTimer += 1 * Time.deltaTime;
                yield return new WaitForEndOfFrame();
            }
        }
        Destroy(this);
        yield return null;
    }

}


