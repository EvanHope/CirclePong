/*
 * Rotates a parent object of all the lights in the center of the screen.
 */
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
