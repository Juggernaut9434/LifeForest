using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class helloWorld : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Starting...");
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Updating");
        // teleport object forward in diection it is rotated
        transform.Translate(Vector3.forward * Time.deltaTime);
    }
}
