using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float arrivalDistance = 2f;
    public float maxFloatDistance = 2f;

    Vector3 newDirection;

    // Start is called before the first frame update
    void Start()
    {
        
        changeDirection();
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, newDirection, Time.deltaTime * moveSpeed);

        if(Vector2.Distance(transform.position, newDirection) <= arrivalDistance )
        {
            changeDirection();
        }
    }

    private void changeDirection()
    {
        newDirection = new Vector2(Random.Range(-5f, 5f), Random.Range(-5f, 5f));
    }
}
