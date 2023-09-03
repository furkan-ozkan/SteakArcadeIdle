using UnityEngine;

public class PlayerWalkCommand : ICommand
{
    private FloatingJoystick _joystick;
    private GameObject _character;
    private Rigidbody _rigidbody;

    public PlayerWalkCommand(FloatingJoystick joystick, GameObject character, Rigidbody rigidbody)
    {
        _joystick = joystick;
        _character = character;
        _rigidbody = rigidbody;
    }
    public void Execute()
    {
        Vector3 walkDirection = 
            new Vector3(
                _joystick.Horizontal * GameManager.Instance.playerData.walkSpeed,
                0,
                _joystick.Vertical * GameManager.Instance.playerData.walkSpeed
            );
        
        Vector3 lookDirection = 
            new Vector3(
                _character.transform.position.x + walkDirection.x,
                _character.transform.position.y,
                _character.transform.position.z + walkDirection.z
            );
            
        _rigidbody.velocity = walkDirection;
        _character.transform.LookAt(lookDirection);
    }

    public void Undo()
    {
        
    }
}