public class PlayerIdleState : PlayerBaseState
{
    private PlayerStateManager _manager;
    private FloatingJoystick _joystick;
    public override void EnterState(PlayerStateManager manager)
    {
        _manager = manager;
        _joystick = GameManager.Instance.joystick;
        GameManager.Instance.walkVFX.SetActive(false);
    }

    public override void UpdateState()
    {
        if (_joystick.Horizontal != 0 || _joystick.Vertical != 0)
            _manager.SwitchState(new PlayerMoveState());
    }

    public override void ExitState()
    {
        
    }
}