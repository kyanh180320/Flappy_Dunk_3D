using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float timeToSpawn;
    float timeSpawnCounter;
    [SerializeField] private GameObject[] circle_advenced;
    [SerializeField] private GameObject[] circle_Minus30_And_Plus30;
    [SerializeField] private GameObject circle_0;
    [SerializeField] private GameObject circle_0_UpDown;
    int countToSpawn = 3;
    void Start()
    {
        countToSpawn = 0;
        timeSpawnCounter = 7;
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.instance.GetStateGame()) return;
        timeSpawnCounter += Time.deltaTime;

        if (timeSpawnCounter > timeToSpawn)
        {
            timeSpawnCounter = 0;
            this.Spawn();
        }
    }
    private void Spawn()
    {
        if (GameManager.instance.GetScore() <= 15)
        {
            SpawnObstacles(circle_0);
        }
        else if (GameManager.instance.GetScore() > 15 && GameManager.instance.GetScore() <= 25)
        {
            if (countToSpawn <= 0)
            {
                int random = Random.Range(0, circle_Minus30_And_Plus30.Length);
                SpawnObstacles(circle_Minus30_And_Plus30[random]);
                countToSpawn = 3;
            }
            else
            {
                SpawnObstacles(circle_0);
                countToSpawn--;
            }
        }
        else if(GameManager.instance.GetScore() > 25 && GameManager.instance.GetScore() <=35)
        {
            if(countToSpawn <= 0)
            {
                SpawnObstacles(circle_0_UpDown);
                countToSpawn = 3;
            }
            else
            {
                SpawnObstacles(circle_0);
                countToSpawn--;
            }

        }
        else
        {
            if(countToSpawn <= 0)
            {
                int random = Random.Range(0, circle_advenced.Length);
                SpawnObstacles(circle_advenced[random]);    
                countToSpawn = 3;
            }
            else
            {
                SpawnObstacles(circle_0);
                countToSpawn--;
            }
        }
        //int random = Random.Range(0, circlePrefab.Length);  
        //GameObject circle = Instantiate(circlePrefab[random], randomPos, Quaternion.identity);

    }
    void SpawnObstacles(GameObject gm)
    {
        Vector3 randomPos = new Vector3(5, Random.Range(-2, 2), 2);
        Instantiate(gm, randomPos, Quaternion.identity);
    }
    bool TrueSpawnAdvencedObstacles()
    {
        //if(GameManager.instance.)
        return true;
    }
}
