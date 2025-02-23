using UnityEngine;
using VContainer;

public class QuizManager
{
    private Quiz flagQuiz;
    private Quiz textQuiz;
    private const string flagFileName = "FlagQuizData";
    private const string textFileName = "TextQuizData";
    private const int numberOfMiniGames = 2;
    private QuizUI quizUI;

    [Inject]
    private void Construct(QuizUI quiz)
    {
        quizUI = quiz;
    }
    public void InitQuizs()
    {
        flagQuiz = LoadQuizData(flagFileName);
        textQuiz = LoadQuizData(textFileName);
    }

    private Quiz LoadQuizData(string fileName)
    {
        Quiz quiz = new Quiz();
        TextAsset quizJson = Resources.Load<TextAsset>(fileName);

        if (quizJson != null)
        {
            quiz = JsonUtility.FromJson<Quiz>(quizJson.ToString());
        }
        else
        {
            Debug.LogError("Error: Quiz JSON file not found in Resources.");
        }
        return quiz;
    }

    public void StartQuiz()
    {
        int randomIndex = Random.Range(0, numberOfMiniGames);
        quizUI.SetQuiz(randomIndex == 0 ? flagQuiz : textQuiz);
    }
}
