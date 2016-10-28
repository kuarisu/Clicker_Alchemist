using UnityEngine;
using System.Collections;

public class Manager_Sparing : MonoBehaviour {

    public static Manager_Sparing Instance;

    private void Awake()
    {
        if (Manager_Sparing.Instance != null)
        {
            Destroy(this.gameObject);
            return;
        }

        Manager_Sparing.Instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    public void Sparing(int _price)
    {
        Manager_Gold.Instance.m_FinalScore -= _price;
        Manager_Ressources.Instance.m_CurrentGoldScore = Manager_Gold.Instance.m_FinalScore;
        Manager_Ressources.Instance.ChangeGoldScore();

    }

}
