using UnityEngine;

public class Movement : MonoBehaviour
{
    #region Variables
    public Rigidbody rb;
    public bool gameStarted;
    public bool gameOver;
    #endregion

    // Start is called on the frame when a script is enabled just before
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameStarted)
        {
            rb.constraints = RigidbodyConstraints.FreezePosition | RigidbodyConstraints.FreezeRotation;
           // rb.constraints = RigidbodyConstraints.FreezeRotation;
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0))
            {
                gameStarted = true;
                Move();
            }
        }
        if (gameStarted)
        {
            print("hej");
            rb.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionX;;
            if (!gameOver)
            {
                if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0))
                {   
                    Move();
                }
            }
        }
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Obstacle")
        {
            Die();
        }
    }

    void Move()
    {
        rb.AddForce(Vector3.up * 150f);
    }
    
    void Die()
    {
        gameOver = true;
        rb.constraints = RigidbodyConstraints.FreezePosition;
        rb.constraints = RigidbodyConstraints.FreezeRotation;
    }
}

