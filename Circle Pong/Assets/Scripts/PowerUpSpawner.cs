/* Deals with spawning all different powerups
 * adjustable varrible spawnWaitTime will determine
 * how long to wait before spawning another powerup.
 */
using System.Collections;
using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
    public GameObject[] PowerUps; //Public array for holding all different powerup prefabs
    public float spawnWaitTime;
    private GameObject pu = null;

    void Start()
    {
        StartCoroutine(Spawner());
    }

    IEnumerator Spawner()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnWaitTime);
            //if there is a powerup that exsists destroy it.
            if (PowerUps != null)
                Destroy(pu);
            //random number generated to determine which powerup is spawned
            float rand = Random.Range(0f, 1f);
            if (rand < .5)
            {
                pu = SpawnPowerUp(PowerUps[0]);
            }
            else if (rand >= .5)
            {
                pu = SpawnPowerUp(PowerUps[1]);
            }
        }
    }
    //Spawns powerup at random point inside a radius of 2
    private GameObject SpawnPowerUp(GameObject powerUp)
    {
        return Instantiate(powerUp, Random.insideUnitCircle * 2, Quaternion.identity);
    }
}
