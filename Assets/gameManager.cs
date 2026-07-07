using UnityEngine;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour
{
    public float gameoverscreendelay;
    private float gameovertimer=0;


    public GameObject GamePausedUI;
    public GameObject GameOverUI;

    private healthBarScript healthBar;

    private bool paused=false;
    private bool gameover=false;

    void Start()
    {
        healthBar=FindAnyObjectByType<healthBarScript>();
    }

    
    void Update()
    {
        if (Input.GetButtonDown("Pause") && paused==false && gameover==false)
        {
            GamePausedUI.SetActive(true);
            paused = true;
        }
        else if (Input.GetButtonDown("Pause") && paused == true && gameover==false)
        {
            GamePausedUI.SetActive(false);
            paused = false;
        }

        if (healthBar.healthamt == 0)
        {   if (gameovertimer < gameoverscreendelay)
            {
                gameovertimer+=Time.deltaTime;
            }

            else if(gameovertimer>= gameoverscreendelay)
            {
            GameOverUI.SetActive(true);
            gameover = true;
            }

        }

    }

    public void resume()
    {
        GamePausedUI.SetActive(false);
    }
    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void mainmenu()
    {
        
    }
    public void quit()
    {
        Application.Quit();
    }

   

}
