using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public float floatSpeed = 1f;
    public float rotationSpeed = 100f;

    private Vector3 initialPosition;

    private void Start()
    {
        initialPosition = transform.position;
    }

    private void Update()
    {
        // Floating motion
        Vector3 floatOffset = new Vector3(0f, Mathf.Sin(Time.time * floatSpeed), 0f);
        transform.position = initialPosition + floatOffset;

        // Rotating motion
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime, Space.World);
    }
}
