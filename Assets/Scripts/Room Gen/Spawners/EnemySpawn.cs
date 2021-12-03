using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] GameObject[] enemies;

    public void SpawnEnemy()
    {
        int choice = Random.Range(0, enemies.Length);

        Instantiate(enemies[choice], transform.position, Quaternion.Euler(0, 0, 0));
        Destroy(gameObject);
    }
}
