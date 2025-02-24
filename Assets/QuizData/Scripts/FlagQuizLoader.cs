public class FlagQuizLoader : QuizLoader
{
    private const string flagFileName = "FlagQuizData";

    protected override void SetFileName()
    {
        fileName = flagFileName;
    }
}
