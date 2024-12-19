using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class winscreen : MonoBehaviour
{
    score sonSkor;
    
    [SerializeField] TextMeshProUGUI tebriklerMesajý;
    void Awake()
    {
        sonSkor = FindObjectOfType<score>();
    }
  
    public void tebriklermesajý()
    {
        tebriklerMesajý.text = "Tebrikler! %" + sonSkor.SkorHesapla() + " skor ile testi tamamladýnýz";
    }
}
