using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField]
    Transform respawnPosition;

    public Transform GetRespawnPoint(){
        return respawnPosition;
    }
}
