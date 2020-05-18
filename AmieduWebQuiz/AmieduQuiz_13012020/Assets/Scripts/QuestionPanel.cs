using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuestionPanel : MonoBehaviour
{
    public GameObject answer;
    public Vector2 answerLocation;
    TextMeshPro questionTitle;
    // Start is called before the first frame update
    void Start()
    {
        questionTitle = transform.Find("Question").GetComponent<TextMeshPro>();
        answerLocation = transform.Find("AnswerLocation").position;
        questionTitle.text = QuestionManager.qs.questions[1].question;
        for (int i = 0; i < QuestionManager.qs.questions.Length; i++)
        {
            GameObject _answer = Instantiate(answer);
            _answer.transform.position = new Vector2(answerLocation.x, answerLocation.y - i);
            _answer.GetComponent<TextMeshPro>().text = QuestionManager.qs.questions[1].answer[i].answer;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
