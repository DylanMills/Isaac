using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawn : MonoBehaviour
{
    [SerializeField] GameObject[] items;

    public void SpawnItem()
    {
        int choice = Random.Range(0, items.Length);

        Instantiate(items[choice], transform.position, Quaternion.Euler(0, 0, 0));
        Destroy(gameObject);
    }
}
