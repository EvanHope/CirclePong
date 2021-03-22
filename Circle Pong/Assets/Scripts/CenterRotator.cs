/*
 * Simple script to rotate paddle around the center of the screen.
 * This is done by setting the paddle object as a child of the center
 * object then rotating the center object.
 */
using UnityEngine;

public class CenterRotator : MonoBehaviour
{
    public float rotationSpeed;


    // Update is called once per frame
    void Update()
    {
        //Vector3 diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        //transform.rotation = Quaternion.Euler(0f, 0f, (Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg) - 90);

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.forward * (rotationSpeed * Time.deltaTime));
        }
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.forward * (-rotationSpeed * Time.deltaTime));
        }
    }
}
