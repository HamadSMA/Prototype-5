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
    private int score;
    public bool isGameActive = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        titleScreen = GameObject.Find("Title Screen");
    }

    // Update is called once per frame
    void Update()
    {

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
        StartCoroutine(SpawnTarget());
        titleScreen.gameObject.SetActive(false);
    }
}
