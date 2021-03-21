using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    public GameObject center;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 diff = transform.position - center.transform.position;
        //transform.rotation = Quaternion.Euler(0f,0f, (Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg) - 90);
    }
}
