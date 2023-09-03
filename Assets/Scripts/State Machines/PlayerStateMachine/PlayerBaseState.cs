using UnityEngine;

public abstract class PlayerBaseState : MonoBehaviour
{
    public abstract void EnterState(PlayerStateManager manager);
    public abstract void UpdateState();
    public abstract void ExitState();
}