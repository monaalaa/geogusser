using TMPro;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using System.Collections.Generic;
public class QuizUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI question;
    [SerializeField] List<AnswerUI> answerList;
    [SerializeField] GameObject quizPanel;

    public void SetQuiz(Quiz quiz)
    {
        question.text = quiz.Question;

;        for (int i = 0; i < quiz.Answers.Length; i++)
        {
            string imageID = quiz.Answers[i].ImageID;
            if (!string.IsNullOrEmpty(imageID))
            {
                LoadSpriteAsync(imageID, i);
            }
            else
            {
                answerList[i].SetAnswer(null, quiz.Answers[i].Text);
            }
            answerList[i].SetOnClickEvent(i == quiz.CorrectAnswerIndex ? OnRightAnswer : OnWrongAnswer);
        }
        quizPanel.SetActive(true);
    }
    private void OnRightAnswer()
    {
        Debug.Log("Great work");
        quizPanel.SetActive(false);
    }
    private void OnWrongAnswer()
    {
        Debug.Log("Try again later");
        quizPanel.SetActive(false);
    }
    private void LoadSpriteAsync(string imageID, int answerIndex)
    {
        AsyncOperationHandle<Sprite> handle = Addressables.LoadAssetAsync<Sprite>(imageID);

        handle.Completed += (op) =>
        {
            if (op.Status == AsyncOperationStatus.Succeeded)
            {
                answerList[answerIndex].SetAnswer(op.Result, "");
            }
            else
            {
                Debug.LogError($"Failed to load sprite with ImageID: {imageID}");
            }
        };
    }
}
