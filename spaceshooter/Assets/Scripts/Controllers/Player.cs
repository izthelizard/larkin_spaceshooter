using Codice.Client.BaseCommands.CheckIn.Progress;
using Codice.CM.Common;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    public List<Transform> asteroidTransforms;
    public Transform enemyTransform;
    public GameObject bombPrefab;
    public GameObject powerupPrefab;
    public GameObject missilePrefab;
    public Transform bombsTransform;
    public float targetSpeed = 3f;
    public float timeToReachTargetSpeed = 2f;
    public float maxRadarDistance;

    public float missileSpeed = 5f;
    public float missileLife = 2f;

    private Vector3 velocity = Vector3.zero;
    private float acceleration;

    public float lineLength = 10f;

    void Start()
    {
        acceleration = targetSpeed / timeToReachTargetSpeed;

       

        // List<string> words = new List<string>();
        //words.Add("Dog");
        //Dog[0]
        //words.Add("Cat");
        //Dog[0],Cat[1]
        // words.Add("Log");
        //Dog[0],Cat[1],Log[2]

        // words.Insert(1, "Rat");
        //Dog[0],Rat[1],Cat[2],Log[3]

        // words.Remove("Dog");
        //Rat[0],Cat[1],Log[2]

        // Debug.Log("Index of the cat is: " + words.IndexOf("Cat"));

        // for (int i = 0; i < words.Count; i++)
        // {
        //     Debug.Log(words[i]);
        // }
        // foreach (string word in words)
        // {
        //    Debug.Log(word);
        // }
    }
    void Update()
    {
        Vector3 origin = transform.position;
        Vector3 ePost = origin + transform.forward * lineLength; 
        // transform.position = transform.position + Vector3.right * 0.001f;
        PlayerMovement();

       

        // EnemyRadar();

        DetectAsteroids(maxRadarDistance, asteroidTransforms);

        if (Input.GetKeyDown(KeyCode.R))
        {
            FireMissile();
        }
    }

    private void PlayerMovement()
    {

        //velocity = Vector3.zero;

        if (Input.GetKey(KeyCode.UpArrow))
        {
            //transform.position += Vector3.up * speed * Time.deltaTime;
            velocity += Vector3.up * acceleration * Time.deltaTime;

        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            velocity += Vector3.down * acceleration * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            velocity += Vector3.left * acceleration * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            velocity += Vector3.right * acceleration * Time.deltaTime;
        }

        //compare the size of the vector to max speed

        //if over it
        //normalize
        //and then mlutiply by maxSpeed
        if (acceleration > targetSpeed)
        {
            velocity = velocity.normalized * targetSpeed;
        }

        transform.position += velocity * Time.deltaTime;
    }

    public void DetectAsteroids(float inMaxRange, List<Transform> inAsteroids)
    {
        foreach (Transform asteroid in inAsteroids)
        {
            //Figuring out what the distance is to the asteroid
            float distance = Vector3.Distance(asteroid.position, transform.position);

            if (distance <= inMaxRange)
            {
                //We are going to draw a line
                Vector3 startPosition = transform.position;
                Vector3 endPosition = (asteroid.position - transform.position).normalized * 2.5f + transform.position;
                Debug.DrawLine(startPosition, endPosition, Color.green);
            }

        }
    }

    public void FireMissile()
    {
        transform.position += Vector3.up * missileSpeed * Time.deltaTime;
    }

    //public void EnemyRadar(float radius, int circlePoints)
    //{
    //radius = 5;
    //circlePoints = new circlePoints(Mathf.Cos(10 * Mathf.Deg2Rad), Mathf.Sin(10 * Mathf.Deg2Rad)) * radius;


    // Debug.DrawLine(startingPosition, endingPosition, Color.green);



    //if (Enemy => radius)
    //{
    //    Debug.DrawLine(startingPosition, endingPosition, Color.red);
    //}

    //}

    public void SpawnPowerups(float radius, int numberOfPowerups)
    {
        float angle = (Mathf.Deg2Rad * (360 / 5));
        float x = Mathf.Cos(angle);
        float y = Mathf.Sin(angle);

        // get clarification later
        //numberOfPowerups = (x, y) * radius;

    }
}
