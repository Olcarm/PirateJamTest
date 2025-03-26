using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rb2D;
    Vector2 mousePos;

    private Vector2 forcePosition;

    [SerializeField]
    WeaponVisual weaponVisual;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        forcePosition = new Vector2(transform.position.x, transform.position.y + 0.1f);
    }

    public void Shoot(WeaponSO weaponSO)
    {
        Vector2 forceVector = transform.right;
        rb2D.AddForce(-forceVector.normalized * weaponSO.thrust, ForceMode2D.Impulse);
        Debug.Log("Attacked: " + -forceVector.normalized * weaponSO.thrust);
    }
}
