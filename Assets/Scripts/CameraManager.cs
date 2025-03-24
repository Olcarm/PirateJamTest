using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public static CameraManager Instance;

    [SerializeField]
    private GameObject mainCamera;

    [SerializeField]
    private GameObject player;


    private void Awake() {
        Instance = this;
    }

    public void SetCameraTransform(Vector2 moveToPos){
        
        
        mainCamera.transform.position = new Vector3(moveToPos.x, moveToPos.y, -10f);
    }
    private void Update()
    {
        FollowPlayer();
    }
    public Vector2 GetCameraTransform(){
        return mainCamera.transform.position;
    }

    public void FollowPlayer(){
        mainCamera.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -10f);

    }
}
