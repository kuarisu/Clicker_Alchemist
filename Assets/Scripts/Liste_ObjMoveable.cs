using UnityEngine;
using System.Collections;

public class Liste_ObjMoveable : MonoBehaviour {

    public bool Paysan = false;
    public bool Apprenti = false;
    public bool Alchimiste = false;
    public bool ChefGuild = false;

    public Mouse_Click m_MouseClick;

    [SerializeField]
    public bool m_Dragged = false;

    int m_isPaysan = 1;
    int m_isApprenti = 2;
    int m_isAlchimiste = 3;
    int m_isChefGuild = 4;

    [SerializeField]
    public int m_Identity = 0;

    void Start()
    {
        if (Paysan == true)
            m_Identity = m_isPaysan;

        if (Apprenti == true)
            m_Identity = m_isApprenti;

        if (Alchimiste == true)
            m_Identity = m_isAlchimiste;

        if (ChefGuild == true)
            m_Identity = m_isChefGuild;
    }

    public IEnumerator isMoving()
    {
        while(m_Dragged == true)
        {
            yield return new WaitForEndOfFrame();
        }


    }

}
