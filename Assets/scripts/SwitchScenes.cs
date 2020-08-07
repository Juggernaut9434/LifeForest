using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScenes : MonoBehaviour
{
    /*
    Switching Scenes
    Can only switch scenes in Builds
    Before Builds, make sure to add Scenes to Build.
    */

    // public Object sceneToLoad;
    // Update is called once per frame
    void Start() {}
    void Update() 
    {
        if(Input.GetKey("c"))
            SceneManager.LoadScene("Level-1");
    }
}
