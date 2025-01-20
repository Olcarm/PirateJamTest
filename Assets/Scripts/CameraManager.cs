using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public static CameraManager Instance;

    [SerializeField]
    private GameObject mainCamera;


    private void Awake() {
        Instance = this;
    }

    public void SetCameraTransform(Vector2 moveToPos){
        
        
        mainCamera.transform.position = new Vector3(moveToPos.x, moveToPos.y, -10f);
    }

    public Vector2 GetCameraTransform(){
        return mainCamera.transform.position;
    }

    public void SetFollowPlayer(){

    }
}
