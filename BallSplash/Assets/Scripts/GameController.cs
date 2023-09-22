using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using TMPro;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> balls;

    private float baseSpawnRate = 1.005f;

    private int totalPoints = 0;

    private int currentStreak = 0;

    public bool isGameOver = false;

    public bool isGameStarted = false;

    [SerializeField]
    private TextMeshProUGUI guiPoints;

    [SerializeField]
    private TextMeshProUGUI guiStreak;

    [SerializeField]
    private GameObject guiGameOver;

    [SerializeField]
    private Button restartGameButton;

    [SerializeField]
    private TextMeshProUGUI guiTitle;

    [SerializeField]
    private GameObject difficultyArea;

    [SerializeField]
    private Slider difficultySlider;


    [SerializeField]
    private Button guiButton;

    [SerializeField]
    private TextMeshProUGUI timerText;

    public float difficulty;

    private int streakMultiplier = 1;

    private float timeRemainingSeconds = 30; 

    // Start is called before the first frame update
    void Start()
    {

        difficultyArea.SetActive(true);
        totalPoints = 0;
        difficulty = difficultySlider.value; 
        guiButton.gameObject.SetActive(true);
        guiButton.onClick.AddListener(this.StartGame); 
        guiGameOver.gameObject.SetActive(false);
        restartGameButton.onClick.AddListener(NewGame);
        guiPoints.gameObject.SetActive(false);
        guiStreak.gameObject.SetActive(false);
        timerText.gameObject.SetActive(false);
        
    }

    void StartGame()
    {
        Debug.Log("Difficulty slider value -> " + difficultySlider.value);
        float spawnRate = baseSpawnRate - difficulty;
        difficultyArea.SetActive(false);
        guiButton.gameObject.SetActive(false);
        guiTitle.gameObject.SetActive(false);
        guiPoints.gameObject.SetActive(true);
        guiStreak.gameObject.SetActive(true);
        timerText.gameObject.SetActive(true);
        StartCoroutine(SpawnBalls(spawnRate));
    }

    // Update is called once per frame
    void DisplayTime(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    void Update()
    {
        
        guiPoints.text = "Total Points -> " + totalPoints;
        guiStreak.text = "Streak -> " + currentStreak;
        //timerText.text

        if (timeRemainingSeconds >= 0)
        { timeRemainingSeconds -= Time.deltaTime;
         }

        DisplayTime(timeRemainingSeconds);

        //Debug.Log(timeRemainingSeconds);
        if (timeRemainingSeconds <= 0)
        {
            isGameOver = true;
        }

        if (isGameOver)
        {
            //guiPoints.gameObject.SetActive(false);
            guiStreak.gameObject.SetActive(false);
            guiGameOver.gameObject.SetActive(true);
            timerText.gameObject.SetActive(false);
            
        }
    }

    IEnumerator SpawnBalls(float spawnRate)
    {
        while (true && !isGameOver)
        {
            yield return new WaitForSeconds(spawnRate);
            int chosenIndex = Random.Range(0, balls.Count);
            Instantiate(balls[chosenIndex]);
        }
    }

    public void UpdatePoints(int points)
    {

        totalPoints += (points * streakMultiplier);
    }

    public void IncreaseStreak(int n)
    {
        currentStreak += n;
        streakMultiplier = (currentStreak/10) + 1;
    }

    public void SetStreak(int n)
    {
        currentStreak = n;
    }

    public void MissedBall(int points)
    {
        
        this.SetStreak(0);
    }

    public void GameOver()
    {
        isGameOver = true;
    }

    public void NewGame()
    {
        Debug.Log("New game clicked!");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
    }
}
