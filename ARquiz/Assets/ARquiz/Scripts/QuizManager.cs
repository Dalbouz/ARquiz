using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizManager : MonoBehaviour
{
    public QuestionAnserHolderSO QAContainer;

    public GameObject QAPrefab;
    [SerializeField]
    private GameObject QuestionParent;

    private void Start()
    {
        foreach (QuestionAnserSO questionAnser in QAContainer.QuestionAnserContainer)
        {
            GameObject newQA =  Instantiate(QAPrefab, transform.position, transform.rotation);
            newQA.transform.parent = QuestionParent.transform;
            QATemp QATemp = newQA.GetComponent<QATemp>();
            QATemp.Questions.Croatian = questionAnser.QuestionCro;
            QATemp.Questions.English = questionAnser.QuestionEng;
            for (int i = 0; i < QATemp.Ansers.Count; i++)
            {
                QATemp.Ansers[i].text = i+1 + "." + questionAnser.Ansers[i];
            }
            
        }
    }
}
