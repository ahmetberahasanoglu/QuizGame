using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class zamanlayıcı : MonoBehaviour
{
    [SerializeField] float soruyuCevaplamaSuresi = 30f;
    [SerializeField] float dogruCevabiGostermeSuresi = 10f;
    public bool isAnsweringQuestion = false;
    public float zamanDoldurucu;
    public bool loadNextQuestion;
    float zamanlayiciDegeri;
    //Image zamanlayiciImage;
    void Update()
    {
        zamanlayıcıyıDuzenle();
    }
    public void CancelTimer()
    {
        zamanlayiciDegeri = 0;
    }
    void zamanlayıcıyıDuzenle()
    {
      //  zamanlayiciImage = FindAnyObjectByType<Image>();
        zamanlayiciDegeri -= Time.deltaTime;
        if (isAnsweringQuestion == false)
        {
            if(zamanlayiciDegeri>0)
            {
                zamanDoldurucu = zamanlayiciDegeri / dogruCevabiGostermeSuresi;
               // zamanlayiciImage.fillAmount = zamanDoldurucu;
               // bu degil zamanlayiciImage.fillAmount -= (1 / dogruCevabiGostermeSuresi) * Time.deltaTime;
            }
            else 
            {
                zamanlayiciDegeri = soruyuCevaplamaSuresi;
                isAnsweringQuestion = true;
                loadNextQuestion = true;
            }
        }
        else
        {
            if (zamanlayiciDegeri >0)
            {
                zamanDoldurucu = zamanlayiciDegeri / soruyuCevaplamaSuresi;
              //  zamanlayiciImage = FindAnyObjectByType<Image>();
               // zamanlayiciImage.fillAmount = zamanDoldurucu;
              //  bu eskisi zamanlayiciImage.fillAmount -= (1 / soruyuCevaplamaSuresi) * Time.deltaTime;
            }
            else
            {
                zamanlayiciDegeri = dogruCevabiGostermeSuresi;
                isAnsweringQuestion = false;
            }
        }
        Debug.Log(isAnsweringQuestion+": "+ zamanlayiciDegeri + " = "+ zamanDoldurucu);
    }
}
