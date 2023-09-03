using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class FurnaceStand : MonoBehaviour
{
    public GameObject stackPlace;
    public GameObject plateStackPlace;
    public Transform furnacePlace;
    public GameObject completeStack;
    public bool isWorking;
    public GameObject item;
    public float defaultTime;
    public float currentTime;
    void Update()
    {
        if (stackPlace.transform.parent.childCount>1)
        {
            Debug.Log("0");
            if (!isWorking && !item)
            {
                isWorking = true;
                item = stackPlace.transform.parent.GetChild(stackPlace.transform.parent.childCount-1).gameObject;
                item.transform.DOMoveX(furnacePlace.position.x, .25f);
                item.transform.DOMoveZ(furnacePlace.position.z, .25f);
                item.transform.DOMoveY(furnacePlace.position.y, .25f).SetEase(Ease.InBack);
                stackPlace.transform.position -= Vector3.up/2;
                Debug.Log("1");
            }
            if (isWorking && item)
            {
                currentTime += Time.deltaTime;
                if (currentTime>=defaultTime)
                {
                    item.transform.DOScale(Vector3.zero, .25f);
                    item.transform.DOMoveX(plateStackPlace.transform.position.x, .25f);
                    item.transform.DOMoveZ(plateStackPlace.transform.position.z, .25f);
                    item.transform.DOMoveY(plateStackPlace.transform.position.y, .25f).SetEase(Ease.OutBack).OnComplete(() =>
                    {
                        Instantiate(completeStack, plateStackPlace.transform.position, completeStack.transform.rotation);
                        Destroy(item);
                    });
                    plateStackPlace.transform.position += Vector3.up/2;
                    item.transform.parent = null;
                    currentTime = 0;
                    isWorking = false;
                    Debug.Log("2");
                }
            }
        }
    }
}
