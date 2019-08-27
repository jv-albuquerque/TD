using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseController : MonoBehaviour
{
    private bool isPause = false;


    [Header("Fade Properties")]
    [SerializeField] private Image fadeInOut = null;
    [SerializeField] private Animator fadeAnim = null;

    [Header("Fade Menu")]
    [SerializeField] private GameObject canvasPause = null;
    [SerializeField] private GameObject canvasSettings = null;
    [SerializeField] private GameObject canvasGameOver = null;
    [SerializeField] private GameObject canvasGameUI = null;

    private ImportantDatas datas = null;

    //Checkers
    private bool pause;
    private bool gameOver;

    //past settings variables
    private float timeScale;

    // Start is called before the first frame update
    void Start()
    {
        datas = GameObject.FindGameObjectWithTag("Datas").GetComponent<ImportantDatas>();

        fadeInOut.gameObject.SetActive(true); //used to clean the screen in the editor
        fadeAnim.SetTrigger("FadeIn");

        timeScale = Time.timeScale;

        canvasPause.SetActive(false);
        canvasSettings.SetActive(false);
        canvasGameOver.SetActive(false);
        canvasGameUI.SetActive(true);
    }

    /// <summary>
    /// Pause or unpause the game
    /// </summary>
    public void Pause()
    {
        if (gameOver)
            return;

        //unpause
        if(isPause)
        {
            // if it is in the pause main menu
            if (pause)
            {
                isPause = false;
                Time.timeScale = timeScale;
                canvasPause.SetActive(false);
                canvasSettings.SetActive(false);
                canvasGameUI.SetActive(true);
            }
            // if it is in the settings menu
            else
            {
                MainPause();
            }
        }
        //pause
        else
        {
            pause = true;
            isPause = true;
            Time.timeScale = 0;
            canvasPause.SetActive(true);
            canvasGameUI.SetActive(false);
        }
    }

    /// <summary>
    /// Go to GameOver Screen
    /// </summary>
    public void GameOver()
    {
        gameOver = true;
        canvasGameOver.SetActive(true);
        canvasGameUI.SetActive(false);
    }

    /// <summary>
    /// Go to settings menu
    /// </summary>
    public void Settings()
    {
        pause = false;
        canvasPause.SetActive(false);
        canvasSettings.SetActive(true);
    }

    /// <summary>
    /// Go back to pause main menu
    /// </summary>
    public void MainPause()
    {
        pause = true;
        canvasPause.SetActive(true);
        canvasSettings.SetActive(false);
    }

    /// <summary>
    /// Go back to main menu
    /// </summary>
    public void MainMenu()
    {
        datas.NextScene = 1; // set the scene that will be loaded
        StartCoroutine(Fading()); //Start the fade out before change sceane
    }

    /// <summary>
    /// Reset the game
    /// </summary>
    public void Restart()
    {
        datas.NextScene = SceneManager.GetActiveScene().buildIndex; // set the scene that will be loaded
        StartCoroutine(Fading()); //Start the fade out before restart sceane
    }

    //Function that plays the fade out in paralel
    //The Animation needs to be in the update mode = Unscale time
    private IEnumerator Fading()
    {
        fadeAnim.SetTrigger("FadeOut");

        yield return new WaitUntil(() => fadeInOut.color.a == 1);
        SceneManager.LoadScene(0);
    }
}
