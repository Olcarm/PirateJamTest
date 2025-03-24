using UnityEngine;

public class WeaponVisual : MonoBehaviour
{
    private Vector3 mousePos;
    private Vector3 objectPos;
    private float angle;
    private float rotation = 0;

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
        /*
        rb2D.rotation = angle;
        */
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        float horizontal = Input.GetAxis("Horizontal");
        rb2D.AddTorque(-torque * horizontal);
        if(rb2D.angularVelocity > maxAngularVelocity)
        {
            rb2D.angularVelocity = maxAngularVelocity;
        }
        if(rb2D.angularVelocity < -maxAngularVelocity)
        {
            rb2D.angularVelocity = -maxAngularVelocity;
        }

    }

    private void HandleConfusedState()
    {
        rotation += Time.deltaTime * rotationPerSecond;
        transform.rotation = Quaternion.Euler(0, 0, rotation);
    }

    public Vector2 GetRotation()
    {
        return transform.right;
    }
}