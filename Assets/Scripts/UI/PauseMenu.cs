using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public GameObject pausePannel;

    public bool isPaused;

    void Start()
    {
        pausePannel.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;

            if (isPaused)
            {

                Time.timeScale = 0;
                pausePannel.SetActive(true);
                isPaused = true;
            }
            else Resume();

        }
    }



    public void Resume()
    {
        Time.timeScale = 1;
        pausePannel.SetActive(false);
        isPaused = false;
    }

    public void Exit()
    {
        PlayerManager.instance.OnDeath();
        pausePannel.SetActive(false);
        Time.timeScale = 1;
    }
}
