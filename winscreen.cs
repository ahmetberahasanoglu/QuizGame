using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class winscreen : MonoBehaviour
{
    score sonSkor;
    
    [SerializeField] TextMeshProUGUI tebriklerMesaj�;
    void Awake()
    {
        sonSkor = FindObjectOfType<score>();
    }
  
    public void tebriklermesaj�()
    {
        tebriklerMesaj�.text = "Tebrikler! %" + sonSkor.SkorHesapla() + " skor ile testi tamamlad�n�z";
    }
}
