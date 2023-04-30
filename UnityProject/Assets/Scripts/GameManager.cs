using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

/// <summary>
/// Singleton class for managing the game
/// </summary>
public class GameManager : MonoBehaviour
{
    private static int Score = 1000;
    public float gravity;
    public TextMeshProUGUI score;
    public GameObject scoreHUD;

    public static void SubtractScore()
    {
        Score -= 45;
    }

    private void Start() 
    {
        scoreHUD.SetActive(false);
    }

    private void OnFinishFase()
    {
        score.text = "Score: " + Score.ToString();
        scoreHUD.SetActive(true);
    }

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            OnFinishFase();
        }
    }
}
