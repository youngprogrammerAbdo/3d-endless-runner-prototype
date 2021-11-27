using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject,ObstaclesManager.Instance.KillObstacleTime());
    }

    // Update is called once per frame
    void FixedUpdate()
    {
            Move(-ObstaclesManager.Instance.ObstacleSpeed());        
    }
	private void Move(float speed)
	{
        transform.position += new Vector3(0, 0, speed);
	}
}
