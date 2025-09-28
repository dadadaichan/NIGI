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
            //�R���C�_�[�\��
            col.enabled = true;
            col.size += new Vector2(area, area);
        }

        if (Input.GetKeyUp(KeyCode.S))
        {
            col.size = new Vector2(0.2f, 0.2f);
            col.enabled = false;
            //�U���J�n�A�R���C�_�[���T�C�Y�ɕύX�A�R���C�_�[��\��
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("CloseRangeEnemy") && !targets.Contains(other.gameObject))
        {
            if (targets.Count < maxTargets)
            {
                targets.Add(other.gameObject);
                Debug.Log("�G��ǉ�: " + other.name);
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
            Debug.Log("�G���폜: " + other.name);
        }
    }
}
