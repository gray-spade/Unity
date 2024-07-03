using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Monster : MonoBehaviour
{
    float hp=100;                               //���Ͱ� ���� ü��
    public float Hp{                            //ü������� ������Ƽ
        get{ return hp; }               
        set {
            hp = value;
            if (hpBar != null) {                //ü�¹� ����
                hpBar.value = hp;
            }
            if (hp <= 0) {                      //ü����0���ϸ�=������
                myState = MonsterState.die;     //���� ����
                hp = 0;                         //ü����0����
            }
        }

    }

    [SerializeField]float speed=1;              //�̵��ӵ�
            
    [SerializeField] float attack=1;            //���ݷ�

    [SerializeField] float attackSpeed=1.7f;    //�����ֱ�

    [SerializeField] int coin = 2;              //óġ�� ��� ��

    Animator anim;                              //�ִϸ�����

    MonsterState myState=MonsterState.move;     //�⺻���´� �̵�

    private bool is_Attack=true;                //�����ֱ� ��Ʈ�ѿ� �ο�
    private bool is_die = false;                //��� ��Ʈ�ѿ� �ο�

    GameObject target;                          //���ݴ��

    Slider hpBar;                               //ü�¹�
    enum MonsterState {                         //������ ���¸� ��Ÿ���� ������
        move,
        attack,
        die
    }
    // Start is called before the first frame update
    void Start()
    {//���� �ʱ�ȭ
        hpBar = GetComponentInChildren<Slider>();
        hpBar.maxValue = hp;
        hpBar.value = 0;
        anim = GetComponent<Animator>();

        anim.SetTrigger("move");
    }

    // Update is called once per frame
    void Update()
    {
        Action();//���¿� ���� �ൿ
    }

    private void Action() {//���¿� ���� �ൿ ����
        switch (myState) {
            case MonsterState.attack://���� ����
                if (is_Attack) {//������ �� �� �ִ� ��Ȳ�̸�
                    is_Attack = false;//���� ��Ȱ��ȭ
                    anim.SetTrigger("attack");//���ݸ��
                    StartCoroutine(AttackTimer());//������ �ٽ� �� �� ������ ���ݰ����ϴٰ� �˷��� �ڷ�ƾ
                    target.GetComponent<Tower>().Damaged(attack);//Ÿ���� ü�� ����
                }
                break;
            case MonsterState.move:
                Move();//�̵�
                break;
            case MonsterState.die:
                if (!is_die) {//�������� �ʾҴٸ�
                    
                    anim.SetTrigger("die");//�״� �ִϸ��̼� ����
                    GameManager.instans.coin += coin;//������
                    GameManager.instans.Um.UpdateInfo();//UI����
                    Destroy(gameObject, anim.GetCurrentAnimatorStateInfo(0).length); //�״� ��� ������ Destroy
                    is_die = true;//�ٽ� �������� �ʵ��� ����
                }
                break;
        }
    }

    private void Move()//�̵�
    {
        transform.Translate(Vector3.forward*speed*Time.deltaTime);
    }


    private void OnTriggerEnter(Collider other)//�������� ���ݹ����� ������
    {
        if (other.tag == "Tower"&& myState!= MonsterState.die)
        {
            target = other.gameObject;//����� ������ ���
            myState = MonsterState.attack;//���¸� �������� �ٲ۴�

        }
    }
    private void OnTriggerExit(Collider other)//���ݹ����� ����� ��������
    {
        if (other.tag == "Tower" && myState != MonsterState.die)
        {
            target = null;//Ÿ���� �������
            myState = MonsterState.move;//���°� �̵����� �ٲ��

        }
    }
    IEnumerator AttackTimer() {//��������� �ڷ�ƾ
        yield return new WaitForSeconds(attackSpeed);//���ݼӵ� �ð���ŭ ��ٸ���
        is_Attack = true;  //���ݰ����ϴٰ� �����Ѵ�
    }
    public void SetStatas(float hp=100, 
                          float attack =1, 
                          float speed =1) {//������ �������ͽ��� �����Ѵ�.
        this.hp = hp;
        this.attack = attack;
        this.speed = speed;


    }

}
