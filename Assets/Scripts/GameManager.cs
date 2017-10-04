using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int lives = 3;
    public int bricks = 20;
    public float resetDelay = 1f;
    public Text livesTxt;
    public GameObject gameOver;
    public GameObject youWon;
    public GameObject brickPrefab;
    public GameObject paddle;
    public GameObject deathParticules;
    public GameObject clonePaddle;

    public static GameManager instance = null;

	// Use this for initialization
	void Start ()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        Setup();
	}
	
    public void LoseLife()
    {
        lives--;
        livesTxt.text = "Lives: " + lives;
        Instantiate(deathParticules, clonePaddle.transform.position, Quaternion.identity);
        Destroy(clonePaddle);
        Invoke("SetupPaddle", resetDelay);
        CheckGameOver();
    }

    public void DestroyBrick()
    {
        bricks--;
        CheckGameOver();
    }

    private void Setup()
    {
        clonePaddle = Instantiate(paddle, transform.position, Quaternion.identity) as GameObject;
        Instantiate(brickPrefab, transform.position, Quaternion.identity);
    }

    private void CheckGameOver()
    {
        if (bricks < 1)
        {
            youWon.SetActive(true);
            Time.timeScale = .25f;
            Invoke("Reset", resetDelay);
        }

        if (lives < 1)
        {
            gameOver.SetActive(true);
            Time.timeScale = .25f;
            Invoke("Reset", resetDelay);
        }
    }

    private void Reset()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void SetupPaddle()
    {
        clonePaddle = Instantiate(paddle, transform.position, Quaternion.identity);
    }
}
