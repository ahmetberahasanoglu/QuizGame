
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Timers;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class quiz : MonoBehaviour
{
    [Header("Sorular")]
    [SerializeField] TextMeshProUGUI textforsoru;
    [SerializeField] List<questionSO> sorular= new List<questionSO>();
    questionSO simdikiSoru;
    [Header("Cevaplar")]
    [SerializeField] GameObject[] cevapButonlarý;
    int dogruCevapIndex;
    bool cevapVerildiMi =true;//süre icerisinde cevap verilmediðinde de dogru cevabý göstermeli

    [Header("Buton Renkleri")]
    [SerializeField] Sprite defaultCevapSprite;
    [SerializeField] Sprite dogruCevapSprite;
    [Header("Zamanlayici")]
    [SerializeField]Image zamanlayiciImage;
    zamanlayýcý zamanlayiciGorseli;
    [Header("Score")]
    [SerializeField] TextMeshProUGUI scoreText;
    score scorekeeper;
    Image buttonimage;
    [Header("Ýlerleme Cubugu")]
    [SerializeField] Slider ilerlemeCubugu;
    public bool testBittiMi;
    winscreen kazanmaEkrani;

   

    void Awake()
    {
        scorekeeper = FindAnyObjectByType<score>();
        zamanlayiciGorseli = FindAnyObjectByType<zamanlayýcý>();
        ilerlemeCubugu.maxValue = sorular.Count;
        ilerlemeCubugu.value = 0;
    }
    void Update()
    {
        zamanlayiciImage.fillAmount = zamanlayiciGorseli.zamanDoldurucu;
        if (zamanlayiciGorseli.loadNextQuestion==true)
        {
            if (ilerlemeCubugu.value == ilerlemeCubugu.maxValue)
            {
                testBittiMi = true;
                return;
            }
            cevapVerildiMi = false;
            yeniSoruCagýr();
            zamanlayiciGorseli.loadNextQuestion = false;
        }
        else if (!cevapVerildiMi && !zamanlayiciGorseli.isAnsweringQuestion)
        {
            cevabýGoster(-1);
            ButtonDurumunuAyarla(false);
        }
        
    }
    public void cevapSecildi(int index)
    {
        cevapVerildiMi = true;
        cevabýGoster(index);
        ButtonDurumunuAyarla(false);
        /* for (int i = 0; i < cevapButonlarý.Length; i++)
         {
             buttonimage = cevapButonlarý[i].GetComponent<Image>();
             buttonimage.color = Color.black;
         }*/
        zamanlayiciGorseli.CancelTimer();
        scoreText.text = "Score: " + "%" + scorekeeper.SkorHesapla();

    }
    void cevabýGoster(int index)
    {
        if (index == simdikiSoru.GetCorrectAnswerIndex())
        {
            textforsoru.text = "Doðru Bildin!";
            buttonimage = cevapButonlarý[index].GetComponent<Image>();
            buttonimage.sprite = dogruCevapSprite;
            scorekeeper.DogruCevapArttýr();
        }
        else
        {
            dogruCevapIndex = simdikiSoru.GetCorrectAnswerIndex();
            string dogruCevap = simdikiSoru.GetAnswer(dogruCevapIndex);
            textforsoru.text = "Yanlýþ cevap.\n Dogru cevap " + dogruCevap + " olacaktý";
            buttonimage = cevapButonlarý[dogruCevapIndex].GetComponent<Image>();
            buttonimage.sprite = dogruCevapSprite;
        }
    }
    void yeniSoruCagýr()
    {
        if( sorular.Count > 0)
        {
            ButtonDurumunuAyarla(true);
            butonSpritelarýnýDuzenle();
            RastgeleSoruAl();
            
            SoruyuGoster();
            ilerlemeCubugu.value++;
            scorekeeper.GorulenSorulariArttýr();
        }
        
        
    }

   void RastgeleSoruAl()
    {
        int index = Random.Range(0, sorular.Count);
        simdikiSoru = sorular[index];
        if ( sorular.Contains(simdikiSoru))
        {
            sorular.Remove(simdikiSoru);
        }

    }
    /* prototip void RastgeleCevapAl()
    {
        
        for(int i=0; i<cevapButonlarý.Length; i++)
        {
            int index = Random.Range(0, cevapButonlarý.Length-1);
            cevapButonlarý[i] = cevapButonlarý[index];
        }
        
        

    }*/

    void SoruyuGoster()
    {
        textforsoru.text = simdikiSoru.SoruyuAl();
        for (int i = 0; i < cevapButonlarý.Length; i++)
        {
            TextMeshProUGUI buttontext = cevapButonlarý[i].GetComponentInChildren<TextMeshProUGUI>();
            buttontext.text = simdikiSoru.GetAnswer(i);
        }
    }
    void ButtonDurumunuAyarla(bool durum)
    {
        Button cevaplar;

        for (int i = 0; i < cevapButonlarý.Length; i++)
        {
            cevaplar = cevapButonlarý[i].GetComponent<Button>();
            cevaplar.interactable = durum;
        }
    }
    void butonSpritelarýnýDuzenle()
    {
        for(int i = 0; i < cevapButonlarý.Length; i++)
        {
            buttonimage = cevapButonlarý[i].GetComponent<Image>();
            buttonimage.sprite = defaultCevapSprite;

        }
    }
    
}
