using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesManager : MonoBehaviour
{
    [SerializeField] private List<Enemy> Enemies;
    [SerializeField] private float obstacleSpeed;
    private float obstaclesSpeed
    {
        get
        {
            if (GameManager.Instance.gameEnded)
            {
                return 0;
            }
            return obstacleSpeed ;
        }
    }
    [SerializeField] private float killObstacle;
    [SerializeField] private float minCreateTime, maxCreateTime;
    private static ObstaclesManager _instance;
    private float[] pathPositions=new float[3];
    private bool StopCreatingObstacles=false;
    
    // Singleton Desgin Pattern To Manage Obstacles Creation,speed and path
    public static ObstaclesManager Instance { 
        get 
        {
            if (_instance==null) 
            {
                _instance = FindObjectOfType<ObstaclesManager>();
            }
            return _instance;
        }
    }
    void Start()
    {
        pathPositions[0] = -GameManager.Instance.pathSidesValue;
        pathPositions[1] = 0;
        pathPositions[2] = GameManager.Instance.pathSidesValue;
        StartCoroutine(ObstacleCreator());
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
                RandomObstacleIndex = Random.Range(0, Enemies.Count - 1);
                CreateObstacle(Enemies[RandomObstacleIndex].gameObject);
            if (StopCreatingObstacles) 
            {
                yield break;
            }
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
    public void StopCreatingObstacle() 
    {
        StopCreatingObstacles = true;
    }
}
