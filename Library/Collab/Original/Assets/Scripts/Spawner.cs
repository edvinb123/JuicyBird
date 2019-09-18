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

        for (int i = 0; i < SpawnObject.Count; i++)
        {

            SpawnObject[i].transform.position -= new Vector3(1 * Time.deltaTime, 0, 0);
        }
    }
    
    void Spawn()
    {
        if (gameStart)
        {
            float y = Random.Range(0, 3);
            GameObject go = Instantiate(SpawnObject, this.transform.position + new Vector3(3, y, 0), Quaternion.identity) as GameObject;
        }
        Invoke("Spawn", Random.Range(timeMin, timeMax));
    }
}
