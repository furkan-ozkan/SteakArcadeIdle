using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class CollectPlaceInteractable : Interactable
{
    public List<Collectable> collectables = new List<Collectable>();
    public override void Interact()
    {
        if (collectables.Count>0)
        {
            GameManager.Instance.animator.SetBool("Carry",true);
            if (GameManager.Instance.inventory.currentType.Equals(CollectableType.Empty) 
                || GameManager.Instance.inventory.currentType.Equals(collectables[0].type))
            {
                if (GameManager.Instance.collectablePlaceParent.transform.childCount <= GameManager.Instance.playerData.maxStackAmount)
                {
                    foreach (var i in collectables)
                    {
                        GameManager.Instance.inventory.currentType = i.type;
                        GameManager.Instance.inventory.holdingAmount++;
                        i.gameObject.transform.parent = GameManager.Instance.collectablePlaceParent.transform;
                        i.transform.DOLocalRotate(Vector3.zero,.25f);
                        i.transform.DOLocalMove(GameManager.Instance.collectablePlace.transform.localPosition, .25f)
                            .OnComplete(() =>
                            {
                                GameManager.Instance.collectablePlace.transform.localPosition = Vector3.forward/2+Vector3.up+(Vector3.up*GameManager.Instance.inventory.holdingAmount/2);
                                collectables.Remove(i);
                                Destroy(gameObject);
                            });
                    }
                }
            }
        }
    }
}