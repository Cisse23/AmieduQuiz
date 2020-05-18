using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuizController : MonoBehaviour
{
    public Quiz[] allQuizzes;
    

    void Start()
    {
        DontDestroyOnLoad(GameObject);
        SceneManager.LoadScene("Menu");
    }

public Quiz GetCurrentQuiz()
    {
        return allQuizzes[0];
    }
}
