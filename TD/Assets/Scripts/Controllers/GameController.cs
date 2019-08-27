using UnityEngine;

public class GameController : MonoBehaviour
{
    private PauseController pause;
    private Score score;

    [SerializeField] private GameObject importatDatas;

    private bool paused = false;
    private bool gameOver = false;

    private void Awake()
    {
        if (GameObject.FindGameObjectWithTag("Datas") == null)
            Instantiate(importatDatas);
    }

    // Start is called before the first frame update
    void Start()
    {
        pause = GetComponent<PauseController>();
        score = GetComponent<Score>();        
    }

    // Update is called once per frame
    void Update()
    {
        // Pause when the player click "Cancel" (by default, Esc)
        if (Input.GetButtonDown("Cancel") && !gameOver)
        {
            paused = !paused;
            pause.Pause();
        }

        //made only to call the gameover
        if(Input.GetKeyDown(KeyCode.Q) && !gameOver)
        {
            GameOver();
        }

        // Where the games go, only can call if isn't paused and isn't gameover
        if (!paused && !gameOver)
        {
            // do everythings here
            if (Input.GetKeyDown(KeyCode.E))
            {
                score.AddScore(0);
            }
        }
    }

    /// <summary>
    /// Fuction made to update all the things when the game is over
    /// </summary>
    private void GameOver()
    {
        gameOver = true;
        score.SaveHighScore();
        pause.GameOver();
    }
}
