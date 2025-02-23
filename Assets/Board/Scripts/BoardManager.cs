using System;
using VContainer;
public class BoardManager
{
    private readonly BoardGenerator _boardGenerator;
    private readonly IObjectResolver _objectResolver;

    public BoardManager(EmptyTile emptyTile,
        MinigameTile quizTile,
        IObjectResolver objectResolver,
        BoardType boardType)
    {

        _boardGenerator = CreateBoardGenerator(boardType);
        _boardGenerator.InitBoardData(emptyTile, quizTile, objectResolver);
    }

    public void InitializeBoard()
    {
        _boardGenerator.InitializeBoard();
    }
    private BoardGenerator CreateBoardGenerator(BoardType boardType)
    {
        return boardType switch
        {
            BoardType.Rectangle => new RectangleBoardGenerator(),
            BoardType.Wavy => new WavyBoardGenerator(),
            _ => throw new ArgumentOutOfRangeException()
        };
    }

    public Tile GetNextTile(Tile currentTile)
    {
        return _boardGenerator.GetNextTile(currentTile);
    }

    public Tile GetRandomTileInFirstRaw()
    {
        return _boardGenerator.GetRandomTileInFirstRaw();
    }

}

public enum BoardType
{
    Rectangle,
    Wavy
}
