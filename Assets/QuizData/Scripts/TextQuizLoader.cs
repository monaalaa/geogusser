public class TextQuizLoader : QuizLoader
{
    private const string textFileName = "TextQuizData";

    protected override void SetFileName()
    {
        fileName = textFileName;
    }
}
