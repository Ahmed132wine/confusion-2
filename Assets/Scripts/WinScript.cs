using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScript : MonoBehaviour
{
    [SerializeField] private GameObject nextLevelButton;
    [SerializeField] private GameObject text;
    public GameObject winPanel;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(winPanel.activeInHierarchy == false)
            {
                winPanel.SetActive(true);
                text.SetActive(false);
                Time.timeScale = 0f;
            }
            else
            {
                winPanel.SetActive(false);
                Time.timeScale = 1f;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if(SceneManager.GetActiveScene().buildIndex == 10)
            {
                nextLevelButton.SetActive(false);
            }
            
            winPanel.SetActive(true);
            text.SetActive(true);
            Time.timeScale = 0f; // Freeze the game
        }
    }
}
