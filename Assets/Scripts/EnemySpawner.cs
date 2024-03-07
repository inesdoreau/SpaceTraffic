using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public void Spawn(Ennemy enemyToSpawn)
    {
        enemyToSpawn.SetPositionAndDirection(transform.position);
        Instantiate(enemyToSpawn);
    }
}
