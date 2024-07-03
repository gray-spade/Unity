using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    //���� �ʱ�ȭ
    [SerializeField]float spawnTime=0.5f;       //���� ��ȯ�ֱ�
    float Min = -7;                             //��ȯ����z�ּ� 
    float Max = 7;                              //��ȯ����z�ִ�
    float time = 0;                             //Ÿ�̸� ����� ����
    float Maxtime = 30;                         //���� ��ȭ �ֱ�

    [SerializeField] float hpScale = 1.02f;     //����hp ������
    [SerializeField] float attScale = 0.25f;    //���� ���ݷ� ������
    [SerializeField] float spScale = 1.01f;     //���� �̵��ӵ� ������

    [SerializeField] float monHp=100;           //��ȯ�� ���� ü��
    [SerializeField] float monAtt=1;            //��ȯ�� ���� ���ݷ�
    [SerializeField] float monSp=1;             //��ȯ�� ���� �̵��ӵ�
    [SerializeField] GameObject Enemy;          //��ȯ�� ���� ������

    GameObject tower;                           //�÷��̾ ����� Ÿ��
    // Start is called before the first frame update
    void Start()
    {//Ÿ���� ã�� ���� �ڷ�ƾ ����
        tower = GameObject.Find("BaseTower");
        StartCoroutine(Spawn());
    }
    IEnumerator Spawn() {
        while (true) {//���� �������� ������ z������ ��ȯ
            float rand = Random.Range(Min, Max);
            GameObject go = Instantiate(Enemy);
            Vector3 pos = transform.position;
            pos.z += rand;
            if (time > Maxtime) {//�����ð��� �Ǹ� �� ���� ����
                time = 0;
                monHp *= hpScale;
                monAtt += attScale;
                monSp *= spScale;
            }
            //������ �� �������ͽ� ����
            go.GetComponent<Monster>().SetStatas((int)(monHp), (int)monAtt, monSp);
            //��ġ ����
            go.transform.position = pos;
            //Ÿ���� ���鼭 ����
            go.transform.LookAt(tower.transform);
            time += spawnTime;
            yield return new WaitForSeconds(spawnTime);//��ȯ�ֱ⸶�� ����
        }
    
    }
}
