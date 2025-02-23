[System.Serializable]
public class Quiz
{
    public string ID;
    public int QuestionType;
    public string Question;
    public string CustomImageID;
    public Answer[] Answers;
    public int CorrectAnswerIndex;
}