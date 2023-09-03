using System.Collections;
using UnityEngine;

public class VFXDestroyer : MonoBehaviour
{
    public float time;
    IEnumerator Start()
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }
}