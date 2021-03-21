using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    public int score;
    Text number;

    // Start is called before the first frame update
    void Start()
    {
        number = GetComponent<Text>();
        score = 0;
        number.text = score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddScore(int x)
    {
        score += x;
        number.text = score.ToString();
    }
}
