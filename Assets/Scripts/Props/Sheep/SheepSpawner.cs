using System.Collections;
using DG.Tweening;
using UnityEngine;

public class SheepSpawner : MonoBehaviour
{
    public GameObject sheepPrefab;

    public GameObject spawnedSheep;
    public SheepDead sheepDead;
    public SheepPatrol sheepPatrol;
    public Animator animator;
    private void Start()
    {
        SpawnSheep();
    }

    public void SpawnSheep()
    {
        spawnedSheep = Instantiate(sheepPrefab, transform.position, sheepPrefab.transform.rotation);
        sheepDead = spawnedSheep.GetComponent<SheepDead>();
        sheepPatrol = spawnedSheep.GetComponent<SheepPatrol>();
        animator = spawnedSheep.GetComponent<Animator>();
        // play spawn vfx
        // play spawn sfx
        spawnedSheep.transform.parent = transform;
        spawnedSheep.transform.DOScale(Vector3.one, .25f);
        spawnedSheep.GetComponent<SheepPatrol>().minX = transform.parent.parent.position.x - 3.5f;
        spawnedSheep.GetComponent<SheepPatrol>().maxX = transform.parent.parent.position.x + 3.5f;
        spawnedSheep.GetComponent<SheepPatrol>().minZ = transform.parent.parent.position.z - 3.5f;
        spawnedSheep.GetComponent<SheepPatrol>().maxZ = transform.parent.parent.position.z + 3.5f;
    }

    public IEnumerator RespawnSheep()
    {
        yield return new WaitForSeconds(3f);
        animator.SetBool("Dead",false);
        spawnedSheep.transform.DOScale(Vector3.one, .25f).OnComplete(() =>
        {
            sheepDead.currentTime = 0;
            sheepPatrol.stopMove = false; 
        });
    }
}