using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceMagic : Magic
{
    //���� ������ ��Ÿ������ ǥ���� ��ƼŬ �ý���
    private ParticleSystem ps2;

    // Start is called before the first frame update
    private void Awake()
    {//������ �ʿ��� ���� �ʱ�ȭ
        _attack *= (attackScale+1);
        hitbox = GetComponentInChildren<Collider>();
        
        ps = GetComponent<ParticleSystem>();
        ps2=transform.Find("ShockSphere").GetComponent<ParticleSystem>();
        Debug.Log(attack);
    }

    protected override IEnumerator Attack()
    {
        while (true)
        {//���������� ��Ÿ����
            if (ps2.particleCount > 0) {
                //���ݹ��� ���� �ִ� �ݶ��̴����� ã�ƿ�
                targets = Physics.OverlapSphere(transform.position, hitbox.bounds.size.x/2);
                foreach (Collider target in targets)
                {
                    if (target.gameObject.tag == "Enemy")
                    {//������ �� ü�� ����
                        target.gameObject.GetComponent<Monster>().Hp -= attack;
                    }
                }//���� �߰��� ������� ���� �ʰ� break;
                break;
            }
            //�������� �� ȣ��
            //���������� �Ͼ ���Ŀ��� ��ƼŬ�� ���ӵǾ����
            yield return new WaitForEndOfFrame();
        }
        yield return null;
    }
}
