using DG.Tweening;
using UnityEngine;

public class MoneyPlaceInteractable : Interactable
{
    public GameObject moneyPrefab;
    public int moneyAmount;
    public override void Interact()
    {
        if (moneyAmount>0)
        {
            moneyAmount--;
            GameManager.Instance.playerData.money++;
            GameObject money = Instantiate(moneyPrefab, transform.position, moneyPrefab.transform.rotation);
            money.transform.DOScale(Vector3.one, .1f);
            money.transform.DOMoveX(GameManager.Instance.character.transform.position.x, .25f);
            money.transform.DOMoveZ(GameManager.Instance.character.transform.position.z, .25f);
            money.transform.DOMoveY(GameManager.Instance.character.transform.position.y+1.5f, .25f).SetEase(Ease.OutBack).OnComplete(() =>
            {
                AudioManager.Instance.PlaySoundOneTime(AudioManager.Instance.audioData.moneySound,1f);
                Destroy(money);
            });
        }
    }
}
