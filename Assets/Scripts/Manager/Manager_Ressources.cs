using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System.Collections;

public class Manager_Ressources : MonoBehaviour
{
    [HideInInspector]
    public int m_PreviousScoreP1 = 0;
    [HideInInspector]
    public int m_PreviousScoreP2 = 0;
    [HideInInspector]
    public int m_PreviousScoreP3 = 0;
    [HideInInspector]
    public int m_PreviousScoreGold = 0;

    [HideInInspector]
    public string m_CurrentRessource;

    [HideInInspector]
    public int m_CurrentScore;

    [HideInInspector]
    public int m_PlanteQuantiy01;
    [HideInInspector]
    public int m_PlanteQuantiy02;
    [HideInInspector]
    public int m_PlanteQuantiy03;


    [HideInInspector]
    public int m_CurrentGoldScore;

    public int m_TimePlante = 1;
    public int m_TimeGold = 1;

    public Text m_TextPlant01;
    public Text m_TextPlant02;
    public Text m_TextPlant03;
    public Text m_TextGold;

    [HideInInspector]
    public int m_TypePlant;

    [SerializeField]
    public GameObject m_Plante_01;
    [SerializeField]
    public GameObject m_Plante_02;
    [SerializeField]
    public GameObject m_Plante_03;

    string m_Score01;
    string m_Score02;
    string m_Score03;
    string m_ScoreGolde;

    public static Manager_Ressources Instance;
    private void Awake()
    {
        if (Manager_Ressources.Instance != null)
        {
            Destroy(this.gameObject);
            return;
        }

        Manager_Ressources.Instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    void Start()
    {
        m_Score01 = m_TextPlant01.text;
        m_Score02 = m_TextPlant02.text;
        m_Score03 = m_TextPlant03.text;
        m_ScoreGolde = m_TextGold.text;
        StartCoroutine(PassifPlante());
        StartCoroutine(PassifGold());
        ChangeGoldScore();
        ChangeScore();
    }


    IEnumerator PassifPlante()
    {
        //CHANGER PAR UNE LISTE POUR POUVOIR RAJOUTER DE SPLANTES SI BESOIN.
        while (true)
        {
            
            m_Plante_01.GetComponent<Plante_Type>().ScorePassif(1);
            m_Plante_02.GetComponent<Plante_Type>().ScorePassif(1);
            m_Plante_03.GetComponent<Plante_Type>().ScorePassif(1);


            yield return new WaitForSeconds(m_TimePlante);
        }
    }

    IEnumerator PassifGold()
    {

        while (true)
        {
          
            Manager_Gold.Instance.IncreaseGoldPassif(0);

            yield return new WaitForSeconds(m_TimeGold);
        }
    }

    public void ChangeRessources()
    {
        switch (m_TypePlant)
        {
            case 0:
                m_CurrentRessource = m_Score01;
                Manager_Input.Instance.m_Selection.GetComponent<Plante_SelectPosition>().Position01();
                break;
            case 1:
                m_CurrentRessource = m_Score02;
                Manager_Input.Instance.m_Selection.GetComponent<Plante_SelectPosition>().Position02();
                break;
            case 2:
                m_CurrentRessource = m_Score03;
                Manager_Input.Instance.m_Selection.GetComponent<Plante_SelectPosition>().Position03();
                break;
            default:
                break;
        }

    }


    public void ChangeScoreClickArea()
    {

        switch (m_TypePlant)
        {
            case 0:
                m_TextPlant01.text = m_Score01 + m_CurrentScore;

                break;
            case 1:
                m_TextPlant02.text = m_Score02 + m_CurrentScore;

                break;
            case 2:
                m_TextPlant03.text = m_Score03 + m_CurrentScore;

                break;
            default:
                break;

        }
    }

    public void ChangeScore()
    { 
        m_TextPlant01.text = m_Score01 + m_PlanteQuantiy01;

        m_TextPlant02.text = m_Score02 + m_PlanteQuantiy02;
      
        m_TextPlant03.text = m_Score03 + m_PlanteQuantiy03;
    }

    public void ChangeGoldScore()
    {
        m_TextGold.text = m_ScoreGolde + m_CurrentGoldScore;
    }
}

