
using UnityEngine;

public abstract class QuizLoader 
{
    protected string fileName;
    protected abstract void SetFileName();
    public Quiz LoadQuizData()
    {
        SetFileName();
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
}
