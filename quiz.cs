
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
    [SerializeField] GameObject[] cevapButonlar�;
    int dogruCevapIndex;
    bool cevapVerildiMi =true;//s�re icerisinde cevap verilmedi�inde de dogru cevab� g�stermeli

    [Header("Buton Renkleri")]
    [SerializeField] Sprite defaultCevapSprite;
    [SerializeField] Sprite dogruCevapSprite;
    [Header("Zamanlayici")]
    [SerializeField]Image zamanlayiciImage;
    zamanlay�c� zamanlayiciGorseli;
    [Header("Score")]
    [SerializeField] TextMeshProUGUI scoreText;
    score scorekeeper;
    Image buttonimage;
    [Header("�lerleme Cubugu")]
    [SerializeField] Slider ilerlemeCubugu;
    public bool testBittiMi;
    winscreen kazanmaEkrani;

   

    void Awake()
    {
        scorekeeper = FindAnyObjectByType<score>();
        zamanlayiciGorseli = FindAnyObjectByType<zamanlay�c�>();
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
            yeniSoruCag�r();
            zamanlayiciGorseli.loadNextQuestion = false;
        }
        else if (!cevapVerildiMi && !zamanlayiciGorseli.isAnsweringQuestion)
        {
            cevab�Goster(-1);
            ButtonDurumunuAyarla(false);
        }
        
    }
    public void cevapSecildi(int index)
    {
        cevapVerildiMi = true;
        cevab�Goster(index);
        ButtonDurumunuAyarla(false);
        /* for (int i = 0; i < cevapButonlar�.Length; i++)
         {
             buttonimage = cevapButonlar�[i].GetComponent<Image>();
             buttonimage.color = Color.black;
         }*/
        zamanlayiciGorseli.CancelTimer();
        scoreText.text = "Score: " + "%" + scorekeeper.SkorHesapla();

    }
    void cevab�Goster(int index)
    {
        if (index == simdikiSoru.GetCorrectAnswerIndex())
        {
            textforsoru.text = "Do�ru Bildin!";
            buttonimage = cevapButonlar�[index].GetComponent<Image>();
            buttonimage.sprite = dogruCevapSprite;
            scorekeeper.DogruCevapArtt�r();
        }
        else
        {
            dogruCevapIndex = simdikiSoru.GetCorrectAnswerIndex();
            string dogruCevap = simdikiSoru.GetAnswer(dogruCevapIndex);
            textforsoru.text = "Yanl�� cevap.\n Dogru cevap " + dogruCevap + " olacakt�";
            buttonimage = cevapButonlar�[dogruCevapIndex].GetComponent<Image>();
            buttonimage.sprite = dogruCevapSprite;
        }
    }
    void yeniSoruCag�r()
    {
        if( sorular.Count > 0)
        {
            ButtonDurumunuAyarla(true);
            butonSpritelar�n�Duzenle();
            RastgeleSoruAl();
            
            SoruyuGoster();
            ilerlemeCubugu.value++;
            scorekeeper.GorulenSorulariArtt�r();
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
        
        for(int i=0; i<cevapButonlar�.Length; i++)
        {
            int index = Random.Range(0, cevapButonlar�.Length-1);
            cevapButonlar�[i] = cevapButonlar�[index];
        }
        
        

    }*/

    void SoruyuGoster()
    {
        textforsoru.text = simdikiSoru.SoruyuAl();
        for (int i = 0; i < cevapButonlar�.Length; i++)
        {
            TextMeshProUGUI buttontext = cevapButonlar�[i].GetComponentInChildren<TextMeshProUGUI>();
            buttontext.text = simdikiSoru.GetAnswer(i);
        }
    }
    void ButtonDurumunuAyarla(bool durum)
    {
        Button cevaplar;

        for (int i = 0; i < cevapButonlar�.Length; i++)
        {
            cevaplar = cevapButonlar�[i].GetComponent<Button>();
            cevaplar.interactable = durum;
        }
    }
    void butonSpritelar�n�Duzenle()
    {
        for(int i = 0; i < cevapButonlar�.Length; i++)
        {
            buttonimage = cevapButonlar�[i].GetComponent<Image>();
            buttonimage.sprite = defaultCevapSprite;

        }
    }
    
}
