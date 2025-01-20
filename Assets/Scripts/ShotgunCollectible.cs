using UnityEngine;

public class ShotgunCollectible : MonoBehaviour, ICollectible
{

    [SerializeField]
    private WeaponSO weaponSO;

    public void Collect()
    {
        Player.Instance.AddWeapon(weaponSO);
        Destroy(this.gameObject);
    }
}
