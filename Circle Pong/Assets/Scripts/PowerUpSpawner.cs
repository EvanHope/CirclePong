using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
    public GameObject[] PowerUps;
    public float spawnWaitTime;
    private GameObject pu = null;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawner());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator Spawner()
    {
        while (true)
        {

            yield return new WaitForSeconds(spawnWaitTime);
            if (PowerUps != null)
                Destroy(pu);
            float rand = Random.Range(0f, 1f);
            if(rand<.5)
            {
                pu = SpawnPowerUp(PowerUps[0]);
            }
            else if (rand >= .5)
            {
                pu = SpawnPowerUp(PowerUps[1]);
            }
        }
    }
    private GameObject SpawnPowerUp(GameObject powerUp)
    {
        return Instantiate(powerUp, Random.insideUnitCircle * 2, Quaternion.identity);
    }
}
