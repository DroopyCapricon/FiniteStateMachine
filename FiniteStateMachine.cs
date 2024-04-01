using UnityEngine;

public abstract class GameState
{
    public abstract void StartState(FiniteStateMachine FiniteStateMachine);
    public abstract void UpdateState(FiniteStateMachine FiniteStateMachine);
    public abstract void EndState(FiniteStateMachine FiniteStateMachine);
}

public class StartGame : GameState
{
    public override void EndState(FiniteStateMachine FiniteStateMachine)
    {
        FiniteStateMachine.ChangeState(FiniteStateMachine.RunGameState);
    }

    public override void StartState(FiniteStateMachine FiniteStateMachine)
    {
        FiniteStateMachine.startGame.Init(FiniteStateMachine);
    }

    public override void UpdateState(FiniteStateMachine FiniteStateMachine)
    {
        throw new System.NotImplementedException();
    }
}

public class Start
{
    public void Init(FiniteStateMachine FiniteStateMachine)
    {
        Debug.Log("Starting Game");
        FiniteStateMachine.StartGameState.EndState(FiniteStateMachine);
    }
}

public class RunGame : GameState
{
    public override void EndState(FiniteStateMachine FiniteStateMachine)
    {
        FiniteStateMachine.ChangeState(FiniteStateMachine.EndGameState);
    }

    public override void StartState(FiniteStateMachine FiniteStateMachine)
    {
        FiniteStateMachine.runGame.Init(FiniteStateMachine);
    }

    public override void UpdateState(FiniteStateMachine FiniteStateMachine)
    {
        throw new System.NotImplementedException();
    }
}

public class Run
{
    public void Init(FiniteStateMachine FiniteStateMachine)
    {
        Debug.Log("Running Game");
        FiniteStateMachine.StartGameState.EndState(FiniteStateMachine);
    }
}

public class EndGame : GameState
{
    public override void EndState(FiniteStateMachine FiniteStateMachine)
    {
        FiniteStateMachine.ChangeState(FiniteStateMachine.StartGameState);
    }

    public override void StartState(FiniteStateMachine FiniteStateMachine)
    {
        FiniteStateMachine.endGame.Init(FiniteStateMachine);
    }

    public override void UpdateState(FiniteStateMachine FiniteStateMachine)
    {
        throw new System.NotImplementedException();
    }
}

public class End
{
    public void Init(FiniteStateMachine FiniteStateMachine)
    {
        Debug.Log("Ending Game");
        FiniteStateMachine.EndGameState.EndState(FiniteStateMachine);
    }
}

public class FiniteStateMachine : MonoBehaviour
{
   
    #region States
    public StartGame StartGameState = new();
    public RunGame RunGameState = new();
    public EndGame EndGameState = new();
    #endregion States

    #region Behaviours
    [Header("GameState Behaviours")]
    public Start startGame;
    public Run runGame;
    public End endGame;
    #endregion Behaviours

    public bool inGame;
    public GameState currentState { get; private set; }

    private void Start()
    {
        Init(StartGameState);
    }

    public void Init(GameState state)
    {
        currentState = state;
        currentState.StartState(this);
    }

    public void ChangeState(GameState state)
    {
        currentState = state;
        currentState.StartState(this);
    }
}