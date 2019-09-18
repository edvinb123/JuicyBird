using UnityEngine;

public class Spawner : MonoBehaviour
{
    #region Variables
    private GameObject SpawnObject;
    public GameObject[] SpawnObjects;

    public float timeMin;
    public float timeMax;
    private bool gameStart;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        SpawnObject = SpawnObjects[Random.Range(0, SpawnObjects.Length)];
        Spawn();
    }

    void Update()
    {
        gameStart = GetComponent<Movement>().gameStarted;
    }
    
    public void Spawn()
    {
        if (gameStart)
        {
            y = Random.Range(0, 3);
            float y = Random.Range(-0.5f, 1f);
            GameObject go = Instantiate(SpawnObject, this.transform.position + new Vector3(0, y, 0), Quaternion.identity) as GameObject;
        }
        Invoke("Spawn", Random.Range(timeMin, timeMax));
    }
}
