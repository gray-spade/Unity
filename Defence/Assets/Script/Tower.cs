using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Tower : MonoBehaviour
{
    [SerializeField]float hp=100;               //ü��
    float maxHp = 100;          //�ִ�ü��
    float mp;                   //����
    public float maxMp =20;     //�ִ븶��
    float mpGen = 1;            //���� ȸ����

    Slider hpBar;               //ü�¹�
    public float Mp {           //���� ����� ������Ƽ
        get { return mp; }
        set
        {
            mp = value;
            if (mp > maxMp)     //�ִ� Mp�� �ѱ�� �ִ�mp�� ����
            {
                mp = maxMp;
            }
        }

    }
    public float Hp             //ü�� ����� ������Ƽ
    {
        get { return hp; }
        set
        {
            hp = value;
            if (hp < 0)         //ü����0���� ������=������
            {                   //ü����0���� ����� 
                hp = 0;
                GameManager.instans.Um.deathPanel.SetActive(true);//UI ����
                Time.timeScale = 0;//�ð��� ����

                
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {//���� �ʱ�ȭ
        hpBar = GetComponentInChildren<Slider>();
        hpBar.maxValue = maxHp;
        hpBar.value = Hp;

        GameManager.instans.Um.mpBar.maxValue = maxMp;
        //UI����
        MpInfo();

    }

    // Update is called once per frame
    void Update()
    {
        //���� ȸ��
        Mp += mpGen*Time.deltaTime;
        MpInfo();
    }
    void updateUI() {//ü�¹� ����
        hpBar.value = Hp;
    }

    public void Damaged(float damage)//ü���� ����
    {
        Hp -= damage;
        updateUI();
    }

    public void MpInfo() {//mp���� UI ����
        GameManager.instans.Um.mpBar.value = mp;
        GameManager.instans.Um.mpText.text = (int)mp + "/" + maxMp;
    }


    public bool IsMagic(int cost) {//�ܺο��� mp���ϴ� �Լ�
        return cost <= mp;
    }

    public void Upgrade() {//���׷��̵�� ���� ����
        mpGen = GameManager.instans.MPRegenLevel+1;
        maxMp = GameManager.instans.MPLevel+20;
        GameManager.instans.Um.mpBar.maxValue = maxMp;
    }
    
}
