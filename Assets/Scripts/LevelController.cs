using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] float waitToLoad = 3f;
    [SerializeField] GameObject winLabel;
    [SerializeField] GameObject loseLabel;
    int numberOfAttacker = 0;
    bool levelTimerFinished = false;

    private void Start()
    {
        winLabel.SetActive(false);
        loseLabel.SetActive(false);
    }

    public void AttackerSpawned()
    {
        numberOfAttacker++;
    }

    public void AttackerKilled()
    {
        numberOfAttacker--;
        if(numberOfAttacker <= 0 && levelTimerFinished)
        {
            StartCoroutine(HandleWinCondition());
        }
    }

    IEnumerator HandleWinCondition()
    {
        winLabel.SetActive(true);
        yield return new WaitForSeconds(waitToLoad);
        FindObjectOfType<LevelLoad>().LoadNextScene();
    }

    public void HandleLoseCondition()
    {
        loseLabel.SetActive(true);
        Time.timeScale = 0;
    }

    public void LevelTimerFinished()
    {
        levelTimerFinished = true;
        StopSpawners();
    }

    private void StopSpawners()
    {
        AttackerSpawer[] spawnerArray = FindObjectsOfType<AttackerSpawer>();
        foreach(AttackerSpawer spawer in spawnerArray)
        {
            spawer.StopSpawning();
        }
    }
}
