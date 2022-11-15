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

    [SerializeField] private int roomNumber = 1;

    [SerializeField] private bool isLastRoom = false;
    private void Awake()
    {
        roomNumber = 1;
        isLastRoom = false;
    }
    private void Start()
    {
        doorGameObjectArray = GameObject.FindGameObjectsWithTag("Door");
    }

    public void StartBattle()
    {
        Debug.Log("StartBattle");

        roomNumber += LevelManager.Instance.roomCleared;
        if (roomNumber == LevelManager.Instance.Room.Length)
        {
            Debug.Log(roomNumber);
            isLastRoom = true;
        }
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
        if (isLastRoom)
        {
            GUIManager.Instance.SetGameClearScene(true);
            GameManager.Instance.Pause(PauseMethods.NoPauseMenu);
        }
        else
        {
            PowerUpManager.Instance.StartPowerUpSelection();
            foreach (GameObject doorGameObject in doorGameObjectArray)
            {
                doorGameObject.SetActive(false);
            }
            LevelManager.Instance.roomCleared++;
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
