using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawer : MonoBehaviour
{
    [SerializeField] float minSpawnDelay = 5f;
    [SerializeField] float maxSpawnDelay = 10f;
    [SerializeField] Attacker[] attackerPrefabArray;
    bool spawn = true;

    IEnumerator Start()
    {
        while (spawn)
        {
            yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));
            SpawnAttacker();
        }
    }

    public void StopSpawning()
    {
        spawn = false;
    }

    private void SpawnAttacker()
    {
        var attackerIndex = Random.Range(0, attackerPrefabArray.Length);
        Spawn(attackerPrefabArray[attackerIndex]);
    }

    private void Spawn(Attacker myattacker)
    {
        Attacker newAttacker =
            Instantiate(myattacker, transform.position, transform.rotation)
            as Attacker;
        newAttacker.transform.parent = transform;
    }
}
