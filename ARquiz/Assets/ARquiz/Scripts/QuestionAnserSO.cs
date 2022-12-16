using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Q&A")]
public class QuestionAnserSO : ScriptableObject
{
    [TextArea]
    public string QuestionCro;

    [TextArea]
    public string QuestionEng;

    public List<string> Ansers;

    public int CorrectAnser;

}
