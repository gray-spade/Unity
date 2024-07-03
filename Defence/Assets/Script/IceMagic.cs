using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceMagic : Magic
{
    //공격 판정이 나타날때를 표시할 파티클 시스템
    private ParticleSystem ps2;

    // Start is called before the first frame update
    private void Awake()
    {//마법의 필요한 변수 초기화
        _attack *= (attackScale+1);
        hitbox = GetComponentInChildren<Collider>();
        
        ps = GetComponent<ParticleSystem>();
        ps2=transform.Find("ShockSphere").GetComponent<ParticleSystem>();
        Debug.Log(attack);
    }

    protected override IEnumerator Attack()
    {
        while (true)
        {//공격판정이 나타날때
            if (ps2.particleCount > 0) {
                //공격범위 내에 있는 콜라이더들을 찾아옴
                targets = Physics.OverlapSphere(transform.position, hitbox.bounds.size.x/2);
                foreach (Collider target in targets)
                {
                    if (target.gameObject.tag == "Enemy")
                    {//범위내 적 체력 감소
                        target.gameObject.GetComponent<Monster>().Hp -= attack;
                    }
                }//이후 추가로 대미지가 들어가지 않게 break;
                break;
            }
            //매프레임 당 호출
            //공격판정이 일어난 이후에도 파티클은 지속되어야함
            yield return new WaitForEndOfFrame();
        }
        yield return null;
    }
}
