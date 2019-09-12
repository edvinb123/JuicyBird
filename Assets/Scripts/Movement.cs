using UnityEngine;

public class Movement : MonoBehaviour
{
    #region Variables
    public Rigidbody rb;
    public bool gameStarted;
    public bool gameOver;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameStarted)
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0))
            {
                gameStarted = true;
                rb.AddForce(Vector3.up * 250f);
            }
        }

        if (gameStarted)
        {
            if (!gameOver)
            {
                if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0))
                {
                    rb.AddForce(Vector3.up * 250f);
                }
            }
        }
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Obstacle")
        {
            gameOver = true;
        }
    }
}

