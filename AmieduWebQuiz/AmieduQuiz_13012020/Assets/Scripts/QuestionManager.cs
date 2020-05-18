using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionManager : MonoBehaviour
{

    public Question[] questions;
    public static QuestionManager qs;

    // Start is called before the first frame update

    void Awake()
    {
        qs = this;
        questions = Resources.LoadAll<Question>("Questions");
    }
    void Start()
    {
        
        foreach (Question question in questions)
        {
            Debug.Log(question.question);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
