using System.Collections;
using UnityEngine;

public class EnemyScanner : MonoBehaviour
{
    public GameObject nearestObj;
    public GameObject lockOn;
    public GameObject playerCenter;
    public float lockOnInterval;
    public float lockOnAngle;
    public Vector3 dir;

    private GameObject preNearestObj;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(ScanEnemyTag());
        //lockOn.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator ScanEnemyTag()
    {
        while (true)
        {
            float distancePlayerToEnemy = float.MaxValue;//�ŏ��ɋ����̍ő����Ƃ����Ƃň��ڂɂǂ�Ȓl�����Ă��ł��Z�������Ɣ��肷�邽��

            foreach (GameObject o in EnemyManager.Instance.enemies)
            {
                float distancePlayerToElement = Vector3.Distance(this.gameObject.transform.position, o.transform.position);
                if (distancePlayerToElement < distancePlayerToEnemy)
                {
                    nearestObj = o;
                    distancePlayerToEnemy = distancePlayerToElement;
                }
            }

            if(nearestObj != null)
            {
                lockOn.SetActive(true);
                if(nearestObj != preNearestObj)
                {
                    lockOn.transform.SetParent(nearestObj.transform, false);
                    lockOn.transform.localPosition = new Vector3(0, 0, 0);
                    preNearestObj = nearestObj;
                }
            }
            else
            {
                lockOn.SetActive(false);
                nearestObj = null;
            }
            AngleCal();
                
            yield return new WaitForSeconds(lockOnInterval);
        }
    }

    public void AngleCal()
    {
        dir = (nearestObj.transform.position - playerCenter.transform.position).normalized;
        lockOnAngle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
    }
}
//�y�ڕW�z�v���C���[����ł��߂��G�����b�N�I������B
//1.���ׂĂ�Tag�uEnemy�v�̃I�u�W�F�N�g�������B�˔z��ɓ����B
//�����t���[�����Əd���Ȃ�A���A�G�������ꍇ���b�N�I�����r�Ԃ�B�ː��b�����Ɏ��s�B�iIEnumerator�ŃR���[�`���j
//2.�z����̈��̃I�u�W�F�N�g�ƃv���C���[�̋������v�Z�B�i�J��Ԃ������j
//��foreach(GameObject o in �z�񖼁j�Łu�z��̒��������o���āAo�ɑ�����ď������s���B�v��z��̏I���܂ŌJ��Ԃ��B
//3.����܂ł̍ŒZ�����I�u�W�F�N�g���z����̍ŒZ�����I�u�W�F�N�g�iif���j�ˌ�҂����b�N�I���B
