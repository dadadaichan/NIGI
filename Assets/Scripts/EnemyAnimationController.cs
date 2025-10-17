using Unity.VisualScripting;
using UnityEngine;

public class EnemyAnimationController : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private SpriteRenderer childSpriteRenderer;
    private Animator animator;
    private Vector2 lastPos;
    private Vector2 currentPos;
    private Vector3 weaponPosR;
    private Vector3 weaponPosL;

    [SerializeField]
    private GameObject weapon;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lastPos = transform.position;
        spriteRenderer = GetComponent<SpriteRenderer>();
        childSpriteRenderer = weapon.GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        weaponPosR = weapon.transform.localPosition;
        weaponPosR.y = weapon.transform.localPosition.y;
        weaponPosL = -weapon.transform.localPosition;
        weaponPosL.y = weapon.transform.localPosition.y;
    }

    // Update is called once per frame
    void Update()
    {
        currentPos = transform.position;
        float dir = currentPos.x - lastPos.x;
        if(dir > 0)
        {
            ////Debug.Log("âEÇ…êiÇÒÇ≈Ç¢ÇÈ");
            //spriteRenderer.flipX = false;
            //childSpriteRenderer.flipX = false;
            //weapon.transform.localPosition = weaponPosR;
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (dir < 0)
        {
            ////Debug.Log("ç∂Ç…êiÇÒÇ≈Ç¢ÇÈ");
            //spriteRenderer.flipX = true;
            //childSpriteRenderer.flipX = true;
            //weapon.transform.localPosition = weaponPosL;
            transform.localScale = new Vector3(-1, 1, 1);
        }
        lastPos = currentPos;
    }

    private void OnTriggerExit2D(Collider2D otherCol)
    {
        if(otherCol.gameObject.name == "Tilemap(Ground)")
        {
            animator.SetBool("isSwim", true);
        }
    }
}
