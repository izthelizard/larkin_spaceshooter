using Codice.CM.Client.Differences;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrigExercise : MonoBehaviour
{
    public List<float> angles = new List<float>() { 0, 55, 70, 105, 130, 185, 220, 265, 295, 305 };

    // Start is called before the first frame update
    void Start()
    {

        Debug.Log("Mathf.Cos(45): " + Mathf.Cos(45 * Mathf.Deg2Rad));
        Debug.Log("Mathf.Cos(-45): " + Mathf.Cos(-45 * Mathf.Deg2Rad));
        Debug.Log("Mathf.Acos(0.7071068): " + Mathf.Acos(0.7071068f) * Mathf.Rad2Deg);

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 startingPosition = Vector3.zero;
        float x = Mathf.Cos(Mathf.Deg2Rad * angles[0]);
        float y = Mathf.Sin(Mathf.Deg2Rad * angles[0]);
        Vector3 endingPosition = new Vector3(x, y);

        Debug.DrawLine(startingPosition, endingPosition, Color.yellow);

        if (Input.GetKey(KeyCode.Space))
        {
            
        }
    }
}
