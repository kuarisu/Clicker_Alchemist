using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RessourcesName : MonoBehaviour {

    public string m_NameRessources;

    public Text m_NameResTxt;

    void Awake()
    {
        m_NameResTxt = GetComponent<Text>();
        m_NameResTxt.text = m_NameRessources;
    }
}
