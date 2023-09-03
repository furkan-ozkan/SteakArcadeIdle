using UnityEngine;

public class PlayerMoveState : PlayerBaseState
{
    private PlayerStateManager _manager;
    private GameObject character;
    private Rigidbody _rigidbody;
    private FloatingJoystick _joystick;
    public override void EnterState(PlayerStateManager manager)
    {
        _manager = manager;
        character = GameManager.Instance.character;
        _rigidbody = character.GetComponent<Rigidbody>();
        _joystick = GameManager.Instance.joystick;
        
        GameManager.Instance.animator.SetBool("Walking",true);
        GameManager.Instance.walkVFX.SetActive(true);
    }

    public override void UpdateState()
    {
        ICommand command = new PlayerWalkCommand(_joystick,character,_rigidbody);
        GameManager.Instance.playerCommandInvoker.ExecuteCommand(command);

        if (_joystick.Horizontal == 0 && _joystick.Vertical == 0)
            _manager.SwitchState(new PlayerIdleState());
    }

    public override void ExitState()
    {
        _rigidbody.velocity = Vector3.zero;
        GameManager.Instance.animator.SetBool("Walking",false);
    }
}