
using UnityEngine;
using VContainer;
using VContainer.Unity;
using static UnityEngine.ResourceManagement.ResourceProviders.AssetBundleResource;

public class GameLifetimeScope : LifetimeScope
{
    [SerializeField]  EmptyTile emptyTile;
    [SerializeField]  MinigameTile quizTile;
    [SerializeField] PlayerController playerController;
    [SerializeField] QuizUI QuizUI;
    [SerializeField] BoardType boardType;
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
        builder.RegisterInstance(QuizUI);
        builder.RegisterInstance(boardType).As<BoardType>().AsSelf();
    }

    protected  void Start()
    {
        gameManager = Container.Resolve<GameManager>();
        gameManager.Start();
    }
}
