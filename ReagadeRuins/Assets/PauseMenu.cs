using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject gameManager;

    public bool gamePaused = false;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !gamePaused)
        {
            gamePaused = true;
            Pause();
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && gamePaused)
        {
            gamePaused = false;
            Resume();
        }
    }

    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }

    public void Home()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }

    public void Quit()
    {
        gameManager.GetComponent<gamemaneger>().Exit();
        Time.timeScale = 1;
    }
}
