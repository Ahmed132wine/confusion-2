using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private int scene;

    public void NextLevel()
    {
        scene = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(scene);
        Time.timeScale = 1f;
    }

    public void Quit()
    {
        SceneManager.LoadScene("MainMenu");   
    }
}
