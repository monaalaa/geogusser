using UnityEngine;

public class QuizManager
{
    private Quiz flagQuiz;
    private Quiz textQuiz;
    private const string flagFileName = "FlagQuizData";
    private const string textFileName = "TextQuizData";
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
            Debug.Log("Quiz loaded successfully.");
        }
        else
        {
            Debug.LogError("Error: Quiz JSON file not found in Resources.");
        }
        return quiz;
    }

    public void StartQuiz()
    {
        Debug.Log($"{flagQuiz} Start quiz {textQuiz}");
    }
}
