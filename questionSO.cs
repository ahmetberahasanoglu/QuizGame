using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Quiz sorusu", fileName = " Yeni Soru")]
public class questionSO : ScriptableObject
{
    [TextArea(2,6)]
    [SerializeField] string question = "Yeni soruyu girin";
    [TextArea(2, 6)]
    [SerializeField] string[] cevaplar=  new string[4];
    [SerializeField]int answerIndexNumber;

    public string SoruyuAl()
    {
        return question;// bu methodla birlikte bir veriyi baska bir classda göstertebiliriz ve istenmeyen deðiþiklikleri önleyebiliriz yani questionSO sorualým altýnda sorualým.question= "xasda" yapamayýz
        // yalnýzca sorualým.SoruyuAl() yaparak sorunun kopyasýný döndürdük
    }
    public int GetCorrectAnswerIndex()
    {
        return answerIndexNumber;
    }
    public string GetAnswer(int index)
    {
        return cevaplar[index];
    }
}
