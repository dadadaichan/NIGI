using UnityEngine;

public class EnemyPlayerDetect : MonoBehaviour
{
    public GameObject player;
    public EnemyAttack enemyAttack;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if(col.gameObject == player)
        {
            enemyAttack.Attack();
        }
    }
}
