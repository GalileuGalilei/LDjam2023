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
    private bool isPaused = false;
    public float gravity;
    public TextMeshProUGUI score;
    public GameObject scoreHUD;
    public GameObject pauseHUD;
    public GoalController goal;

    [SerializeField] GameObject train;

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
        VerifySelect();
    }

    private void VerifySelect()
    {
        for(int i = 0; i < 4; i++)
        {
            if(Input.GetKeyDown((i + 1).ToString()))
            {
                Debug.Log("Cheguei");
                train.transform.GetChild(i).gameObject.transform.GetChild(0).GetComponent<CarController>().selected = !train.transform.GetChild(i).gameObject.transform.GetChild(0).GetComponent<CarController>().selected;
            }
        }
    }
}
