using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager Instance;
    // Start is called before the first frame update
    [SerializeField] private float timeToSpawn;
    float timeSpawnCounter;
    [SerializeField] private GameObject[] circle_advenced;
    [SerializeField] private GameObject[] circle_Minus30_And_Plus30;
    [SerializeField] private GameObject circle_0;
    [SerializeField] private GameObject circle_0_UpDown;
    [SerializeField] private GameObject circle_Fever;
    [SerializeField] private GameObject circle_Score;
    [SerializeField] private GameObject circle_Lock;
    [SerializeField] private SpaceChallengeObject upSpaceChallenge;
    [SerializeField] private SpaceChallengeObject downSpaceChallenge;
    public List<SpawnRange> spaceChallengeSpawnRangeList;
    int Score;
    int countToSpawn = 3;
    bool checkSpawnCircleFever;

    private int circleScoreCooldown;

    private float localChanceToAppearSpaceChallenge = 1f;
    private float spaceChallengeTime = 5f;

    private int lockSpawned;
    private int lockTimer;
    private bool inLockSpawnEvent;
    
    private void Awake()
    {
        if (Instance != null & Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    void Start()
    {
        checkSpawnCircleFever = true;
        countToSpawn = 0;
        timeSpawnCounter = 7;
        Score = GameManager.instance.GetScore();
        Reset();
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.instance.GetStateGame()) return;
        //if (GameManager.instance.GetSateRunGame())
        {
            timeSpawnCounter += Time.deltaTime;

            if (timeSpawnCounter > timeToSpawn)
            {
                timeSpawnCounter = 0;
                this.Spawn();
            }
        }
    }

    private void Spawn()
    {
        if (inLockSpawnEvent)
        {
            lockTimer -= 1;
        }
        if (CheckSpawnSpaceChallenge())
        {
            Debug.Log("spawn space challenge");
            upSpaceChallenge.UpMoveDown();
            downSpaceChallenge.DownMoveUp();
        }

        if (GameManager.instance.GetScore() <= 15)
        {
            SpawnObstacles(circle_0);
        }
        else if ((GameManager.instance.GetScore() % 20 == 0))
        {
            SpawnObstacles(circle_Fever);
            if (lockSpawned <= 3 && CheckLockSpawnEvent())
            {
                inLockSpawnEvent = true;
            }
            //checkSpawnCircleFever = false;
        }
        else if (inLockSpawnEvent && lockTimer <= 0)
        {
            SpawnObstacles(circle_Lock);
            lockSpawned++;
            inLockSpawnEvent = false;
            lockTimer = 3;
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
        else if (GameManager.instance.GetScore() > 25 && GameManager.instance.GetScore() <= 35)
        {
            if (countToSpawn <= 0)
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
            if (countToSpawn <= 0)
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

    private bool CheckSpawnSpaceChallenge()
    {
        int currentScore = GameManager.instance.GetScore();
        foreach (var spawnRange in spaceChallengeSpawnRangeList)
        {
            if (currentScore >= spawnRange.startValue && currentScore <= spawnRange.endValue &&
                spawnRange.isSpawned == false)
            {
                spawnRange.isSpawned = true;
                return true;
            }
        }

        return false;
    }

    private bool CheckLockSpawnEvent()
    {
        int currentScore = GameManager.instance.GetScore();
        if (currentScore < 15)
        {
            return false;
        }

        if (upSpaceChallenge.isLive)
        {
            return false;
        }

        if (GameData.LockSpawnCooldown > 0)
        {
            return false;
        }

        return true;
    }

    public void Reset()
    {
        foreach (var spawnRange in spaceChallengeSpawnRangeList)
        {
            spawnRange.isSpawned = true;
        }

        lockSpawned = 0;
        lockTimer = 3;
        inLockSpawnEvent = false;
    }
}

[Serializable]
public class SpawnRange
{
    public int startValue;
    public int endValue;
    public bool isSpawned;
}