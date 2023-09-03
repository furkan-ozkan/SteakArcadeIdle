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
                GameObject money = Instantiate(moneyPrefab, GameManager.Instance.collectablePlace.transform.position+Vector3.up*2, moneyPrefab.transform.rotation);
                money.transform.DOScale(Vector3.one, .25f);
                money.transform.DOMove(-transform.right, .5f).OnComplete(() =>
                {
                    AudioManager.Instance.PlaySoundOneTime(AudioManager.Instance.audioData.moneySound,1f);
                    NeededMoney--;
                    GameManager.Instance.playerData.money--;
                    amountText.text = NeededMoney + "";
                    Destroy(money);
                    
                    if(NeededMoney.Equals(0))
                    {
                        propPrefab.SetActive(true);
                        propPrefab.transform.DOScale(Vector3.one, .5f);
                        gameObject.GetComponent<BoxCollider>().enabled = false;
                        transform.GetChild(1).DOScale(Vector3.zero, .5f);
                        if (NeededMoney<0)
                        {
                            GameManager.Instance.playerData.money -= NeededMoney;
                        }
                        Destroy(GetComponent<BoxCollider>());
                        Destroy(this);
                        Destroy(transform.GetChild(1).gameObject);
                    }
                });
            }
        }
    }
}