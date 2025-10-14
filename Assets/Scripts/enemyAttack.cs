using System.Threading;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    CircleCollider2D detectCol;
    Animator Anim;
    public PlayerHP playerHP;
    public GameObject player;

    public int interval;
    public GameObject child;
    public float atDis;
    public int count = 0;
    public GameObject detectArea;

    private Vector3 dir;
    private float angle;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        detectCol = detectArea.GetComponent<CircleCollider2D>();
        Anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //private void OnTriggerStay2D(Collider2D col)
    //{
    //    if(col.gameObject == player)
    //    {
    //        //count++;
    //        //if (count > interval)
    //        //{
    //        //    Anim.SetTrigger("enemyAttack");
    //        //    DirCalculation();
    //        //    child.SetActive(true);
    //        //    playerHP.TakeDamage(1);
    //        //    count = 0;
    //        //}
    //        ////ifelse(アニメーション終わったら)
    //        ////{
    //        ////    childCol.SetActive(false);    
    //        ////}
    //    }
    //}

    public void Attack()
    {
        count++;
        if (count > interval)
        {
            Anim.SetTrigger("enemyAttack");
            DirCalculation();
            child.SetActive(true);
            playerHP.TakeDamage(1);
            count = 0;
        }
        //ifelse(アニメーション終わったら)
        //{
        //    childCol.SetActive(false);    
        //}
    }

    private void DirCalculation()
    {
        dir = (this.gameObject.transform.position - player.transform.position).normalized;//方向ベクトル求めれた？
        angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        child.transform.rotation = Quaternion.Euler(0, 0, angle);
        child.transform.position = this.transform.position - dir*atDis;
    }
}
