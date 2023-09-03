using System;
using System.Collections;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;

public class SheepDead : MonoBehaviour
{
    public float deadTime;
    public float currentTime;
    
    public GameObject steakPrefab;
    public GameObject smokeVFX;
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (currentTime < deadTime)
            {
                currentTime += Time.deltaTime;
                if (currentTime >= deadTime)
                {
                    GetComponent<SheepPatrol>().stopMove = true;
                    GetComponent<Animator>().SetBool("Dead",true);
                    StartCoroutine(transform.parent.GetComponent<SheepSpawner>().RespawnSheep());
                    StartCoroutine(DeadSheep());
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            
        }
    }

    IEnumerator DeadSheep()
    {
        yield return new WaitForSeconds(.5f);
        transform.DOScale(Vector3.zero, .25f).OnComplete(() =>
        {
            // play instantiate vfx
            Instantiate(smokeVFX, transform.position, smokeVFX.transform.rotation);
            // play instantiate sfx
            Instantiate(steakPrefab, transform.position, steakPrefab.transform.rotation);
        });
    }
}