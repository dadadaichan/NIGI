using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private float spawnDistance;
    [SerializeField] private int spawnCount;
    [SerializeField] private float spawnInterval;
    [SerializeField] private float elipsedTime = 0;
    [SerializeField] private GameObject playerGameObject;
    [SerializeField] private SteeringBehaviour steeringBehaviour;
    [SerializeField] private int maxEnemy;
    [SerializeField] private int currentEnemy = 0;
    [SerializeField] private EnemyManager enemyManager;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentEnemy = enemyManager.closeRangeEnemies.Count;
    }

    private void OnTriggerStay2D(Collider2D player)
    {
        if (player.gameObject == playerGameObject)
        {
            elipsedTime += Time.deltaTime;
            if(elipsedTime > spawnInterval && currentEnemy < maxEnemy)
            {
                elipsedTime = 0;
                SpawnEnemy();
            }
        }
    }

    private void SpawnEnemy()
    {
        if (enemyPrefab != null)
        {
            for(int i = 0; i < spawnCount; i++)
            {
                Vector2 randomDir = Random.insideUnitCircle.normalized;
                Vector3 spawnPos = playerGameObject.transform.position + (Vector3)randomDir * spawnDistance;
                GameObject Senemy = Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
                steeringBehaviour = Senemy.GetComponent<SteeringBehaviour>();
                steeringBehaviour.targetTransform = playerGameObject.transform;
                Senemy.name = "Senemy" + i;
            }           
        }
        
    }
}
