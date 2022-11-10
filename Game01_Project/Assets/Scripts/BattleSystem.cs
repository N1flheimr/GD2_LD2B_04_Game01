using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using MoreMountains.TopDownEngine;
using MoreMountains.Tools;
using MoreMountains.Feedbacks;

public class BattleSystem : MonoBehaviour
{
    public enum State
    {
        Idle,
        Active
    }

    [SerializeField] private EnemySpawn[] enemySpawnArray;
    [SerializeField] private GameObject[] doorGameObjectArray;

    [SerializeField] private int enemyCount;
    [SerializeField] private float timeScale = 0.2f;
    [SerializeField] private float slowDownDuration = 1.1f;
    [SerializeField] private bool useLerp = true;
    [SerializeField] private float lerpSpeed = 6f;

    private void Start()
    {
        doorGameObjectArray = GameObject.FindGameObjectsWithTag("Door");
    }

    public void StartBattle()
    {
        Debug.Log("StartBattle");
        foreach (EnemySpawn enemySpawn in enemySpawnArray)
        {
            enemySpawn.Spawn();
            enemyCount++;
        }
        foreach (GameObject doorGameObject in doorGameObjectArray)
        {
            doorGameObject.SetActive(true);
        }
    }

    public IEnumerator BattleFinish()
    {
        MMTimeScaleEvent.Trigger(MMTimeScaleMethods.For, timeScale, slowDownDuration, useLerp, lerpSpeed, false);
        yield return new WaitForSecondsRealtime(1f);
        PowerUpManager.Instance.StartPowerUpSelection();
        foreach (GameObject doorGameObject in doorGameObjectArray)
        {
            doorGameObject.SetActive(false);
        }
    }

    public void enemyKilled()
    {
        enemyCount--;
        if (enemyCount <= 0)
        {
            StartCoroutine(BattleFinish());
        }
    }
}
