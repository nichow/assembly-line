using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineMovement : MonoBehaviour
{
    // speed modifier for the object's movement
    private const float Speed = .065f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * Speed);
        // if ojbect is not on screen destroy it
        if (!PointIsVisibleToCamera(transform.position))
        {
            Destroy(gameObject);
        }
    }

    // method returns true if object is on screen
    static bool PointIsVisibleToCamera(Vector2 point)
    {
        return Camera.main.WorldToViewportPoint(point).x > 0;
    }
}
