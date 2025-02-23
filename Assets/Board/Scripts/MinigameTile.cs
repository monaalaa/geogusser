using UnityEngine;
using VContainer;

public class MinigameTile : Tile
{
    private QuizManager _quizManager;

    [Inject]
    public void Construct(QuizManager quizManager)
    {
        _quizManager = quizManager;
    }
    public override void OnLand()
    {
        _quizManager.StartQuiz();
        Debug.Log("Player Land on through an Minigame tile!");
    }

    public override void OnPass()
    {
        Debug.Log("Player passed through an Minigame tile!");
    }
}

