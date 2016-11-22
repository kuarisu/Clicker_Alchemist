using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Plante_SellingValues : MonoBehaviour {


    public int m_NbSold = 1;
    public int m_NbGoldForOne= 10;
    public int m_NbClick = 0;

    public List<int> m_MultiplicatorList = new List<int>();



    //Faire une liste dont chaque index = un multiplicateur.
    //Faire une valeur de nb de click qui correspond à l'index de la liste. Si nbClick >= list.lenght alors nbClick (et index) = 0
    //quand vente, le script prendre la valeur m_NbSold * multiplicateur à l'index nbClick.
     
    public void ChangeNbSold()
    {
        if (m_NbClick >= m_MultiplicatorList.Count-1)
        {
            m_NbClick = 0;

        }
        else
        {
            m_NbClick++;
        }

    }


}
