using UnityEngine;

public class Movement : MonoBehaviour 
{
    #region Variables
    private float speed;
    private Rigidbody rb2D;
    #endregion

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        rb2D = getComponent<Rigidbody2D>();
    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        
    }
}