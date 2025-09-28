using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform playerTransform; // �v���C���[���w��
    [SerializeField] float followZ = -10f;      // Z���W�i���s���j
    [SerializeField] float cameraZoom = 5f;     // �C���X�y�N�^�[���璲������Y�[���l

    private Camera cam;

    void Start()
    {
        cam = GetComponent<Camera>();
        cam.orthographic = true; // 2D�Q�[���Ȃ琳���e�ɂ���
    }

    void LateUpdate()
    {
        // �v���C���[�Ǐ]
        if (playerTransform != null)
        {
            transform.position = new Vector3(playerTransform.position.x, playerTransform.position.y, followZ);
        }

        // �C���X�y�N�^�[�Őݒ肵���l�𔽉f
        cam.orthographicSize = cameraZoom;
    }
}
