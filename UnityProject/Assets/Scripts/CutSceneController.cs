using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class CutSceneController : MonoBehaviour
{
    VideoPlayer player;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<VideoPlayer>();
        player.loopPointReached += LoadFase1;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Escape))
        {
            player.Stop();
            SceneManager.LoadScene("Fase1");
        }
    }

    private void LoadFase1(VideoPlayer source)
    {
        source.Stop();
        SceneManager.LoadScene("Fase1");
    }
}
