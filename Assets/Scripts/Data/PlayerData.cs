using UnityEngine;

[CreateAssetMenu(menuName = "Create/Player/PlayerData")]
public class PlayerData : ScriptableObject
{
    public int money=100000;
    public float walkSpeed;
    public int maxStackAmount;
}