using UnityEngine;

public class Attack : MonoBehaviour
{
    public Animator animator;
    public Animator AXAnim;
    public GameObject AX;
    public GameObject attackEffect;
    public float attackDuration;
    public EnemyScanner enemyScanner;
    public float effectDistance;
    public GameObject player;
    public PlayerGauge playerGauge;
    public float rot;
    private bool isAXReady = false;

    private float timer = 0f;
    public bool isAttacking = false;
    private void Start()
    {
        animator = GetComponentInChildren<Animator>(true);
        AXAnim = AX.GetComponent<Animator>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (!isAXReady)
            {
                isAXReady = true;
                AXAnim.SetBool("isAXReady", true);
            }
            else if (isAXReady)
            {
                isAXReady = false;
                AXAnim.SetBool("isAXReady", false);
            }
        }

        if (Input.GetKeyDown(KeyCode.Space) && isAXReady)
        {
            if (!playerGauge.isZeroGauge)
            {
                AttackStart();
            }
            else
            {

            }
        }

        if (isAttacking)
        {
            timer -= Time.deltaTime;
            if (timer <= 0f)
            {
                EndAttack();
            }
        }
    }
    void AttackStart()
    {
        isAttacking = true;
        AXAnim.SetTrigger("AXAttack");
        playerGauge.GaugeDecrease(1);
        attackEffect.SetActive(true);
        attackEffect.transform.position = enemyScanner.closestPlayerCenter.transform.position + enemyScanner.dir * effectDistance;
        attackEffect.transform.rotation = Quaternion.Euler(0, 0, enemyScanner.closeLockOnAngle + rot);//ロックオン方向を入力
        animator.SetTrigger("AttackEffect");
        timer = attackDuration;
    }

    void EndAttack()
    {
        attackEffect.SetActive(false);
        isAttacking = false;
    }
}
//【目標】スペース押したら、攻撃エフェクト、判定が可能になる。
//    1,スペースおしたら、attack関数呼び出す。
//    2.attack関数で、アニメーションの再生(ロックオンしてる方向に)、コライダーオブジェクトの有効化(ロックオンしてる方向に)