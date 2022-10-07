using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSin : MonoBehaviour
{
    float sinCenterX;
    float amplitude = 6;
    public float frequency = 0.5f;

    void Start()
    {
        sinCenterX = transform.position.x;
    }

    private void FixedUpdate()
    {
        Vector2 pos = transform.position;

        float sin = Mathf.Sin(pos.y * frequency) * amplitude;
        pos.x = sinCenterX + sin;

        transform.position = pos;
    }
}
