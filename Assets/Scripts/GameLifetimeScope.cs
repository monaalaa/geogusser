
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
        // builder.Register<RollDiceUI>(Lifetime.Singleton);
        builder.Register<PlayersManager>(Lifetime.Singleton);
        // builder.Register<MinigameManager>(Lifetime.Singleton);

        builder.Register<BoardManager>(Lifetime.Singleton);

        builder.RegisterInstance(emptyTile);
        builder.RegisterInstance(quizTile);
        builder.RegisterComponentInNewPrefab(playerController, Lifetime.Transient);
        
    }

    protected  void Start()
    {
        gameManager = Container.Resolve<GameManager>();
        gameManager.Start();
    }
}
