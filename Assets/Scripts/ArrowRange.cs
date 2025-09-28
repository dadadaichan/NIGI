using System.Collections.Generic;
using UnityEngine;

public class ArrowRange : MonoBehaviour
{
    public CapsuleCollider2D col;
    public float area;
    public int maxTargets = 5;
    public List<GameObject> targets = new List<GameObject>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        col = this.gameObject.GetComponent<CapsuleCollider2D>();
        col.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.S))
        {
            //コライダー表示
            col.enabled = true;
            col.size += new Vector2(area, area);
        }

        if (Input.GetKeyUp(KeyCode.S))
        {
            col.size = new Vector2(0.2f, 0.2f);
            col.enabled = false;
            //攻撃開始、コライダー元サイズに変更、コライダー非表示
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("CloseRangeEnemy") && !targets.Contains(other.gameObject))
        {
            if (targets.Count < maxTargets)
            {
                targets.Add(other.gameObject);
                Debug.Log("敵を追加: " + other.name);
            }
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
   
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (targets.Contains(other.gameObject))
        {
            targets.Remove(other.gameObject);
            Debug.Log("敵を削除: " + other.name);
        }
    }
}
