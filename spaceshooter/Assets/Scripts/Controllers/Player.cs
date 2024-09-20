using Codice.Client.BaseCommands.CheckIn.Progress;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Player : MonoBehaviour
{
    public List<Transform> asteroidTransforms;
    public Transform enemyTransform;
    public GameObject bombPrefab;
    public Transform bombsTransform;
    public float targetSpeed = 3f;
    public float timeToReachTargetSpeed = 2f;

    private Vector3 velocity = Vector3.zero;
    private float acceleration;

    void Start()
    {
        acceleration = targetSpeed / timeToReachTargetSpeed;

        List<string> words = new List<string>();
        words.Add("Dog");
        //Dog[0]
        words.Add("Cat");
        //Dog[0],Cat[1]
        words.Add("Log");
        //Dog[0],Cat[1],Log[2]

        words.Insert(1, "Rat");
        //Dog[0],Rat[1],Cat[2],Log[3]

        words.Remove("Dog");
        //Rat[0],Cat[1],Log[2]

        Debug.Log("Index of the cat is: " + words.IndexOf("Cat"));

        for(int i = 0; i < words.Count; i++)
        {
            Debug.Log(words[i]);
        }
        foreach(string word in words)
        {
            Debug.Log(word);
        }
    }

    void Update()
    {
        // transform.position = transform.position + Vector3.right * 0.001f;
        PlayerMovement();
       
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


}
