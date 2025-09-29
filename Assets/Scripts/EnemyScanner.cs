using System.Collections;
using UnityEngine;

public class EnemyScanner : MonoBehaviour
{
    public GameObject closestObj;
    //public GameObject longClosestObj;
    public GameObject closeLockOn;
    //public GameObject longLockOn;
    public GameObject closestPlayerCenter;
    //public GameObject longClosestPlayerCenter;

    public float lockOnInterval;
    public float closeLockOnAngle;
    //public float longLockOnAngle;
    public float closeLockOnScale;
    //public float longLockOnScale;
    public Vector3 dir;
    //public Vector3 dirLong;

    private GameObject preClosestObj;
    //private GameObject preLongClosestObj;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(ScanEnemy());
        //lockOn.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (closestObj == null)
        {
            if (closeLockOn != null)  // �����Ń`�F�b�N
            {
                closeLockOn.SetActive(false);
            }
        }

        //if (longClosestObj == null)
        //{
        //    if (longLockOn != null)  // �����Ń`�F�b�N
        //    {
        //        longLockOn.SetActive(false);
        //    }
        //}
    }

    IEnumerator ScanEnemy()
    {
        while (true)
        {
            float preDistancePlayerToEnemy = float.MaxValue;
            GameObject candidate = null;

            foreach (GameObject o in EnemyManager.Instance.closeRangeEnemies)
            {
                if (o == null || o.Equals(null)) continue; // Destroy���ꂽ�G�͖���

                float distance = Vector3.Distance(transform.position, o.transform.position);
                if (distance < preDistancePlayerToEnemy)
                {
                    candidate = o;
                    preDistancePlayerToEnemy = distance;
                }
            }

            closestObj = candidate;

            if (closestObj != null && closestObj.CompareTag("CloseRangeEnemy"))
            {
                if (closeLockOn != null && !closeLockOn.Equals(null))
                {
                    closeLockOn.SetActive(true);
                    if (closestObj != preClosestObj)
                    {
                        closeLockOn.transform.SetParent(closestObj.transform, true);
                        closeLockOn.transform.localScale = new Vector3(closeLockOnScale, closeLockOnScale, 1);
                        closeLockOn.transform.localPosition = Vector3.zero;

                        preClosestObj = closestObj;
                    }
                }
            }
            else
            {
                // �G�����Ȃ� or Destroy���ꂽ��LockOn��\��
                if (closeLockOn != null && !closeLockOn.Equals(null))
                {
                    closeLockOn.SetActive(false);
                }
                closestObj = null;
            }

            if (closestObj != null && !closestObj.Equals(null))
            {
                dir = (closestObj.transform.position - closestPlayerCenter.transform.position).normalized;
                closeLockOnAngle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            }

            yield return new WaitForSeconds(lockOnInterval);
        }
    }


    //public void AngleCal()
    //{
    //    if(nearestObj != null)
    //    {
    //        dir = (nearestObj.transform.position - playerCenter.transform.position).normalized;
    //        lockOnAngle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
    //    }
    //    //dir = (nearestObj.transform.position - playerCenter.transform.position).normalized;
    //    //lockOnAngle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
    //}
}
//�y�ڕW�z�v���C���[����ł��߂��G�����b�N�I������B
//1.���ׂĂ�Tag�uEnemy�v�̃I�u�W�F�N�g�������B�˔z��ɓ����B
//�����t���[�����Əd���Ȃ�A���A�G�������ꍇ���b�N�I�����r�Ԃ�B�ː��b�����Ɏ��s�B�iIEnumerator�ŃR���[�`���j
//2.�z����̈��̃I�u�W�F�N�g�ƃv���C���[�̋������v�Z�B�i�J��Ԃ������j
//��foreach(GameObject o in �z�񖼁j�Łu�z��̒��������o���āAo�ɑ�����ď������s���B�v��z��̏I���܂ŌJ��Ԃ��B
//3.����܂ł̍ŒZ�����I�u�W�F�N�g���z����̍ŒZ�����I�u�W�F�N�g�iif���j�ˌ�҂����b�N�I���B
