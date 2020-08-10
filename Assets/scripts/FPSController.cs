using UnityEngine;

public class FPSController : MonoBehaviour
{
    /*
    Moving Player and Camera.
    
    > Player <3D Objects>
        > PlayerPOV <Camera>
    
    Attach Script to (Player with CharacterController)
    Then Add Camera and Player to CharacterController
    */

    public CharacterController characterController;
 
     [Header("Camera")]
     /*
    Camera
    Mouse Sensitivity with default values
    InvertPitch inverts the up to down.
    Clamp constrains the Camera rotations with minY and maxY
     */
     public Camera cam;
     public float XSensitivity, YSensitivity;
     public bool invertPitch, clamp;
     public int minY, maxY;
 
     [Header("Movement")]
     public bool grounded = true, jumping = true;
     public float forwardSpeed, horizontalSpeed, jumpPower, gravity;
     
     [HideInInspector] public float jumpSpeed, verticalRotation;


     void Update() {
         // While Game is Paused, Don't move POV
         if(UIManager.GameIsPaused) return;

         // If falling off map, restart
         if( transform.position.y <= -6 ) UIManager.Restart();

         float mouseX = Input.GetAxis("Mouse X"), mouseY = Input.GetAxis("Mouse Y");
 
         if (!invertPitch)
             mouseY = -mouseY;
         verticalRotation += mouseY * YSensitivity;
         if (clamp)
             verticalRotation = Mathf.Clamp(verticalRotation, minY, maxY);
 
         transform.Rotate(0, mouseX * XSensitivity, 0);
         cam.transform.localRotation = Quaternion.Euler(verticalRotation, 0, 0);
 
        // Hide the Mouse when playing and not when game is paused
         if (Input.GetMouseButtonDown(0) && !UIManager.GameIsPaused)
             Cursor.lockState = CursorLockMode.Locked;
 
         float horizontal = Input.GetAxis("Horizontal"), forward = Input.GetAxis("Vertical");
 
         grounded = characterController.isGrounded;
 
         if (grounded) {
             jumping = false;
             jumpSpeed = 0;
         }
         else
             jumpSpeed -= (gravity * 25) * Time.deltaTime;
 
         if (Input.GetAxisRaw("Jump") != 0 && !jumping) {
             jumping = true;
             jumpSpeed = jumpPower;
         }
 
         Vector3 motion = new Vector3(horizontal * horizontalSpeed, jumpSpeed, forward * forwardSpeed);
         characterController.Move((transform.rotation * motion) * Time.deltaTime);
     }
}
