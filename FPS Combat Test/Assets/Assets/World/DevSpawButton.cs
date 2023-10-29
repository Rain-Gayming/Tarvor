using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class DevSpawButton : HealthManager
{
    [BoxGroup("Spawner")]
    public GameObject toSpawn;
    [BoxGroup("Spawner")]
    public Vector3 spawnPoint;
    public override void Die()
    {
        GameObject newSpawn = Instantiate(toSpawn);
        newSpawn.transform.position = spawnPoint;
    }
}
