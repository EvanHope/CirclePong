using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightRotator : MonoBehaviour
{
    public float RotationSpeed;
    public float increaseOnHitAmount;

    void Update()
    {
        transform.Rotate(Vector3.forward * (RotationSpeed * Time.deltaTime));
    }

    public void IncreaseRotationSpeed()
    {
        RotationSpeed += increaseOnHitAmount;
    }
}
