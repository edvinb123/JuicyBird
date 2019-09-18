using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    #region  Variables
    public Text scoreText;
    private float scorePoints;
    private bool move1;
    private bool move2;
    private bool playerGotPast;
    #endregion

    // Update is called once per frame
    void Update()
    {
        move1 = GetComponent<Movement>().gameOver;
        move2 = GetComponent<Movement>().gameStarted;
        scoreText.text = "Score: " + scorePoints.ToString("0");

        if (!move1 && move2)
        {
            print ("on point");
            if (!playerGotPast && GameObject.Find("Player").transform.position.x > transform.position.x)
            {
                scorePoints ++;
                playerGotPast = true;
            }
        }
    }
}
