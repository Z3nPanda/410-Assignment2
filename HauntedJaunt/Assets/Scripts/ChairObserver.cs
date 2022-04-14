using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Mathematics;

public class ChairObserver : MonoBehaviour
{
    public Transform player;
    private float turnSpeed = 20f;
    private Vector3 new_rotation;

    void Start()
    {
        new_rotation = new Vector3(0.0f, 1.0f, 0.0f);
    }

    
    void FixedUpdate()
    {
        // Find distance between player and our chair and normalize the vector to find the angle
        Vector3 distance = player.position - transform.position;
        distance.Normalize();
        // Find our angle betwen the player and the chair
        float angle = Mathf.Rad2Deg * Mathf.Acos(Vector3.Dot(Vector3.forward, distance));
        // Set it to our new rotation Vector3
        new_rotation.y = 2f * angle;
        // Translate our new_rotation using eulerAngles
        transform.eulerAngles = new_rotation;
        // Rotate our chair
        transform.Rotate(new_rotation * turnSpeed * Time.deltaTime);
    }
}
