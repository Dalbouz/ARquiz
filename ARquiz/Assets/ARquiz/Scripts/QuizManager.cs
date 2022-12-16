using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizManager : MonoBehaviour
{
    private static QuizManager _instance;
    public static QuizManager Instance
    {
        get
        {
            return _instance;
        }
    }

    public QuestionAnserHolderSO QAContainer;
    public GameObject QAPrefab;
    public List<GameObject> Questions;
    public QATemp CurrentActiveTemp;
    public int CorrectAnswered = 0;
    [SerializeField]
    private int CurrentActiveIndex = 0;

    private void Awake()
    {
        if (_instance == null)
            _instance = this;
    }
    private void Start()
    {
        Questions = new List<GameObject>();
        foreach (QuestionAnserSO questionAnser in QAContainer.QuestionAnserContainer)
        {
            GameObject newQA = Instantiate(QAPrefab, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
            Questions.Add(newQA);
            newQA.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);
            QATemp QATemp = newQA.GetComponent<QATemp>();
            QATemp.Questions.Croatian = questionAnser.QuestionCro;
            QATemp.Questions.English = questionAnser.QuestionEng;
            for (int i = 0; i < QATemp.Ansers.Count; i++)
            {
                QATemp.Ansers[i].text = i+1 + "." + questionAnser.Ansers[i];
            }
            QATemp.CorrectAnser = questionAnser.CorrectAnswer;
            newQA.SetActive(false);
        }

        for (int i = 0; i < Questions.Count; i++)
        {
            GameObject temp = Questions[i];
            int RandomIndex = Random.Range(i, Questions.Count);
            Questions[i] = Questions[RandomIndex];
            Questions[RandomIndex] = temp; 
        }
        Questions[CurrentActiveIndex].SetActive(true);
        CurrentActiveTemp = Questions[CurrentActiveIndex].GetComponent<QATemp>();
    }

    public void NextQuestion()
    {
        Questions[CurrentActiveIndex].SetActive(false);
        if(CurrentActiveIndex >= Questions.Count-1)
        {
            Debug.Log("Summary Screen" + "tocan broj odgovora" + CorrectAnswered );
            //otvori summary Screen
            CorrectAnswered = 0;
            CurrentActiveIndex = 0;
            return;
        }
        CurrentActiveIndex++;
        CurrentActiveTemp = Questions[CurrentActiveIndex].GetComponent<QATemp>();
        Questions[CurrentActiveIndex].SetActive(true);
    }
}
