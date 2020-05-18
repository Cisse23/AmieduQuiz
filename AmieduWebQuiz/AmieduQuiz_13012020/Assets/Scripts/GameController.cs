using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Transactions;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    private QuizController quizController;
    private Quiz currentQuiz;
    private Question[] questionPool;
    private bool isQuizActive;
    private int questionIndex;
    private int playerScore;

    private List<GameObject> answerButtonGameObjects = new List<GameObject>();
    public SimpleObjectPool answerButtonObjectPool;
    public Transform answerButtonParent;
    public GameObject quizPanel;
    public GameObject quizEndPanel;

    public Text questionText;
    public Text scoreText;


    void Start()
    {
        quizController = FindObjectOfType<QuizController>();
        currentQuiz = quizController.GetCurrentQuiz();
        questionPool = currentQuiz.questions;

        playerScore = 0;
        questionIndex = 0;

        ShowQuestion();
        isQuizActive = true;

    }

private void ShowQuestion()
    {
        RemoveAnswerButtons();
        Question question = questionPool[questionIndex];
        questionText.text = question.question;

        for (int i = 0; i < question.answers.Length; i++)
        {
            GameObject answerButtonGameObject = answerButtonObjectPool.GetObject();
            answerButtonGameObjects.Add(answerButtonGameObject);
            answerButtonGameObject.transform.SetParent(answerButtonParent);

            AnswerButton answerButton = answerButtonGameObject.GetComponent<AnswerButton>();
            answerButton.SetUp(question.answers[i]);
        }
    }



    private void RemoveAnswerButtons()
    {
        while (answerButtonGameObjects.Count>0)
        {
            answerButtonObjectPool.ReturnObject(answerButtonGameObjects[0]);
            answerButtonGameObjects.RemoveAt(0);
        }
    }

    public void AnswerButtonClicked(bool isCorrect)
    {
        if (isCorrect)
        {
            playerScore += currentQuiz.pointsPerAnswer;
            scoreText.text = "Score: " + playerScore.ToString();
        }

        if (questionPool.Length > questionIndex + 1)
        {
            questionIndex++;
            ShowQuestion();
        }

        else
        {
            EndQuiz();
        }
    }

    public void EndQuiz()
    {
        isQuizActive = false;
        quizEndPanel.SetActive(true);
        quizPanel.SetActive(false);
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
