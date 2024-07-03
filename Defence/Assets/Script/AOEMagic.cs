using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AOEMagic : Magic
{
    //���� ���� ���� Ŭ����

    //�����ֱ�
    [SerializeField] protected float hitDelay;

    // Start is called before the first frame update
    private void Awake()
    {//������ ���ݷ� ����,�ʿ��� ���� ����
        attack += attackScale ;
        hitbox = GetComponentInChildren<Collider>();
        Debug.Log(attack);
        ps = GetComponent<ParticleSystem>();
    }
    //�θ��� �߻� �޼��带 ������
    protected override IEnumerator Attack()
    {
        while (true)
        {
            //���ݹ����� �ִ� ���ӿ�����Ʈ�� ������ ���� �迭�� ��´�
            targets = Physics.OverlapSphere(transform.position, hitbox.bounds.size.x/2);
            foreach (Collider target in targets)
            {//���ݹ����� Enemy��� Tag�� ���� �ݶ��̴���
                if (target.gameObject.tag == "Enemy")
                {
                    if (target.gameObject != null) {//ü���� ��´�
                        target.gameObject.GetComponent<Monster>().Hp -= _attack;
                    }
                    
                }
            }
            //���� �ֱ⸶�� ����
            yield return new WaitForSeconds(hitDelay);
        }
    }
}
