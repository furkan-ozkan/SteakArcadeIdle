using UnityEngine;

public class Collectable : MonoBehaviour
{
    public CollectableType type;
}

public enum CollectableType
{
    Empty,
    Steak
}