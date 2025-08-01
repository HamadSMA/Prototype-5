using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    private float spawnRate = 1.0f;
    public List<GameObject> targets;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    private GameObject titleScreen;
    public Button playAgainButton;
    private AudioSource backgroundMusic;
    private int score;
    public bool isGameActive;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        titleScreen = GameObject.Find("Title Screen");
        backgroundMusic = GameObject.Find("Background Music").GetComponent<AudioSource>();
    }



    IEnumerator SpawnTarget()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }

    public void GameOver()
    {
        playAgainButton.gameObject.SetActive(enabled);
        gameOverText.gameObject.SetActive(enabled);
        isGameActive = false;

    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartGame(float difficulty)
    {
        spawnRate /= difficulty;
        isGameActive = true;
        score = 0;
        if (!backgroundMusic.isPlaying)
        {
            backgroundMusic.Play();
        }
        StartCoroutine(SpawnTarget());
        titleScreen.gameObject.SetActive(false);
    }
}
