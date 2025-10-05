using UnityEngine;

public class enemyAttack : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private float attackDistance;
    [SerializeField] private Animator enemyAttackAnim;
    private float distance;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        enemyAttackAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(this.gameObject.transform.position, player.transform.position);
        if(distance < attackDistance)
        {

        }
    }
}
