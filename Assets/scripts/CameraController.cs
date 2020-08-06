using UnityEngine;

public class CameraController : MonoBehaviour
{
    // character Controller from Unity component
    public CharacterController controller;

    public float speed = 6f;

    // turning smoothly
    public float turnSmoothlyTime = 0.1f;
    float turnSmoothVelocity;

    void Update()
    {
        // wasd
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        // x,y,z
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            
            // orientating object to face camera looking
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            ;
            // adjusts snappy ness of turning to more smooth
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothlyTime);
            // rotates object
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            // moving object
            controller.Move(direction * speed * Time.deltaTime);
        }
    
    }
}
