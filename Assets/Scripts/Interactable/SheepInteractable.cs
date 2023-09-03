using System.Collections;
using DG.Tweening;
using UnityEngine;

public class SheepInteractable : Interactable
{
    public float deadAnimationTime;
    public float chopAnimationTime;
    public float resetSheepTime;

    public GameObject steakSpawnSmokeVFX;
    public GameObject steakPrefab;
    public override void Interact()
    {
        if (canInteractable)
        {
            canInteractable = false;
            GetComponent<SheepPatrol>().stopMove = true;
            GetComponent<Animator>().SetBool("Dead",true);
            GameManager.Instance.animator.SetBool("Choping",true);
            StartCoroutine(DeadAnimationTime());
            StartCoroutine(ChopAnimationTime());
            StartCoroutine(ResetSheepTime());
        }
    }

    IEnumerator DeadAnimationTime()
    {
        yield return new WaitForSeconds(deadAnimationTime);
        Instantiate(steakSpawnSmokeVFX,transform.position,steakSpawnSmokeVFX.transform.rotation);
        transform.DOScale(Vector3.zero, 1);
        
        yield return new WaitForSeconds(.1f);
        Instantiate(steakPrefab,transform.position,steakPrefab.transform.rotation);
    }

    IEnumerator ChopAnimationTime()
    {
        yield return new WaitForSeconds(chopAnimationTime/5);
        AudioManager.Instance.PlaySoundOneTime(AudioManager.Instance.audioData.chopSound,25f);
        yield return new WaitForSeconds((chopAnimationTime / 5)*4);
        GameManager.Instance.animator.SetBool("Choping",false);
    }

    IEnumerator ResetSheepTime()
    {
        yield return new WaitForSeconds(resetSheepTime);
        GetComponent<Animator>().SetBool("Dead",false);
        canInteractable = true;
        GetComponent<SheepPatrol>().stopMove = false;
        transform.DOScale(Vector3.one, .25f);
    }
}