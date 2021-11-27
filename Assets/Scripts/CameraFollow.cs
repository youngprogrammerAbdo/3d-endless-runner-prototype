using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private float SmoothTime = 0.3f;
    private Transform cam;
    [SerializeField]private Transform player;
    private Vector3 Offset;
    private Vector3 velocity;

    private void Start()
    {
        cam = gameObject.transform;
        Offset = cam.position - player.position;
    }

    private void LateUpdate()
    {
        Vector3 targetPosition = player.position + Offset;
        cam.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, SmoothTime);
        transform.LookAt(player);
    }
}
