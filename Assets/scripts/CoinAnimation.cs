using UnityEngine;

public class CoinAnimation : MonoBehaviour
{
    /*
    Animating a coin up and down and spinning
    */

    public float SpinSpeed = 1f;
    public float amplitude = 0.005f;
    public float frequency = 1f;

    Vector3 posOffset = new Vector3();
    Vector3 tempPos = new Vector3();

    void Start()
    {
        posOffset = transform.position;
        tempPos = posOffset;
    }

    // Update is called once per frame
    void Update()
    {
        // Rotate the coin. //x,y,z
        // only when game is not paused
        if(!UIManager.GameIsPaused)
            transform.Rotate(0,0, SpinSpeed);
        
        // Bounce up and down
        tempPos.y += Mathf.Sin(Time.deltaTime * Mathf.PI * frequency) * amplitude;

        transform.position = tempPos;
        
    }
}
