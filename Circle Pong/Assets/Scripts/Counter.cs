/*
 * Updates number in middle of the screen
 * when game is started and everytime
 * AddScore function is called.
 */
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    public int score;
    Text number;

    void Start()
    {
        number = GetComponent<Text>();
        score = 0;
        number.text = score.ToString();
    }

    public void AddScore(int x)
    {
        score += x;
        number.text = score.ToString();
    }
}
