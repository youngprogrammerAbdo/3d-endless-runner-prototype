using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandSpeed : MonoBehaviour
{
    private Renderer landRenderer;
    [SerializeField] private float speedFactor=100;
    void Start()
    {
        landRenderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        landRenderer.material.mainTextureOffset += new Vector2(0,-ObstaclesManager.Instance.ObstacleSpeed()/ speedFactor);
    }
}
