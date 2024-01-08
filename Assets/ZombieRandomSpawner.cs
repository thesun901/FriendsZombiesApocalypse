using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieRandomSpawner : MonoBehaviour
{
    public int maxRange = 18;
    int seriesCount = 0;
    public int seriesDemanded = 15; //number of "Random Spawn" series demanded to increase probability of spawning zombie
    public int minDistance = 20;
    public int maxDistance = 30;

    public GameObject zombieTemplate;

    public Transform[] heroes;


    // Start is called before the first frame update
    void Start()
    {
        maxRange = 18;
        InvokeRepeating("RandomSpawn", 1.0f, 1.5f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void RandomSpawn()
    {
        int i;
        i = Random.Range(1, maxRange);


        if(i == 1)
        {
            //randomly choose distance between spawned zombie and hero
            int randomValueX = Random.Range(minDistance, maxDistance);
            if (Random.Range(0, 2) == 1)
                randomValueX = randomValueX * -1;

            int randomValueY = Random.Range(minDistance, maxDistance);
            if (Random.Range(0, 2) == 1)
                randomValueY = randomValueY * -1;

            //picks random hero from list and spawns zombie nearby
            int a = Random.Range(0, heroes.Length);
            this.gameObject.transform.position = new Vector3(heroes[a].transform.position.x + randomValueX, heroes[a].transform.position.y + randomValueY);
            Instantiate(zombieTemplate, new Vector3(transform.position.x, transform.position.y, zombieTemplate.transform.position.z), Quaternion.identity);
        }

        seriesCount++;

        if(seriesCount >= seriesDemanded && maxRange > 5)
        {
            seriesCount = 0;
            maxRange--;
        }
    }
}
