using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Vector2 lastPos;
    private Vector2 currentPos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lastPos = transform.position;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        currentPos = transform.position;
        float dir = currentPos.x - lastPos.x;
        if (dir > 0)
        {
            Debug.Log("�E�ɐi��ł���");
            spriteRenderer.flipX = false;
        }
        else if (dir < 0)
        {
            Debug.Log("���ɐi��ł���");
            spriteRenderer.flipX = true;
        }
        lastPos = currentPos;
    }
}
