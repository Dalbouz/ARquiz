using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class QuizManagerWithPrefab : MonoBehaviour
{
    private static QuizManagerWithPrefab _instance;
    public static QuizManagerWithPrefab Instance
    {
        get
        {
            return _instance;
        }
    }

    public List<GameObject> Questions;//For old Instantiation
    public QuestionAnserHolderSO QAContainer;
    public GameObject QAPrefab;
    public QATemp CurrentActiveTemp;

    public int CorrectAnswered = 0;
    [SerializeField]
    private int CurrentActiveIndex = 0;
    public GameObject ScoreBoard;
    [SerializeField]
    private int _waitBeforeLoadMM;
    [SerializeField]
    private List<Button> ButtonsToDisable;
    private void Awake()
    {
        if (_instance == null)
            _instance = this;

    }
    private void Start()
    {
        CreateQuestionsandAnswers();
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
    private void CreateQuestionsandAnswers()
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
            QATemp.ShuffleAnswers.Shuffle();
            for (int i = 0; i < QATemp.Ansers.Count; i++)
            {
                QATemp.Ansers[i].GetComponent<TextMeshProUGUI>().text = QATemp.Ansers[i].GetComponent<AnswerButton>().PositionInParent + "." + questionAnser.Ansers[i];
            }
            QATemp.CorrectAnser = questionAnser.CorrectAnswer;
            newQA.SetActive(false);
        }
        GameObject temp;
        for (int i = 0; i < Questions.Count; i++)
        {
            temp = Questions[i];
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
        if (CurrentActiveIndex >= Questions.Count - 1)
        {
            foreach (Button button in ButtonsToDisable)
            {
                button.interactable = false;
            }
            StartCoroutine(WaitAndLoadMM());
            return;
        }
        CurrentActiveIndex++;
        CurrentActiveTemp = Questions[CurrentActiveIndex].GetComponent<QATemp>();
        Questions[CurrentActiveIndex].SetActive(true);
    }
}


