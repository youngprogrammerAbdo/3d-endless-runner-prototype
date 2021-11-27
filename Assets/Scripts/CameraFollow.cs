using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private float SmoothTime = 0.3f;
    private Transform cam;
    [SerializeField]private Transform player;
    [SerializeField] private Vector3 Offset;
    [SerializeField] private float Height;
    private Vector3 velocity;
    Vector3 targetPosition;
    private void Start()
    {
        cam = gameObject.transform;
      //  Offset = cam.position - player.position;
    }

    private void LateUpdate()
    {
        targetPosition = player.position + Offset;
        cam.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, SmoothTime);
        transform.LookAt(player.position + new Vector3(0, Height, 0));
    }
}
