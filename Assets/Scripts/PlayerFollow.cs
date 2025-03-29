using UnityEngine;

public class PlayerFollow : MonoBehaviour
{
    public GameObject player;
    public float xOffset;
    public float yOffset;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = player.transform.position + new Vector3 (xOffset, yOffset, 0);
    }
}
