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
    //    Debug.Log("�g���K�[����o������: " + otherCollider.gameObject.name);
    //}

    void AttackStart()
    {
        playerGauge.GaugeDecrease(1);
        isAttacking = true;
        attackEffect.SetActive(true);
        attackEffect.transform.position = enemyScanner.playerCenter.transform.position + enemyScanner.dir * effectDistance;
        attackEffect.transform.rotation = Quaternion.Euler(0,0, enemyScanner.lockOnAngle);//���b�N�I�����������
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