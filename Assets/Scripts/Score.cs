using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    #region  Variables
    private Text scoreText;
    public float Points;
    #endregion

    // Update is called once per frame
    void Update()
    {
        scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
        scoreText.text = " " + Points.ToString("0");
    }

    public void GetPoint()
    {
        print ("keeek");
        Points += 1;
    }
}
