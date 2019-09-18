using UnityEngine;

public class Spawner : MonoBehaviour
{
    #region Variables
    private GameObject SpawnObject;
    public GameObject[] SpawnObjects;
    public float timeMin;
    public float timeMax;
    private bool gameStart;
    private bool gameEnd;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        SpawnObject = SpawnObjects[Random.Range(0, SpawnObjects.Length)];
        Spawn();
    }

    void Update()
    {
        gameStart = GameObject.Find("Player").GetComponent<Movement>().gameStarted;
        gameEnd = GameObject.Find("Player").GetComponent<Movement>().gameOver;
    }
    
    void Spawn()
    {
        if (gameStart && !gameEnd)
        {
            float y = Random.Range(0, 1);
            GameObject go = Instantiate(SpawnObject, this.transform.position + new Vector3(3, y, 0), Quaternion.identity) as GameObject;
        }
        Invoke("Spawn", Random.Range(timeMin, timeMax));
    }
}
