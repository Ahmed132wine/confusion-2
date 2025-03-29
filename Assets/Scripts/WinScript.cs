using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScript : MonoBehaviour
{
    [SerializeField] private GameObject nextLevelButton;
    public GameObject winPanel;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if(SceneManager.GetActiveScene().buildIndex == 10)
            {
                nextLevelButton.SetActive(false);
            }
            
            winPanel.SetActive(true);
            Time.timeScale = 0f; // Freeze the game
        }
    }
}
