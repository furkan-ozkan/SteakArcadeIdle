using System;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class SpawnerInteractable : Interactable
{
    public GameObject moneyPrefab;
    public GameObject propPrefab;
    public TextMeshProUGUI amountText;
    public int NeededMoney;

    private void Start()
    {
        amountText.text = NeededMoney + "";
    }

    public override void Interact()
    {
        if (GameManager.Instance.playerData.money > 0)
        {
            if (NeededMoney > 0)
            {
                NeededMoney--;
                GameManager.Instance.playerData.money--;
                GameObject money = Instantiate(moneyPrefab, GameManager.Instance.collectablePlace.transform.position+Vector3.up*2, moneyPrefab.transform.rotation);
                money.transform.DOScale(Vector3.one, .25f);
                
                money.transform.DOMoveX(transform.GetChild(0).position.x, .25f);
                money.transform.DOMoveZ(transform.GetChild(0).position.z, .25f);
                money.transform.DOMoveY(transform.GetChild(0).position.y, .25f).SetEase(Ease.InBack).OnComplete(() =>
                {
                    AudioManager.Instance.PlaySoundOneTime(AudioManager.Instance.audioData.moneySound,1f);
                    Destroy(money);
                });
                amountText.text = NeededMoney + "";
                if(NeededMoney.Equals(0))
                {
                    propPrefab.SetActive(true);
                    propPrefab.transform.DOScale(Vector3.one, .5f);
                    gameObject.GetComponent<BoxCollider>().enabled = false;
                    transform.GetChild(1).DOScale(Vector3.zero, .5f);
                        
                    Destroy(GetComponent<BoxCollider>());
                    Destroy(this);
                    Destroy(transform.GetChild(1).gameObject);
                }
            }
        }
    }
}