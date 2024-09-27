using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    public Transform mark;
    public float enemySpeed = 2f;
    public float playerDistance = 1f;
  

    private void Start()
    {
        mark = GameObject.Find("Player").transform;
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, mark.position, enemySpeed * Time.deltaTime);

    }

}
