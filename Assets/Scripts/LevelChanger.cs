using UnityEngine;

public class LevelChanger : MonoBehaviour
{
    [SerializeField]
    Vector2 cameraPos1;
    [SerializeField]
    Vector2 cameraPos2;

    Vector2 currentCameraPosition;

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Next Level");
            currentCameraPosition = CameraManager.Instance.GetCameraTransform();

            if (currentCameraPosition == cameraPos1)
            {
                if (other.transform.position.y > transform.position.y)
                {
                    CameraManager.Instance.SetCameraTransform(cameraPos2);
                }
            }
            else
            {
                if (other.transform.position.y < transform.position.y)
                {
                    CameraManager.Instance.SetCameraTransform(cameraPos1);
                }

            }
        }
    }
}
