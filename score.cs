using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class score : MonoBehaviour
{
    int dogruCevaplar = 0;
    int gorulenSorular = 0;

   public int dogruCevaplarıAl()
    {
        return dogruCevaplar;
    }
    public void DogruCevapArttır()
    {
        dogruCevaplar++;
    }
    public int GorulenSorulariAl()
    {
        return gorulenSorular;
    }
    public void GorulenSorulariArttır()
    {
        gorulenSorular++;
    }
    public int SkorHesapla()
    {
        return Mathf.RoundToInt(dogruCevaplar / (float)gorulenSorular * 100);// 3/4 gibi bir degeri int degisken direkt 0 diye yazardı;
    }
}
