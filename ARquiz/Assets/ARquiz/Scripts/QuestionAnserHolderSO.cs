using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "QAHolder")]
public class QuestionAnserHolderSO : ScriptableObject
{
    public List<QuestionAnserSO> QuestionAnserContainer;
}

