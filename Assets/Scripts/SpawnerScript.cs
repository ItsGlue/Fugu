using System.Collections;
using UnityEngine;

public class SpawnPrefabWithRandomDelay : MonoBehaviour
{
    public GameObject prefab;
    public float minDelay = 4f;
    public float maxDelay = 5f;

    void Start()
    {
        StartCoroutine(SpawnPrefabWithDelay());
    }

    IEnumerator SpawnPrefabWithDelay()
    {
        while (true)
        {
            float delay = Random.Range(minDelay, maxDelay);
            yield return new WaitForSeconds(delay);

            Instantiate(prefab, transform.position, transform.rotation);
        }
    }
}