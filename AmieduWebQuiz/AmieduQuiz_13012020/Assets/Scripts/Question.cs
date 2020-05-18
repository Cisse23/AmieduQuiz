using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName="Question")]
public class Question : ScriptableObject
{
   public string question;
   public Answer[] answer;
}

[System.Serializable]
public class Answer
{
    public string answer;
    public bool isCorrect;
}
