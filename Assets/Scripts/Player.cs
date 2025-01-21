using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance;
    PlayerMovement playerMovement;

    [SerializeField]
    private WeaponSO currentWeapon;

    [SerializeField]
    private WeaponSO startingWeapon;

    float currentAmmo;
    float maxAmmo;

    float tempCurrentAmmo;
    float tempMaxAmmo;

    bool isTempWeapon;

    float timer;

    /*
        [SerializeField]
        List<Weapons> weaponsList;

        [Serializable]
        public class Weapons{
            public string name;
            public int currentAmmo;
            public WeaponSO weaponSO;

            public Weapons(WeaponSO weaponSO){
                this.weaponSO = weaponSO;
                name = weaponSO.name;
                currentAmmo = weaponSO.ammoCount;
            }
        }
    */
    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        currentWeapon = startingWeapon;
        maxAmmo = currentWeapon.ammoCount;
        currentAmmo = maxAmmo;
        playerMovement = GetComponent<PlayerMovement>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            TryToShoot();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            Reload();
        }
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            currentWeapon = startingWeapon;
            isTempWeapon = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<ICollectible>(out ICollectible collectible))
        {
            collectible.Collect();
        }
    }
    public void SetupWeapon(WeaponSO weapon, float duration)
    {
        currentWeapon = weapon;
        tempMaxAmmo = weapon.ammoCount;
        tempCurrentAmmo = tempMaxAmmo;
        isTempWeapon = true;
        timer = duration;
        Debug.Log("Switched to weapon: " + currentWeapon.name + " for " + duration + " seconds");
    }


    bool IsGrounded()
    {
        return GetComponent<Rigidbody2D>().linearVelocityY == 0;
    }

    void TryToShoot()
    {
        if (isTempWeapon && tempCurrentAmmo <= 0)
        {
            return;
        }
        else if (!isTempWeapon && currentAmmo <= 0)
        {
            return;
        }
        playerMovement.Shoot(currentWeapon);
        if (isTempWeapon) tempCurrentAmmo--;
        else currentAmmo--;
    }
    void Reload()
    {
        if (IsGrounded())
        {
            if (isTempWeapon)
            {
                tempCurrentAmmo = tempMaxAmmo;
            }
            else
            {
                currentAmmo = maxAmmo;
            }

        }
        else
        {
            Debug.Log("Not grounded");
        }
    }
}
