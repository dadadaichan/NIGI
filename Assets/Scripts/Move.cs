using UnityEngine;

public class Move : MonoBehaviour
{
    public float moveSpeed = 5f;

    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal"); // ←→キー: -1,0,1
        float v = Input.GetAxisRaw("Vertical");   // ↑↓キー: -1,0,1

        Vector3 move = new Vector3(h, v, 0).normalized;

        transform.Translate(move * moveSpeed * Time.deltaTime, Space.World);
    }
}

