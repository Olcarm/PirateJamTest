using UnityEngine;

public class WeaponVisual : MonoBehaviour
{
    private Vector3 mousePos;
    private Vector3 objectPos;
    private float angle;

    [SerializeField]
    private float rotationPerSecond;
    [SerializeField]
    private Rigidbody2D rb2D;
    [SerializeField]
    float torque = 500f;
    [SerializeField]
    float maxAngularVelocity = 100f;



    private bool confused = false;

    public void SetConfused()
    {
        confused = !confused;
        Debug.Log("Entered confused area");
    }

    private void FixedUpdate()
    {
        if (!confused)
        {
            HandleNormalState();
        }
        else
        {
            HandleConfusedState();
        }
    }

    private void HandleNormalState()
    {
        UpdateMousePosition();
        RotateTowardsMouse();
    }

    private void UpdateMousePosition()
    {
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPosition.z = 0;
        mousePos = mouseWorldPosition;
    }

    private void RotateTowardsMouse()
    {
        Vector2 direction = (mousePos - transform.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        float targetAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        float angleDifference = Mathf.DeltaAngle(rb2D.rotation, targetAngle);
        float torqueAmount = Mathf.Clamp(angleDifference, -1f, 1f) * torque;

        rb2D.AddTorque(torqueAmount);

        if (Mathf.Abs(rb2D.angularVelocity) > maxAngularVelocity)
        {
            rb2D.angularVelocity = Mathf.Sign(rb2D.angularVelocity) * maxAngularVelocity;
        }
        /*
        float horizontal = Input.GetAxis("Horizontal");
        rb2D.AddTorque(torque * horizontal);
        
        if (rb2D.angularVelocity > maxAngularVelocity)
        {
            rb2D.angularVelocity = maxAngularVelocity;
        }
        if(rb2D.angularVelocity < -maxAngularVelocity)
        {
            rb2D.angularVelocity = -maxAngularVelocity;
        }
        */
    }

    private void HandleConfusedState()
    {
        rb2D.rotation += rotationPerSecond * Time.fixedDeltaTime;
    }

    public Vector2 GetRotation()
    {
        return transform.right;
    }
}