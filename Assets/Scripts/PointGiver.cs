using UnityEngine;
using UnityEngine.UI;

public class PointGiver : MonoBehaviour
{
    #region  Variables
    private bool playerGotPast;
    #endregion

    // Update is called once per frame
    void Update()
    {
        if (!playerGotPast && GameObject.Find("Player").transform.position.x > this.transform.localPosition.x)
        {
            print ("haxx");
            GameObject.Find("Player").GetComponent<Score>().GetPoint();
            playerGotPast = true;
        }
    }
}
