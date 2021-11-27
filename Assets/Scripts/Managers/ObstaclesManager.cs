using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesManager : MonoBehaviour
{
    // Singleton Desgin Pattern To Manage Obstacles Creation,speed and path
    private static ObstaclesManager _instance;
    public static ObstaclesManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<ObstaclesManager>();
            }
            return _instance;
        }
    }

    [SerializeField] private List<Obstacle> Enemies;
    [SerializeField] private float obstacleSpeed;
    
    [SerializeField] private float accelerationGameSpeedAmount=0.1f;
    [SerializeField] private float timesToAccelerateGame=10;

    [SerializeField] private float maxAccelerateGameValue = 0.4f;

    private float accelerationSpeed;
    private float obstaclesSpeed
    {
        get
        {
            if (GameManager.Instance.gameEnded)
            {
                return 0;
            }
            return (obstacleSpeed+ accelerationSpeed);
        }
    }
    [SerializeField] private float killObstacle;
    [SerializeField] private float minCreateTime, maxCreateTime;
   
    private float[] pathPositions=new float[3];
    private bool StopCreatingObstacles=false;
    private float TimeDeacreaseFactor= 0.015f;
    
    void Start()
    {
        pathPositions[0] = -GameManager.Instance.pathSidesValue;
        pathPositions[1] = 0;
        pathPositions[2] = GameManager.Instance.pathSidesValue;
        accelerationSpeed = 0;
        StartCoroutine(ObstacleCreator());
        InvokeRepeating("AccelrationGameSpeed", timesToAccelerateGame, timesToAccelerateGame);
    }

    public float KillObstacleTime() 
    {
        return killObstacle;
    }
    public float ObstacleSpeed()
    {
        return obstaclesSpeed;
    }

    private IEnumerator ObstacleCreator() 
    {
        float RandomCreatingTime=0;
        int RandomObstacleIndex = 0;
        while (true) 
        {
            RandomCreatingTime = Random.Range(minCreateTime,maxCreateTime);
            
            yield return new WaitForSeconds(RandomCreatingTime);
                RandomObstacleIndex = Random.Range(0, Enemies.Count);
                CreateObstacle(Enemies[RandomObstacleIndex].gameObject);
             DecreaseCreateTime();
            if (StopCreatingObstacles) 
            {
                yield break;
            }
        }
    }
    private void DecreaseCreateTime() 
    {
        if (maxCreateTime > 0.4f)
        {
            maxCreateTime -= TimeDeacreaseFactor;
        }
    }
    private void CreateObstacle(GameObject obstacle) 
    {
        Vector3 randomPos;
        int RandomPathIndex;
        RandomPathIndex = Random.Range(0, pathPositions.Length);
        randomPos = new Vector3(pathPositions[RandomPathIndex],0, 0);
        Instantiate(obstacle,transform.position+ randomPos, Quaternion.identity);
    }
    private void AccelrationGameSpeed()
    {
        if (accelerationSpeed < maxAccelerateGameValue)
        {
            accelerationSpeed += accelerationGameSpeedAmount;
        }
    }
    public void StopCreatingObstacle() 
    {
        StopCreatingObstacles = true;
    }
}
