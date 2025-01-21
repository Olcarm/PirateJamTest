using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    Rigidbody2D rb2D;
    Vector2 mousePos;
    [SerializeField]
    WeaponVisual weaponVisual;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    public void Shoot(WeaponSO weaponSO)
    {
        Vector2 forceVector = weaponVisual.GetRotation();
        rb2D.AddForce(-forceVector.normalized * weaponSO.thrust, ForceMode2D.Impulse);
        Debug.Log("Attacked: " + -forceVector.normalized * weaponSO.thrust);
    }
}
