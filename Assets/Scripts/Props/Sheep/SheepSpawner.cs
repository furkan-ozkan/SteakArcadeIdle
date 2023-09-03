using System.Collections;
using DG.Tweening;
using UnityEngine;

public class SheepSpawner : MonoBehaviour
{
    public GameObject sheepPrefab;

    public GameObject spawnedSheep;
    private void Start()
    {
        SpawnSheep();
    }

    public void SpawnSheep()
    {
        spawnedSheep = Instantiate(sheepPrefab, transform.position, sheepPrefab.transform.rotation);
        spawnedSheep.transform.parent = transform;
        spawnedSheep.transform.DOScale(Vector3.one, .25f);
        spawnedSheep.GetComponent<SheepPatrol>().minX = transform.parent.parent.position.x - 3.5f;
        spawnedSheep.GetComponent<SheepPatrol>().maxX = transform.parent.parent.position.x + 3.5f;
        spawnedSheep.GetComponent<SheepPatrol>().minZ = transform.parent.parent.position.z - 3.5f;
        spawnedSheep.GetComponent<SheepPatrol>().maxZ = transform.parent.parent.position.z + 3.5f;
    }
}