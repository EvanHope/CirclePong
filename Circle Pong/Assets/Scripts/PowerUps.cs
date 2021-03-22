/*
 * Rotates powerup while it is spawned.
 */
using UnityEngine;

public class PowerUps : MonoBehaviour
{
    public float rotationSpeed;

    void Update()
    {
        transform.Rotate(Vector3.forward * (rotationSpeed * Time.deltaTime));
    }
    private void OnDestroy()
    {
        //Particle effect
    }
}
