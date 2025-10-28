using UnityEngine;
using UnityEngine.InputSystem;

public class Lander : MonoBehaviour
{
    private Rigidbody2D landerRigidbody2D;

    // References for this one Game Object
    private void Awake() {
        landerRigidbody2D = GetComponent<Rigidbody2D>();

        Debug.Log(Vector2.Dot(new Vector2(0, 1), new Vector2(0, 1)));
        Debug.Log(Vector2.Dot(new Vector2(0, 1), new Vector2(.5f, .5f)));
        Debug.Log(Vector2.Dot(new Vector2(0, 1), new Vector2(1, 0)));
        Debug.Log(Vector2.Dot(new Vector2(0, 1), new Vector2(0, -1)));
    }

    // External References (not in this Game Object)
    private void Start() {
        
    }

    // Special method working with physics (BUT NOT FOR MOUSE CLICKs)
    // Project Setting/Time/Fixed Timestep - refresh rate of physics move
    private void FixedUpdate()
    {
        if (Keyboard.current.upArrowKey.isPressed) {
            float force = 700f;
            // adding force depending of rotation
            landerRigidbody2D.AddForce(force * transform.up * Time.deltaTime);
        }
        if (Keyboard.current.leftArrowKey.isPressed) {
            float turnSpeed = +100f;
            // rotate to right
            landerRigidbody2D.AddTorque(turnSpeed * Time.deltaTime);
        }
        if (Keyboard.current.rightArrowKey.isPressed) {
            float turnSpeed = -100f;
            // rotate to right
            landerRigidbody2D.AddTorque(turnSpeed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision2D)
    {
        float relativeVelocityMagnitude = 4f;
        if (collision2D.relativeVelocity.magnitude > relativeVelocityMagnitude)
        {
            Debug.Log("Landing too hard");
            return;
        }

        float dotVector = Vector2.Dot(Vector2.up, transform.up);
        float minDotVector = .90f;
        if (dotVector < minDotVector)
        {
            // Landed on a too step angle!
            Debug.Log("Landed on a too step angle!");
            return;
        }

        Debug.Log("Success");
    }
}
