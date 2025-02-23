
using UnityEngine;
using VContainer;
using VContainer.Unity;

public class GameLifetimeScope : LifetimeScope
{
    [SerializeField]  EmptyTile emptyTile;
    [SerializeField]  MinigameTile quizTile;
    [SerializeField] PlayerController playerController;
    private GameManager gameManager;
    protected override void Configure(IContainerBuilder builder)
    {
        builder.Register<GameManager>(Lifetime.Singleton);
        builder.Register<PlayersManager>(Lifetime.Singleton);
        builder.Register<QuizManager>(Lifetime.Singleton);
        builder.Register<BoardManager>(Lifetime.Singleton);

        builder.RegisterInstance(emptyTile);
        builder.RegisterInstance(quizTile);
        builder.RegisterInstance(playerController);
    }

    protected  void Start()
    {
        gameManager = Container.Resolve<GameManager>();
        gameManager.Start();
    }
}
