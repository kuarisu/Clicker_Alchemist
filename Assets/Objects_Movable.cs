using UnityEngine;
using System.Collections;

public class Objects_Movable : MonoBehaviour {

    [HideInInspector]
    public bool m_Dragged = false; //Used to know if the Object is moving or not
    [HideInInspector]
    public Vector3 m_NewPos; //Used to update the position of the object while moving
    [HideInInspector]
    public bool m_Movable = true; //Used to know if the Object can move or not (if Postulant: can move, if Employé: can't move) 


    Vector3 m_PreviousPos; //Used to stock the origine position
    Vector3 m_InitialPos;

    public enum Type
    {
        Postulant,
        Request,
    }

    public Type m_TypeMovableObject;

    void Start()
    {
        StockPos();
        m_Dragged = false;
    }

    public void StockPos()
    {
        m_PreviousPos = transform.position;
    }

    public IEnumerator isMoving()
    {
        m_InitialPos = transform.position;
        this.gameObject.layer = 2;

        while (m_Dragged == true)
        {
            if (m_TypeMovableObject == Type.Request)
            {
                Vector3 m_MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector3 m_AllowedPos = m_MousePos - m_InitialPos;
                m_AllowedPos = Vector3.ClampMagnitude(m_AllowedPos, 3);
                transform.position = new Vector3(m_InitialPos.x + m_AllowedPos.x, transform.position.y, transform.position.z);
            }
            if (m_TypeMovableObject == Type.Postulant)
            {
                Manager_Raycast.Instance.UpdateRayCast();
                gameObject.transform.position = m_NewPos;
            }
            yield return new WaitForEndOfFrame();
        }
        this.gameObject.layer = 0;
    }


    public void ResetPost()
    {
        Debug.Log("Back to position !");
        transform.position = m_PreviousPos;
        Manager_Input.Instance.GetComponent<Manager_Input>().m_StockedObject = null;
    }
}
