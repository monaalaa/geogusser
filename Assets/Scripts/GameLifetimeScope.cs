
using UnityEngine;
using VContainer;
using VContainer.Unity;

public class GameLifetimeScope : LifetimeScope
{
    [SerializeField]  EmptyTile emptyTile;
    [SerializeField]  MinigameTile quizTile;
    protected override void Configure(IContainerBuilder builder)
    {
        // Register Game Managers
        //builder.Register<GameManager>(Lifetime.Singleton);
        builder.RegisterEntryPoint<GameManager>();
        // builder.Register<MinigameManager>(Lifetime.Singleton);
        // builder.Register<UIManager>(Lifetime.Singleton);

        // // Register Player Controller
        // builder.Register<PlayerController>(Lifetime.Singleton);

        // // Register Tile Prefabs (For example purposes)

        builder.RegisterInstance(emptyTile);
        builder.RegisterInstance(quizTile);
        builder.Register<BoardManager>(Lifetime.Singleton);
    }
}
