using UnityEngine;

public class ShotgunCollectible : MonoBehaviour, ICollectible
{

    [SerializeField]
    private WeaponSO weaponSO;
    [SerializeField]
    private float duration;

    public void Collect()
    {
        Player.Instance.SetupWeapon(weaponSO, duration);
        Destroy(this.gameObject);
    }
}
