using UnityEngine;

public class PlayerStateManager : MonoBehaviour
{
    public PlayerBaseState currentState;

    private void Awake()
    {
        currentState = new PlayerIdleState();
    }

    private void Start()
    {
        currentState.EnterState(this);
    }

    private void Update()
    {
        currentState.UpdateState();
    }

    public void SwitchState(PlayerBaseState newState)
    {
        currentState.ExitState();
        currentState = newState;
        currentState.EnterState(this);
    }
}