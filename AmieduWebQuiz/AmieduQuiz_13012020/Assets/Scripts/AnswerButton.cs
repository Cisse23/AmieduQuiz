using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnswerButton : MonoBehaviour
{
    public Text answerText;
    private Answer answer;
    private GameController gameController;

    void Start()
    {
        gameController = FindObjectOfType<GameController>();
    }

    public void SetUp(Answer data)
    {
        answer = data;
        answerText.text = answer.answer;

    }

    public void HandleClick()
    {
        gameController.AnswerButtonClicked(answer.isCorrect);
    }

}
