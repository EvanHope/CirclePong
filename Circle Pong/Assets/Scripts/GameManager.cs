/*
 * Deals with pausing and restarting game.
 * To pause press escape to restart press r.
 */
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public BallBehavior BB;
    private bool paused = false;
    public GameObject PausedMenu;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseResume();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            Restart();
        }
    }

    public void Restart()
    {
        if (paused)
            PauseResume();
        SceneManager.LoadScene("GamePlay");
    }

    public void PauseResume()
    {
        if (!paused)
        {
            PausedMenu.SetActive(true);
            StopCoroutine(BB.SlowTime(0));
            Debug.Log("Pause!");
            paused = true;
            Time.timeScale = 0;
        }
        else if (paused)
        {
            PausedMenu.SetActive(false);
            paused = false;
            Time.timeScale = 1f;
        }
    }
}
