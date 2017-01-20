using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger_Notification : MonoBehaviour {

    [HideInInspector]
    public bool m_IsActive;

    [SerializeField]
    private GameObject m_Notification;

    void Start()
    {
        m_IsActive = true;
    }

	public void EnableNotification()
    {
        m_Notification.SetActive(true);
        m_IsActive = true;
    }

    public void DisableNotification()
    {
        m_Notification.SetActive(false);
        m_IsActive = false;
    }
}
