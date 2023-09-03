using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    public float coolDown;
    public bool canInteractable = true;
    public abstract void Interact();
}