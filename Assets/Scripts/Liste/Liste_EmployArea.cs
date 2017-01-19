using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Liste_EmployArea : MonoBehaviour {

    public enum EmployArea
    {
        Paysan,
        Apprenti,
        Alchemiste,
        ChefGuilde
    }

    public EmployArea m_AreaType;

    public List<GameObject> m_EmployeInArea = new List<GameObject>();

    public Image m_Border;



}
