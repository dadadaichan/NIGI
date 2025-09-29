using System.Collections.Generic;
using UnityEngine;

public class ArrowRange : MonoBehaviour
{
    public CapsuleCollider2D col;
    public float area;
    public int maxTargets = 5;
    public List<GameObject> targets = new List<GameObject>();
    public GameObject arrowLockOnPf;
    public PlayerGauge playerGauge;
    public int arrowGaugeDecrease;
    public bool isArrowFire = false;

    // �����������b�N�I���I�u�W�F�N�g���Ǘ����郊�X�g
    private List<GameObject> activeLockOns = new List<GameObject>();

    private Vector3 baseScale;

    void Start()
    {
        baseScale = transform.localScale;
        col = GetComponent<CapsuleCollider2D>();
        col.enabled = false;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.S))
        {
            //col.enabled = true;
            //transform.localScale += new Vector3(area, area, 0); // += �ɂ���Ɩ��t���[���g�債������̂ŏC��

            //// �܂����b�N�I���}�[�J�[���t���Ă��Ȃ��G�ɂ�������
            //foreach (GameObject arrowTarget in new List<GameObject>(targets)) // �R�s�[����foreach
            //{
            //    if (arrowTarget != null && !HasLockOn(arrowTarget))
            //    {
            //        GameObject lockOn = Instantiate(arrowLockOnPf, arrowTarget.transform.position, Quaternion.identity);
            //        lockOn.transform.SetParent(arrowTarget.transform, false); // �q�ɂ���
            //        lockOn.transform.localPosition = Vector3.zero;            // �G�̒��S�ɔz�u
            //        activeLockOns.Add(lockOn);                                // ���X�g�ɓo�^
            //    }
            //}
            if (!playerGauge.isZeroGauge)
            {
                ArrowLoad();
            }
            
        }

        if (Input.GetKeyUp(KeyCode.S))
        {
            //playerGauge.GaugeDecrease(arrowGaugeDecrease);
            //// �S���b�N�I���폜
            //foreach (GameObject lockOn in activeLockOns)
            //{
            //    if (lockOn != null)
            //        Destroy(lockOn);
            //}
            //activeLockOns.Clear();

            //// ���b�N�I�������G�����ׂĔj��
            //foreach (GameObject arrowTarget in new List<GameObject>(targets))
            //{
            //    if (arrowTarget != null)
            //    {
            //        Destroy(arrowTarget);
            //    }
            //}
            //targets.Clear();

            //transform.localScale = baseScale;
            //col.enabled = false;
            if (!playerGauge.isZeroGauge)
            {
                ArrowFire();
            }
        }
    }

    private void ArrowLoad()
    {
        col.enabled = true;
        transform.localScale += new Vector3(area, area, 0); // += �ɂ���Ɩ��t���[���g�債������̂ŏC��

        // �܂����b�N�I���}�[�J�[���t���Ă��Ȃ��G�ɂ�������
        foreach (GameObject arrowTarget in new List<GameObject>(targets)) // �R�s�[����foreach
        {
            if (arrowTarget != null && !HasLockOn(arrowTarget))
            {
                GameObject lockOn = Instantiate(arrowLockOnPf, arrowTarget.transform.position, Quaternion.identity);
                lockOn.transform.SetParent(arrowTarget.transform, false); // �q�ɂ���
                lockOn.transform.localPosition = Vector3.zero;            // �G�̒��S�ɔz�u
                activeLockOns.Add(lockOn);                                // ���X�g�ɓo�^
            }
        }
        isArrowFire = true;
    }

    private void ArrowFire()
    {
        playerGauge.GaugeDecrease(arrowGaugeDecrease);
        // �S���b�N�I���폜
        foreach (GameObject lockOn in activeLockOns)
        {
            if (lockOn != null)
                Destroy(lockOn);
        }
        activeLockOns.Clear();

        // ���b�N�I�������G�����ׂĔj��
        foreach (GameObject arrowTarget in new List<GameObject>(targets))
        {
            if (arrowTarget != null)
            {
                Destroy(arrowTarget);
            }
        }
        targets.Clear();

        transform.localScale = baseScale;
        col.enabled = false;
        isArrowFire = false;
    }

    private bool HasLockOn(GameObject target)
    {
        foreach (GameObject lockOn in activeLockOns)
        {
            if (lockOn != null && lockOn.transform.parent == target.transform)
                return true;
        }
        return false;
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

    private void OnTriggerExit2D(Collider2D other)
    {
        if (targets.Contains(other.gameObject))
        {
            targets.Remove(other.gameObject);
            Debug.Log("�G���폜: " + other.name);
        }
    }
}
