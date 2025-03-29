using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ImpossibleGameManager : MonoBehaviour
{
    public float movementSpeed = 7;
    public GameObject levelGroup;
    public Vector3 lastCheckpoint = new Vector3(0,0,0);
    public GameObject player;
    public Text attemptText;
    private int numberOfAttempts = 1;
    bool canReset = true;

    public void ResetPosition()
    {
        if(canReset)
        {
            canReset = false;

            Time.timeScale = 0;
            StartCoroutine(DelayOnDeath());
        }
        
    }
    public void UpdateCheckpoint(Vector3 newCheckpoint)
    {
        lastCheckpoint = newCheckpoint;
    }

    IEnumerator ResetCoolDown()
    {
        yield return new WaitForSeconds(0.01f);
        canReset = true;
    }
    IEnumerator DelayOnDeath() 
    {
        yield return new WaitForSecondsRealtime(1f);
        Time.timeScale = 1;
        levelGroup.transform.position = new Vector3(lastCheckpoint.x, 0, 0);
        player.transform.position = new Vector3(player.transform.position.x, lastCheckpoint.y, 0);
        numberOfAttempts++;
        attemptText.text = "Attempt: " + numberOfAttempts;
        StartCoroutine(ResetCoolDown());
    }
}
