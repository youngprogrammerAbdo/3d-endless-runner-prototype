using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomColors : MonoBehaviour
{
    private Color color;
    private Renderer renderer;
    void Start()
    {
        renderer = GetComponent<Renderer>();
        renderer.material.color = new Color(Random.Range(0.001f,1), Random.Range(0.001f, 1), Random.Range(0.001f, 1),1);
    }
}
