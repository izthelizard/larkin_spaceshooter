using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atmosphere : MonoBehaviour
{
    public GameObject atmosphericprefab;
    public float speed = 10f;
    public float countDown = 2f;
    public Vector3 startPosition;
    //public int numberOfMeteorids = 2;
    

    // Start is called before the first frame update
    void Start()
    {
        startPosition = new Vector3(-20, Random.Range(-10, 10), transform.position.z);
        transform.position = startPosition;
        //SpawnMultiple();
    }

    void Update()
    {
        transform.position += Vector3.right * speed * Time.deltaTime;

        if (transform.position.x > 10)
        {
            Invoke("Respawn", countDown);
        }
    }

    void Respawn()
    {
        startPosition = new Vector3(-20, Random.Range(-10, 10), transform.position.z);
        transform.position = startPosition;

    }

    //void SpawnMultiple()
    //{
       // for (int i = 0; i < numberOfMeteorids; i++)
       // {
          //  Vector3 randomPosition = new Vector3(startPosition.x, Random.Range(-10, 10), startPosition.z);
         //   Instantiate(atmosphericprefab, randomPosition, Quaternion.identity);
         //   Debug.Log($"Spawned meteoroid at position: {randomPosition}");
       // }
   // }

}
