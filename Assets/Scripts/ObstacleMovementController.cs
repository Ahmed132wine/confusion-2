using UnityEngine;

public class ObstacleMovementController : MonoBehaviour
{
    public float movementSpeed = 4;
    ImpossibleGameManager gameManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<ImpossibleGameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(-gameManager.movementSpeed * Time.deltaTime, 0, 0);
    }
}
