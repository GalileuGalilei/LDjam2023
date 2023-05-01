using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

/// <summary>
/// Singleton class for managing the game
/// </summary>
public class GameManager : MonoBehaviour
{
    private static int Score = 500;
    public static GameObject selectedCar = null;
    private bool isPaused = false;
    public float gravity;
    public TextMeshProUGUI score;
    public GameObject scoreHUD;
    public GameObject pauseHUD;
    public GoalController goal;

    public static void SubtractScore()
    {
        Score -= 85;
    }

    private void Awake() 
    {
        scoreHUD.SetActive(false);
        pauseHUD.SetActive(false);
        goal.OnFinishGame += OnFinishFase;
    }

    private void OnFinishFase()
    {
        score.text = "Score: " + Score.ToString();
        AudioSource audioSource = GetComponent<AudioSource>();
        audioSource.Play();
        scoreHUD.SetActive(true);
    }

    public void LoadFase(int fase)
    {
        if(isPaused)
        {
            Pause();
        }

        UnityEngine.SceneManagement.SceneManager.LoadScene("Fase" + fase.ToString());
    }

    public void LoadMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }

    public void Pause()
    {
        if(isPaused)
        {
            Time.timeScale = 1.0f;
            pauseHUD.SetActive(false);
        }
        else
        {
            Time.timeScale = 0.0f;
            pauseHUD.SetActive(true);
        }

        isPaused = !isPaused;
    }

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
    }
}
