using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class QuizManagerWithStruct : MonoBehaviour
{
    private static QuizManagerWithStruct _instance;
    public static QuizManagerWithStruct Instance
    {
        get
        {
            return _instance;
        }
    }
    public QuestionAnserHolderSO QAContainer;
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
        public void GetValues(string p1, string p2, List<string> p3, int p4)
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
        CreateQuestionsAndAnswers();

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
}


