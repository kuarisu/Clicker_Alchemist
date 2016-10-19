using UnityEngine;
using System.Collections;

public class Button_ClickArea : MonoBehaviour {

    Animator m_An;
    public Animation m_clipBounce;

    void Start()
    {
        m_An = GetComponent<Animator>();
    }

    public void Bounce()
    {
        Debug.Log("hello");
        m_An.SetTrigger("Bounce");
    }
}
