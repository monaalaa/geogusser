using UnityEngine;
using VContainer;

public class QuizManager
{
    private const int numberOfMiniGames = 2;
    private Quiz flagQuiz;
    private Quiz textQuiz;
    private QuizUI quizUI;
    private QuizLoader flagQuizLoader;
    private QuizLoader textQuizLoader;
    [Inject]
    private void Construct(QuizUI quiz)
    {
        quizUI = quiz;
    }
    public void InitQuizs()
    {
        flagQuizLoader = new FlagQuizLoader();
        textQuizLoader = new TextQuizLoader();

        flagQuiz = flagQuizLoader.LoadQuizData();
        textQuiz = textQuizLoader.LoadQuizData();
    }

    public void StartQuiz()
    {
        int randomIndex = Random.Range(0, numberOfMiniGames);
        quizUI.SetQuiz(randomIndex == 0 ? flagQuiz : textQuiz);
    }
}
