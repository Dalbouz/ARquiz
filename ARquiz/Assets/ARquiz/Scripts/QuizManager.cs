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
    private void Awake()
    {
        if (_instance == null)
            _instance = this;
    }
    private void Start()
    {
        ShuffleQuestions();
    }
    private void ShuffleQuestions()
    {
        QuestionAnserSO QTemp;
        for (int i = 0; i < QAContainer.QuestionAnserContainer.Count; i++)
        {
            QTemp = QAContainer.QuestionAnserContainer[i];
            int RandomIndex = Random.Range(i, QAContainer.QuestionAnserContainer.Count);
            QAContainer.QuestionAnserContainer[i] = QAContainer.QuestionAnserContainer[RandomIndex];
            QAContainer.QuestionAnserContainer[RandomIndex] = QTemp;
        }
        ChangeQuestion();
    }
    private void ChangeQuestion()
    {
        CurrentActiveTemp.Questions.Croatian = QAContainer.QuestionAnserContainer[CurrentActiveIndex].QuestionCro;
        CurrentActiveTemp.Questions.English = QAContainer.QuestionAnserContainer[CurrentActiveIndex].QuestionEng;
        CurrentActiveTemp.Questions.SetText();
        CurrentActiveTemp.CorrectAnser = QAContainer.QuestionAnserContainer[CurrentActiveIndex].CorrectAnswer;
        CurrentActiveTemp.ShuffleAnswers.Shuffle();
        for (int i = 0; i < CurrentActiveTemp.Ansers.Count; i++)
        {
            AnswerButtonTemp = CurrentActiveTemp.Ansers[i].GetComponent<AnswerButton>();
            CurrentActiveTemp.Ansers[i].GetComponent<TextMeshProUGUI>().text = AnswerButtonTemp.PositionInParent + "." + QAContainer.QuestionAnserContainer[CurrentActiveIndex].Ansers[i];
        }
    }
    public void NextQuestion()
    {
        if (CurrentActiveIndex >= QAContainer.QuestionAnserContainer.Count - 1)
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
        ChangeQuestion();
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


