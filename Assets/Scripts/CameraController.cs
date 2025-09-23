using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform playerTransform;
    [SerializeField] float cameraZoomOut;

    private void Update()
    {
        transform.position = new Vector3(playerTransform.position.x, playerTransform.position.y, -cameraZoomOut);
    }
}
