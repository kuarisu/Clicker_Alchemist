using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Postulant_Spawn : MonoBehaviour {

    private int m_NbMaxPostulant = 4;

    [SerializeField]
    List<Image> m_ListPostulant = new List<Image>();

    [SerializeField]
    int m_Timer;
    private int m_CurrentTime;


	
}
