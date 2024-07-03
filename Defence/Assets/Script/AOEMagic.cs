using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AOEMagic : Magic
{
    //지속 범위 마법 클래스

    //공격주기
    [SerializeField] protected float hitDelay;

    // Start is called before the first frame update
    private void Awake()
    {//마법의 공격력 설정,필요한 정보 설정
        attack += attackScale ;
        hitbox = GetComponentInChildren<Collider>();
        Debug.Log(attack);
        ps = GetComponent<ParticleSystem>();
    }
    //부모의 추상 메서드를 재정의
    protected override IEnumerator Attack()
    {
        while (true)
        {
            //공격범위에 있는 게임오브젝트의 정보를 전부 배열에 담는다
            targets = Physics.OverlapSphere(transform.position, hitbox.bounds.size.x/2);
            foreach (Collider target in targets)
            {//공격범위에 Enemy라는 Tag를 가진 콜라이더는
                if (target.gameObject.tag == "Enemy")
                {
                    if (target.gameObject != null) {//체력을 깎는다
                        target.gameObject.GetComponent<Monster>().Hp -= _attack;
                    }
                    
                }
            }
            //공격 주기마다 동작
            yield return new WaitForSeconds(hitDelay);
        }
    }
}
