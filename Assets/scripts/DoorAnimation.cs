using System.Collections;
using UnityEngine;

public class DoorAnimation : MonoBehaviour
{
    /*
    attach to DoorHolder, or anywhere appropriate
    Animation 101
    Window > Animation : for making animations
    Window > Animator : for sequencing animations

    Animation
        > Add a KeyFrame Before making adjustments
    Animator
        > Mapping the animations
        > could add parameters too which can be
        changed in this script.
    */

    private Animator _animator = null;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update() {}

    void OnTriggerEnter(Collider other)
    {
        _animator.SetBool("isOpen", true);
    }
    void OnTriggerExit(Collider other)
    {
        _animator.SetBool("isOpen", false);
    }
}
