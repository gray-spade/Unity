using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Magic : MonoBehaviour
{//�������� �⺻ ������ ��� �ִ� �߻� Ŭ����

    protected Collider hitbox;                  //���ݹ���
    protected Collider[] targets;               //������ ����
    protected  ParticleSystem ps;               //�� ������ ����Ʈ

    [SerializeField] protected float _attack;   //������ ���ݷ�
    [SerializeField] public float attackScale=2;//���׷��̵�� ���ݷ� ����

    public float attack
    {                       //���ٿ� ������Ƽ
        get { return _attack; }
        set { _attack = value; }
    }

    private void Start()
    {//���� �����ϸ� ���� ����
        StartCoroutine(Attack());
    }
    // Update is called once per frame
    void Update()
    {
        //��ƼŬ�� ������ Destroy
        if (ps)
        {
            if (!ps.IsAlive())
            {
                Destroy(gameObject);
            }
        }
    }
    //��ӹ��� �ڽ� Ŭ������ �ݵ�� ������ �ؾ��ϴ� �߻�ż���
    protected abstract IEnumerator Attack();
}
