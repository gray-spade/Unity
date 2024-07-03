using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Magic : MonoBehaviour
{//마법들의 기본 동작을 담고 있는 추상 클래스

    protected Collider hitbox;                  //공격범위
    protected Collider[] targets;               //공격할 대상들
    protected  ParticleSystem ps;               //이 마법의 이팩트

    [SerializeField] protected float _attack;   //마법의 공격력
    [SerializeField] public float attackScale=2;//업그레이드당 공격력 증가

    public float attack
    {                       //접근용 프로퍼티
        get { return _attack; }
        set { _attack = value; }
    }

    private void Start()
    {//씬에 등장하면 공격 실행
        StartCoroutine(Attack());
    }
    // Update is called once per frame
    void Update()
    {
        //파티클이 끝나면 Destroy
        if (ps)
        {
            if (!ps.IsAlive())
            {
                Destroy(gameObject);
            }
        }
    }
    //상속받은 자식 클래스가 반드시 재정의 해야하는 추상매서드
    protected abstract IEnumerator Attack();
}
