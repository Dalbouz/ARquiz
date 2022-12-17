using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

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

    //public List<GameObject> Questions;//For old Instantiation
    public QuestionAnserHolderSO QAContainer;
    public GameObject QAPrefab;
    public QATemp CurrentActiveTemp;
    [SerializeField]
    private GameObject QATemp;
    public int CorrectAnswered = 0;
    [SerializeField]
    private int CurrentActiveIndex = 0;
    public GameObject ScoreBoard;
    [SerializeField]
    private int _waitBeforeLoadMM;
    [SerializeField]
    private List<Button> ButtonsToDisable;
    private AnswerButton AnswerButtonTemp;
    private struct Question
    { 
        public string questionCro;
        public string questionEng;
        public List<string> answers;
        public int correctAnswer;
        public void GetValues(string p1, string p2, List<string>p3, int p4)
        {
            questionCro = p1;
            questionEng = p2;
            answers = p3;
            correctAnswer = p4;
        }
    }
    private List<Question> QuestionContents;
    private void Awake()
    {
        if (_instance == null)
            _instance = this;
       
    }
    private void Start()
    {
        /*NEW*/
        CreateQuestionsAndAnswers();
        /*OLD*/
        //CreateQuestionsandAnswers();
    }

    private void CreateQuestionsAndAnswers()
    {
        QuestionContents = new List<Question>();
        Question tempContent = new Question();
        foreach (QuestionAnserSO questionAnser in QAContainer.QuestionAnserContainer)
        {
            tempContent.GetValues(questionAnser.QuestionCro, questionAnser.QuestionEng, questionAnser.Ansers, questionAnser.CorrectAnswer);
            QuestionContents.Add(tempContent);
        }
        Question QTemp;
        for (int i = 0; i < QuestionContents.Count; i++)
        {
            QTemp = QuestionContents[i];
            int RandomIndex = Random.Range(i, QuestionContents.Count);
            QuestionContents[i] = QuestionContents[RandomIndex];
            QuestionContents[RandomIndex] = QTemp;
        }
        AddQuestionToTemp();
    }

    /*NEW*/
    private void AddQuestionToTemp()
    {
        CurrentActiveTemp.Questions.Croatian = QuestionContents[CurrentActiveIndex].questionCro;
        CurrentActiveTemp.Questions.English = QuestionContents[CurrentActiveIndex].questionEng;
        CurrentActiveTemp.Questions.SetText();
        CurrentActiveTemp.CorrectAnser = QuestionContents[CurrentActiveIndex].correctAnswer;
        CurrentActiveTemp.ShuffleAnswers.Shuffle();
        for (int i = 0; i < CurrentActiveTemp.Ansers.Count; i++)
        {
            AnswerButtonTemp = CurrentActiveTemp.Ansers[i].GetComponent<AnswerButton>();
            CurrentActiveTemp.Ansers[i].GetComponent<TextMeshProUGUI>().text = AnswerButtonTemp.PositionInParent + "." + QuestionContents[CurrentActiveIndex].answers[i];
        }
    }
    /*NEW*/
    public void NextQuestion()
    {
        if (CurrentActiveIndex >= QuestionContents.Count - 1)
        {
            foreach (Button button in ButtonsToDisable)
            {
                button.interactable = false;
            }
            QATemp.SetActive(false);
            StartCoroutine(WaitAndLoadMM());
            return;
        }
        CurrentActiveIndex++;
        AddQuestionToTemp();
    }
    private IEnumerator WaitAndLoadMM()
    {
        ScoreBoard.SetActive(true);
        yield return new WaitForSeconds(_waitBeforeLoadMM);
        CorrectAnswered = 0;
        CurrentActiveIndex = 0;
        SceneManager.LoadScene("Glavni Meni");
    }

    /*OLD - remove QATemp prefab form Hierarchy*/
    //private void CreateQuestionsandAnswers()
    //{
    //    Questions = new List<GameObject>();
    //    foreach (QuestionAnserSO questionAnser in QAContainer.QuestionAnserContainer)
    //    {
    //        GameObject newQA = Instantiate(QAPrefab, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
    //        Questions.Add(newQA);
    //        newQA.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);
    //        QATemp QATemp = newQA.GetComponent<QATemp>();
    //        QATemp.Questions.Croatian = questionAnser.QuestionCro;
    //        QATemp.Questions.English = questionAnser.QuestionEng;
    //        QATemp.ShuffleAnswers.Shuffle();
    //        for (int i = 0; i < QATemp.Ansers.Count; i++)
    //        {
    //            QATemp.Ansers[i].GetComponent<TextMeshProUGUI>().text = QATemp.Ansers[i].GetComponent<AnswerButton>().PositionInParent + "." + questionAnser.Ansers[i];
    //        }
    //        QATemp.CorrectAnser = questionAnser.CorrectAnswer;
    //        newQA.SetActive(false);
    //    }
    //    GameObject temp;
    //    for (int i = 0; i < Questions.Count; i++)
    //    {
    //        temp = Questions[i];
    //        int RandomIndex = Random.Range(i, Questions.Count);
    //        Questions[i] = Questions[RandomIndex];
    //        Questions[RandomIndex] = temp;
    //    }
    //    Questions[CurrentActiveIndex].SetActive(true);
    //    CurrentActiveTemp = Questions[CurrentActiveIndex].GetComponent<QATemp>();
    //}
    ///*OLD*/
    //public void NextQuestion()
    //{
    //    Questions[CurrentActiveIndex].SetActive(false);
    //    if (CurrentActiveIndex >= Questions.Count - 1)
    //    {
    //        foreach (Button button in ButtonsToDisable)
    //        {
    //            button.interactable = false;
    //        }
    //        StartCoroutine(WaitAndLoadMM());
    //        return;
    //    }
    //    CurrentActiveIndex++;
    //    CurrentActiveTemp = Questions[CurrentActiveIndex].GetComponent<QATemp>();
    //    Questions[CurrentActiveIndex].SetActive(true);
    //}
}


