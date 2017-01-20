using UnityEngine;
using System.Collections;

public class Button_ClickArea : MonoBehaviour {

    Animator m_An;
    public Animation m_clipBounce;
    public ParticleSystem m_Particle;

    void Start()
    {
        m_Particle.Stop();
        m_An = GetComponent<Animator>();
    }

    public void Bounce()
    {
        m_An.SetTrigger("Bounce");
    }
}
