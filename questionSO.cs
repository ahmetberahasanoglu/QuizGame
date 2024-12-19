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
        return question;// bu methodla birlikte bir veriyi baska bir classda g�stertebiliriz ve istenmeyen de�i�iklikleri �nleyebiliriz yani questionSO sorual�m alt�nda sorual�m.question= "xasda" yapamay�z
        // yaln�zca sorual�m.SoruyuAl() yaparak sorunun kopyas�n� d�nd�rd�k
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
