using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance;
    PlayerMovement playerMovement;
    
    [SerializeField]
    private Weapons currentWeapon;

    [SerializeField]
    private WeaponSO startingWeapon;

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
    private void Awake() {
        Instance = this;
    }
    void Start()
    {
        AddWeapon(startingWeapon);
        currentWeapon = weaponsList[0];
        SetupWeapon(currentWeapon);
        playerMovement = GetComponent<PlayerMovement>();
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0) && currentWeapon.currentAmmo > 0){
            playerMovement.Shoot(currentWeapon.weaponSO);
            currentWeapon.currentAmmo--;
        }
        if(Input.GetKeyDown(KeyCode.Alpha1)){
            currentWeapon = weaponsList[0];
            SetupWeapon(currentWeapon);
            
        }
        if(Input.GetKeyDown(KeyCode.Alpha2) && weaponsList.Count >= 2){
            currentWeapon = weaponsList[1];
            SetupWeapon(currentWeapon);
        }
        if(Input.GetKeyDown(KeyCode.R)){
            if(IsGrounded()){
                currentWeapon.currentAmmo = currentWeapon.weaponSO.ammoCount;
            }
            else{
                Debug.Log("Not grounded");
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.TryGetComponent<ICollectible>(out ICollectible collectible)){
            collectible.Collect();
        }
    }
    void SetupWeapon(Weapons weapon){
        currentWeapon = weapon;
        Debug.Log("Switched to weapon: " + currentWeapon.weaponSO.name);
    }
    public void AddWeapon(WeaponSO weaponSO){
        Weapons newWeapon = new Weapons(weaponSO);
        weaponsList.Add(newWeapon);
    }
    
    bool IsGrounded(){
        return GetComponent<Rigidbody2D>().linearVelocityY == 0;
    }

    

}
