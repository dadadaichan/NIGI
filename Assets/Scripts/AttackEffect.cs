using UnityEngine;

public class AttackEffect : MonoBehaviour
{
    public Animator animator;
    public GameObject attackEffect;
    public float attackDuration;
    public EnemyScanner enemyScanner;
    public float effectDistance;
    public GameObject player;
    public PlayerGauge playerGauge;

    private float timer = 0f;
    public bool isAttacking = false;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponentInChildren<Animator>(true);
        //if (attackEffect.activeSelf == true)attackEffect.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            AttackStart();
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

    //void OnTriggerExit2D(Collider2D otherCollider)
    //{
    //    Debug.Log("トリガーから出た相手: " + otherCollider.gameObject.name);
    //}

    void AttackStart()
    {
        playerGauge.GaugeDecrease(1);
        isAttacking = true;
        attackEffect.SetActive(true);
        attackEffect.transform.position = enemyScanner.playerCenter.transform.position + enemyScanner.dir * effectDistance;
        attackEffect.transform.rotation = Quaternion.Euler(0,0, enemyScanner.lockOnAngle);//ロックオン方向を入力
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