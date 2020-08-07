using UnityEngine;
using System.Collections;

public class DestoryTrigger : MonoBehaviour
{
    /*
    Destory's game object when collided.
    Make sure to turn on isTrigger under Collider in Unity
    */

    // happens on trigger event is true
    void OnTriggerEnter(Collider other)
    {
        // destroys the object thats not attached to the script
        // Destroy(other.gameObject)

        // Destroys the object that IS attached to script
        Destroy(gameObject);
    }

    /* Happens on trigger event after true but now false
    void OnTriggerExit(Collider other) {}
    */
    void Start() {}
    void Update() {}
}
