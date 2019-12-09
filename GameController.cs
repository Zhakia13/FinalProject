using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject[] hazards;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;
    public AudioClip musicWin;
    public AudioSource musicSource1;
    public AudioClip musicLose;

    public Text scoreText;
    public Text restartText;
    public Text gameOverText;

   public bool gameOver;
    private bool restart;
private bool timerActive = false;
    private bool canCount = true;
    
    public int score;

    float currentTime = 0f;
    float startingTime = 30f;
    [SerializeField] Text countdownText;

    void Start()
    {
        gameOver = false;
        restart = false;
        restartText.text = "";
        gameOverText.text = "";
        score = 0;
        UpdateScore();
        StartCoroutine(SpawnWaves());
        currentTime = startingTime;
  
    }

    void Update()
    {
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
        if (restart)
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                SceneManager.LoadScene("SampleScene");
            }
         
        }
        if (Input.GetKeyDown(KeyCode.Q))
            timerActive = true;

        if (timerActive)
        {
            currentTime -= 1 * Time.deltaTime;
            countdownText.text = currentTime.ToString("0");
            if (currentTime <= 0)
            {
                currentTime = 0;
            }
            if (currentTime <= 0)
            {
                gameOver = true;
                musicSource1.clip = musicLose;
                musicSource1.Play();
                restart = true;
                gameOverText.text = "Game Over! Created by Z Powell";
            }

        }
        if (Input.GetKeyDown(KeyCode.E))
            timerActive = false;
    }



            IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                GameObject hazard = hazards[Random.Range(0, hazards.Length)];
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);

            if (gameOver)
            {
                restartText.text = "Press 'Z' for Restart";
                restart = true;
                musicSource1.clip = musicLose;
                musicSource1.Play();
                timerActive = false;
                break;
            }
        }
    }

    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }


    void UpdateScore()
    {
        scoreText.text = "Points: " + score;
        if (timerActive == false)
        {
            if (score >= 100)
            {
                gameOverText.text = "You Win! Created by Z Powell";
                gameOver = true;
                restart = true;
                musicSource1.clip = musicWin;
                musicSource1.Play();
            }
        }
    }

    public void GameOver()
    { 
            {
                gameOverText.text = "Game Over! Created by Z Powell";
            gameOver = true;
                musicSource1.clip = musicLose;
                musicSource1.Play();
            timerActive = false;
        }
        
       
    }
}
