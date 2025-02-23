using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AnswerUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI asnwerText;
    [SerializeField] private Image asnwerImage;
    [SerializeField] Button answerButton;

    public void SetAnswer(Sprite sprite, string text)
    {
        asnwerText.text = text;
        asnwerImage.sprite = sprite;
    }
    public void SetOnClickEvent(UnityEngine.Events.UnityAction onClickAction)
    {
        answerButton.onClick.RemoveAllListeners();
        answerButton.onClick.AddListener(onClickAction);
    }
}
