using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    Rigidbody2D rb2D;
    Vector2 mousePos;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    public void Shoot(WeaponSO weaponSO)
    {
        mousePos = Camera.main.ScreenToWorldPoint((Vector2)Input.mousePosition);
        Vector2 forceVector = mousePos - (Vector2)transform.position;
        rb2D.AddForce(-forceVector.normalized * weaponSO.thrust, ForceMode2D.Impulse);
        //Debug.Log("Attacked: " + -forceVector.normalized * weaponSO.thrust);
    }
}
