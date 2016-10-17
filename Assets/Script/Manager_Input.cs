using UnityEngine;
using System.Collections;

public class Manager_Input : MonoBehaviour
{

    public void CheckRayCast()
    {
        Ray _ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit _hit;

    }

//    if (Physics.Raycast(_ray, out _hit))
//        {
//            if (_hit.collider.tag == "TriggerList")
//            {
//                m_MainScreen.GetComponent<Screen_Slide>().LerpList();
//    Debug.Log("hello");
//            }

//            if (_hit.collider.tag == "TriggerRP")
//            {
//                m_MainScreen.GetComponent<Screen_Slide>().LerpRP();
//Debug.Log("hello encore");
//            }
//        }
}
