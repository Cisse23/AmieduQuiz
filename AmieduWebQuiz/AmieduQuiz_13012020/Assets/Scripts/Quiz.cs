using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Quiz")]
public class Quiz : ScriptableObject
{

    public int pointsPerAnswer = 1;
    public Question[] questions;

}
