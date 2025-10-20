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
        attackEffect.transform.rotation = Quaternion.Euler(0, 0, enemyScanner.closeLockOnAngle + rot);//���b�N�I�����������
        animator.SetTrigger("AttackEffect");
        timer = attackDuration;
    }

    void EndAttack()
    {
        attackEffect.SetActive(false);
        isAttacking = false;
    }
}
//�y�ڕW�z�X�y�[�X��������A�U���G�t�F�N�g�A���肪�\�ɂȂ�B
//    1,�X�y�[�X��������Aattack�֐��Ăяo���B
//    2.attack�֐��ŁA�A�j���[�V�����̍Đ�(���b�N�I�����Ă������)�A�R���C�_�[�I�u�W�F�N�g�̗L����(���b�N�I�����Ă������)