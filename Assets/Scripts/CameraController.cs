using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform playerTransform; // プレイヤーを指定
    [SerializeField] float followZ = -10f;      // Z座標（奥行き）
    [SerializeField] float cameraZoom = 5f;     // インスペクターから調整するズーム値

    private Camera cam;

    void Start()
    {
        cam = GetComponent<Camera>();
        cam.orthographic = true; // 2Dゲームなら正投影にする
    }

    void LateUpdate()
    {
        // プレイヤー追従
        if (playerTransform != null)
        {
            transform.position = new Vector3(playerTransform.position.x, playerTransform.position.y, followZ);
        }

        // インスペクターで設定した値を反映
        cam.orthographicSize = cameraZoom;
    }
}
