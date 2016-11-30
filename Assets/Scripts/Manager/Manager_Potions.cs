using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Manager_Potions : MonoBehaviour {

    public static Manager_Potions Instance;

    public List<GameObject> m_ListPotion = new List<GameObject>();
    public List<int> m_ListStockPotion = new List<int>();

    private void Awake()
    {
        if (Manager_Gold.Instance != null)
        {
            Destroy(this.gameObject);
            return;
        }

        Manager_Potions.Instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

}
