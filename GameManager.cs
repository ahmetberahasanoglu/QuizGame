using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    quiz quiz;
    winscreen endscreen;
    void Awake()
    {
        quiz = FindObjectOfType<quiz>();
        endscreen = FindObjectOfType<winscreen>();

    }
    void Start()
    {
       
        quiz.gameObject.SetActive(true);
        endscreen.gameObject.SetActive(false);
    }

   
    void Update()
    {
        if (quiz.testBittiMi == true)
        {
            quiz.gameObject.SetActive(false);
            endscreen.gameObject.SetActive(true);
            endscreen.tebriklermesajý();
           // Invoke("BolumuTekrarla", 5f);
        }
    }
    public void BolumuTekrarla()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
