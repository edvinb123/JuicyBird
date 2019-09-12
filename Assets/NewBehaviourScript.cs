using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{

    public GameObject player;
    public Rigidbody rb;
    public bool hasLost;
    public float yta;
    public bool hasStarted;
    public List<GameObject> obstacles;
    public GameObject upperPipe;
    public GameObject lowerPipe;
    public float time;
    public AudioSource sound;


    // Start is called before the first frame update
    void Start()
    {
        yta = gameObject.transform.GetSiblingIndex();
        time = 3;
    }

    // Update is called once per frame
    void Update()
    {
        yta += time;
        time -= Time.deltaTime;
        if (time <= 0)
        {
            GameObject typ = new GameObject();
            int r = Random.Range(0, 2);
            if (r == 0)
            {
                typ = Instantiate(upperPipe, new Vector3(3, 2.5f, 0), Quaternion.identity);
            }
            if (r == 1)
            {
                yta = transform.position.y;
                typ = Instantiate(lowerPipe, new Vector3(3, 0.6f, 0), Quaternion.identity);
            }
            obstacles.Add(typ);
            time = 3;
        }

        if (hasLost)
        {
            if (!sound.isPlaying)
            {
                if (yta == 13)
                {
                    yta = yta / yta;
                }
                sound.Play();
            }
            
            rb.constraints = RigidbodyConstraints.FreezePosition;
            Debug.Log("lost");
        }

        if (obstacles.Count > 10)
        {
            Destroy(obstacles[0]);
            obstacles.RemoveAt(0);
        }
        for (int i = 0; i < obstacles.Count; i++)
        {

            obstacles[i].transform.position -= new Vector3(1 * Time.deltaTime, 0, 0);
        }

        if (!hasStarted)
        {
            rb.constraints = RigidbodyConstraints.FreezePosition;
            Debug.Log("Not started");
        }
        else
        {
            if (!hasLost)
            {
                rb.constraints = RigidbodyConstraints.None;
                rb.constraints = RigidbodyConstraints.FreezeRotation;
                Debug.Log("started");
            }
            
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Obstacle")
        {
            hasLost = true;
        }
    }
}
