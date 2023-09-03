using DG.Tweening;
using UnityEngine;

public class PutSteakOnFurnace : Interactable
{
    public CollectableType type;
    public Transform stackPlace;
    public override void Interact()
    {
        if (GameManager.Instance.inventory.currentType.Equals(type))
        {
            if (GameManager.Instance.inventory.holdingAmount>=1)
            {
                GameObject item = GameManager.Instance.collectablePlaceParent.transform.GetChild(
                    GameManager.Instance.collectablePlaceParent.transform.childCount - 1).gameObject;
                
                GameManager.Instance.inventory.holdingAmount--;
                
                item.transform.parent = stackPlace.parent;
                
                item.transform.DOMoveX(stackPlace.position.x, .25f);
                item.transform.DOMoveY(stackPlace.position.y, .25f);
                item.transform.DOMoveZ(stackPlace.position.z, .25f);

                stackPlace.localPosition += Vector3.up/2;
                GameManager.Instance.collectablePlace.transform.position -= Vector3.up / 2;
            }
            else
            {
                GameManager.Instance.inventory.currentType = CollectableType.Empty;
            }
        }
    }
}