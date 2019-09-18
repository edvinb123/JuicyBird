using UnityEngine;

public class Movement : MonoBehaviour
{
    #region Variables
    public Rigidbody rb;
    public bool gameStarted;
    public bool gameOver;
    public float jumpForce = 150f;
    Vector3 EulerAngleVelocity;
    #endregion

    // Start is called on the frame when a script is enabled just before
    void Start()
    {
        EulerAngleVelocity = new Vector3(0, 0, -100);
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
            rb.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezePositionX;;
            if (!gameOver)
            {
                if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0))
                {   
                    Move();
                }
            }
        }

    }

    void FixedUpdate()
    {
        Quaternion deltaRotation = Quaternion.Euler(EulerAngleVelocity * Time.deltaTime);

        if (rb.velocity.y < 0)
        {
            rb.MoveRotation(rb.rotation * deltaRotation);
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
        rb.AddForce(Vector3.up * jumpForce);
        rb.MoveRotation(Quaternion.Euler(0, 0, 40));
    }
    
    void Die()
    {
        gameOver = true;
        rb.constraints = RigidbodyConstraints.FreezePosition | RigidbodyConstraints.FreezeRotation;
    }
}

