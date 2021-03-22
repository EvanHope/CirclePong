/*
 * Deals with majority of games logic.
 * In many cases when the ball interacts with other objects functions are called.
 * 
 */
using System.Collections;
using UnityEngine;

public class BallBehavior : MonoBehaviour
{
    public AudioManager audioManager;

    public Vector2 speed;
    public float speedMultiplier;

    public GameObject[] lights;
    public LightRotator lightRotator;
    public Counter scoreCounter;

    //PowerUps
    public int powerUpTime;
    public GameObject paddle;
    public GameObject OGcenter;
    public GameObject paddlePrefab;
    private SpriteRenderer paddleRenderer;
    private Color paddleColor;

    private float collisionTime = 0f;

    // Start is called before the first frame update
    void Start()
    {
        float rand = Random.Range(-.5f, .5f);
        float rand2 = .5f - Mathf.Abs(rand);
        speed = new Vector3(rand, rand2);
        paddleRenderer = paddle.GetComponent<SpriteRenderer>();
        paddleColor = paddleRenderer.color;
    }

    // Update is called once per frame
    void Update()
    {
        //Moves the ball based on calculated speed
        transform.position += new Vector3(speed.x, speed.y) * Time.deltaTime * speedMultiplier;

        //Debug function
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            HitAction();
        }
    }

    //When ball collides with powerup coroutines are started to start the powerup effects
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "SlowTime")
        {
            StopCoroutine(SlowTime(powerUpTime));
            StopCoroutine(PowerUpColor(powerUpTime, col.GetComponent<SpriteRenderer>().color));
            StartCoroutine(SlowTime(powerUpTime));
            StartCoroutine(PowerUpColor(powerUpTime, col.GetComponent<SpriteRenderer>().color));
            Destroy(col.gameObject);
        }

        if (col.tag == "DoubleBarrier")
        {
            StopCoroutine(DoubleBarrier(powerUpTime, col.GetComponent<SpriteRenderer>().color));
            StopCoroutine(PowerUpColor(powerUpTime, col.GetComponent<SpriteRenderer>().color));
            StartCoroutine(DoubleBarrier(powerUpTime, col.GetComponent<SpriteRenderer>().color));
            StartCoroutine(PowerUpColor(powerUpTime, col.GetComponent<SpriteRenderer>().color));
            Destroy(col.gameObject);
        }

    }
    //TODO: Create gameover screen
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "GameEnder")
        {
            //End Game
        }
    }

    //On Paddle Hit
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Ensures that the ball did not hit the paddle within the last second to work around bug where one hit would be counted twice.
        if (collisionTime + 1f < Time.time)
        {
            collisionTime = Time.time;
            //TODO: Fix Bug where ball goes in weird direction due to normal being weird(prob just use preset directions for each different collider
            speed = collision.GetContact(0).normal.normalized;
            //Debug.Log(collision.contacts[0].normal.normalized);
            HitAction();
        }
    }

    //All behaviors for when ball hits paddle
    private void HitAction()
    {
        scoreCounter.AddScore(1);
        audioManager.PlayHitSound();
        float distancetemp = 100;
        int itemp = 0;
        for (int i = 0; i < lights.Length; i++)
        {
            if (Vector3.Distance(transform.position, lights[i].transform.position) < distancetemp)
            {
                distancetemp = Vector3.Distance(transform.position, lights[i].transform.position);
                itemp = i;
            }
        }
        LightBehavior lightbehavior = lights[itemp].GetComponent<LightBehavior>();
        lightbehavior.IncreaseIntensity();
        lightRotator.IncreaseRotationSpeed();
    }


    //PowerUps
    //Slowtime powerup sets time scale to half
    public IEnumerator SlowTime(int powerUpLength)
    {
        while (true)
        {
            Time.timeScale = 0.5f;
            yield return new WaitForSecondsRealtime(powerUpLength);
            Time.timeScale = 1;
            break;
        }
    }

    //DoubleBarrier creates a second barrier on the circle
    public IEnumerator DoubleBarrier(int powerUpLength, Color pucolor)
    {
        while (true)
        {
            Quaternion rotation = Quaternion.Euler(0, 0, Random.Range(0, 360));
            GameObject pu = Instantiate(paddlePrefab, Vector3.zero, rotation);
            pu.GetComponentInChildren<SpriteRenderer>().color = pucolor;
            yield return new WaitForSecondsRealtime(powerUpLength);
            Destroy(pu);
            break;
        }
    }

    //Used to display the color of the powerup when one is picked up and slowly fade back to white
    private IEnumerator PowerUpColor(int powerUpLenght, Color pucolor)
    {
        paddleRenderer.color = pucolor;
        yield return new WaitForSecondsRealtime(5);
        while (true)
        {
            yield return new WaitForSecondsRealtime(((float)powerUpLenght - 5) / 50);
            paddleRenderer.color = Color.Lerp(paddleRenderer.color, paddleColor, 1f / 50f);
            if (paddleRenderer.color == paddleColor)
                break;
        }
    }
}
