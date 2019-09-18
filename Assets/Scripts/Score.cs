using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    #region  Variables
    public Text scoreText;
    private float scorePoints;
    private bool move1;
    private bool move2;
    #endregion
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        move1 = GetComponent<Movement>().gameOver;
        move2 = GetComponent<Movement>().gameStarted;
        scoreText.text = "Score: " + scorePoints.ToString("0.0") + "m";

        if (!move1 && move2)
        {
            scorePoints += 1 * Time.deltaTime;
        }
    }
}
