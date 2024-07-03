using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Monster : MonoBehaviour
{
    float hp=100;                               //몬스터가 갖는 체력
    public float Hp{                            //체력제어용 프로퍼티
        get{ return hp; }               
        set {
            hp = value;
            if (hpBar != null) {                //체력바 변경
                hpBar.value = hp;
            }
            if (hp <= 0) {                      //체력이0이하면=죽으면
                myState = MonsterState.die;     //상태 변경
                hp = 0;                         //체력을0으로
            }
        }

    }

    [SerializeField]float speed=1;              //이동속도
            
    [SerializeField] float attack=1;            //공격력

    [SerializeField] float attackSpeed=1.7f;    //공격주기

    [SerializeField] int coin = 2;              //처치시 얻는 돈

    Animator anim;                              //애니메이터

    MonsterState myState=MonsterState.move;     //기본상태는 이동

    private bool is_Attack=true;                //공격주기 컨트롤용 부울
    private bool is_die = false;                //사망 컨트롤용 부울

    GameObject target;                          //공격대상

    Slider hpBar;                               //체력바
    enum MonsterState {                         //몬스터의 상태를 나타내는 열거형
        move,
        attack,
        die
    }
    // Start is called before the first frame update
    void Start()
    {//변수 초기화
        hpBar = GetComponentInChildren<Slider>();
        hpBar.maxValue = hp;
        hpBar.value = 0;
        anim = GetComponent<Animator>();

        anim.SetTrigger("move");
    }

    // Update is called once per frame
    void Update()
    {
        Action();//상태에 따라 행동
    }

    private void Action() {//상태에 따라 행동 변경
        switch (myState) {
            case MonsterState.attack://공격 상태
                if (is_Attack) {//공격을 할 수 있는 상황이면
                    is_Attack = false;//공격 비활성화
                    anim.SetTrigger("attack");//공격모션
                    StartCoroutine(AttackTimer());//공격을 다시 할 수 있을때 공격가능하다고 알려줄 코루틴
                    target.GetComponent<Tower>().Damaged(attack);//타겟의 체력 감소
                }
                break;
            case MonsterState.move:
                Move();//이동
                break;
            case MonsterState.die:
                if (!is_die) {//아직죽지 않았다면
                    
                    anim.SetTrigger("die");//죽는 애니메이션 진행
                    GameManager.instans.coin += coin;//돈증가
                    GameManager.instans.Um.UpdateInfo();//UI갱신
                    Destroy(gameObject, anim.GetCurrentAnimatorStateInfo(0).length); //죽는 모션 끝나고 Destroy
                    is_die = true;//다시 실행하지 않도록 변경
                }
                break;
        }
    }

    private void Move()//이동
    {
        transform.Translate(Vector3.forward*speed*Time.deltaTime);
    }


    private void OnTriggerEnter(Collider other)//적대대상이 공격범위에 들어오면
    {
        if (other.tag == "Tower"&& myState!= MonsterState.die)
        {
            target = other.gameObject;//대상을 변수에 담고
            myState = MonsterState.attack;//상태를 공격으로 바꾼다

        }
    }
    private void OnTriggerExit(Collider other)//공격범위에 대상이 없어지면
    {
        if (other.tag == "Tower" && myState != MonsterState.die)
        {
            target = null;//타겟이 사라지고
            myState = MonsterState.move;//상태가 이동으로 바뀐다

        }
    }
    IEnumerator AttackTimer() {//공격제어용 코루틴
        yield return new WaitForSeconds(attackSpeed);//공격속도 시간만큼 기다리고
        is_Attack = true;  //공격가능하다고 변경한다
    }
    public void SetStatas(float hp=100, 
                          float attack =1, 
                          float speed =1) {//몬스터의 스테이터스를 변경한다.
        this.hp = hp;
        this.attack = attack;
        this.speed = speed;


    }

}
