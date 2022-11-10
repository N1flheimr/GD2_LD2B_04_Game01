using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.TopDownEngine;

public class EnemySpawn : MonoBehaviour
{
    private Vector3 spawnPoint;
    private Health health;
    [SerializeField] BattleSystem boundedEnemySpawner;


    private void Awake()
    {
        gameObject.SetActive(false);
        spawnPoint = transform.position;
        health = GetComponent<Health>();
    }

    private void Start()
    {
        health.OnDeath += Health_OnDeath;
    }

    public void Spawn()
    {
        transform.position = spawnPoint;
        gameObject.SetActive(true);
    }

    private void Health_OnDeath()
    {
        boundedEnemySpawner.enemyKilled();
    }
}
