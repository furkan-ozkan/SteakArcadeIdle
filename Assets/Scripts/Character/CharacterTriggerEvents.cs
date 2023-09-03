using System;
using UnityEngine;

public class CharacterTriggerEvents : MonoBehaviour
{
    public float globalCoolDownTime;
    public float currentGlobalCoolDownTime;
    public bool canInteract=true;
    public GameObject interactingObject;

    private void Update()
    {
        if (!canInteract)
        {
            currentGlobalCoolDownTime += Time.deltaTime;
            if (currentGlobalCoolDownTime >= globalCoolDownTime)
            {
                canInteract = true;
                currentGlobalCoolDownTime = 0;
                interactingObject = null;
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (canInteract && other.GetComponent<Interactable>() != null)
        {
            interactingObject = other.gameObject;
            Interactable interactable = other.GetComponent<Interactable>();
            globalCoolDownTime = interactable.coolDown;
            canInteract = false;
            interactable.Interact();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        /*
         * if (other.GetComponent<Interactable>() != null && other.gameObject.Equals(interactingObject))
        {
            canInteract = true;
            currentGlobalCoolDownTime = 0;
            interactingObject = null;
        }
         */
    }
}