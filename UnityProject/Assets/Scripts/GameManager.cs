using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Singleton class for managing the game
/// </summary>
public class GameManager
{
    private GameManager() { }
    public static GameManager Instance { get; } = new GameManager();
    public float gravity;
}
