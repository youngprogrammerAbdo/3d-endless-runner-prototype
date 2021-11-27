using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private Color color;
    private Renderer renderer;
    private Vector3 startPosition;
    [SerializeField] private float jumpPower = 0.5f, jumpSpeed = 6;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject,ObstaclesManager.Instance.KillObstacleTime());
        startPosition = transform.position;
        renderer = GetComponent<Renderer>();
        RanomdColor();
    }
    private void RanomdColor()
    {
        renderer.material.color = new Color(Random.Range(0.001f, 1), Random.Range(0.001f, 1), Random.Range(0.001f, 1), 1);
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        UpDowanMove();
        Move(-ObstaclesManager.Instance.ObstacleSpeed());        
    }
    private void UpDowanMove()
    {
        transform.position = new Vector3(transform.position.x, startPosition.y + (((Mathf.Sin(Time.time * jumpSpeed) * jumpPower))), transform.position.z);
    }
    private void Move(float speed)
	{
        transform.position += new Vector3(0, 0, speed);
	}
}
