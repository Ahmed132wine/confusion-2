using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    audioManager audioManager;
    Rigidbody2D rb;
    public float jumpForce = 1000;
    bool inAir = false;
    public float rotationSpeed = 10;
    ImpossibleGameManager gameManager;
    bool canRotate = true;

    public GameObject checkPointGameObject;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<ImpossibleGameManager>();

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if(!inAir) 
            {
                rb.AddForceAtPosition(Vector2.up * jumpForce, transform.position);
                audioManager.PlaySFX(audioManager.jump);
                inAir = true;
            }
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            GameObject g = Instantiate(checkPointGameObject, gameManager.levelGroup.transform);
            g.transform.localPosition = this.transform.position - gameManager.levelGroup.transform.position;
            Vector3 checkpointData = new Vector3(gameManager.levelGroup.transform.position.x, this.transform.position.y,0);
            gameManager.UpdateCheckpoint(checkpointData);
        }
        if(inAir)
        {
            if(canRotate)
            {
                transform.Rotate(Vector3.forward * (rotationSpeed * Time.deltaTime));
            }
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            gameManager.ResetPosition();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        inAir = false;
        transform.rotation = Quaternion.identity;
        canRotate = false;
        StartCoroutine(ResetCanRotate());
    }
    IEnumerator ResetCanRotate()
    {
        yield return new WaitForSeconds(0.1f);
        canRotate = true;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        inAir = true;
    }

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<audioManager>();
    }
}
