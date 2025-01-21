using UnityEngine;

public class WeaponVisual : MonoBehaviour
{
    Vector3 mousePos;
    Vector3 objectPos;
    float angle;
    float rotation = 0;

    [SerializeField]
    float rotationPerSecond;

    bool confused = false;
    public void SetConfused()
    {
        confused = !confused;
        Debug.Log("Entered confused area");
    }

    private void Update()
    {
        if (!confused)
        {
            mousePos = Input.mousePosition;
            mousePos.z = 20f;
            objectPos = Camera.main.WorldToScreenPoint(transform.position);
            mousePos.x = mousePos.x - objectPos.x;
            mousePos.y = mousePos.y - objectPos.y;
            angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }
        else{
            ConfusedState();
        }

    }

    public Vector2 GetRotation(){
        return transform.right;
    }

    void ConfusedState(){
        rotation += Time.deltaTime * rotationPerSecond;
        transform.rotation = Quaternion.Euler(0, 0, rotation);
    }
}
