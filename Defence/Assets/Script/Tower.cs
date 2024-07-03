using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Tower : MonoBehaviour
{
    [SerializeField]float hp=100;               //체력
    float maxHp = 100;          //최대체력
    float mp;                   //마나
    public float maxMp =20;     //최대마나
    float mpGen = 1;            //마나 회복량

    Slider hpBar;               //체력바
    public float Mp {           //마나 제어용 프로퍼티
        get { return mp; }
        set
        {
            mp = value;
            if (mp > maxMp)     //최대 Mp를 넘기면 최대mp로 변경
            {
                mp = maxMp;
            }
        }

    }
    public float Hp             //체력 제어용 프로퍼티
    {
        get { return hp; }
        set
        {
            hp = value;
            if (hp < 0)         //체력이0보다 낮으면=죽으면
            {                   //체력을0으로 만들고 
                hp = 0;
                GameManager.instans.Um.deathPanel.SetActive(true);//UI 띄운다
                Time.timeScale = 0;//시간을 멈춤

                
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {//변수 초기화
        hpBar = GetComponentInChildren<Slider>();
        hpBar.maxValue = maxHp;
        hpBar.value = Hp;

        GameManager.instans.Um.mpBar.maxValue = maxMp;
        //UI갱신
        MpInfo();

    }

    // Update is called once per frame
    void Update()
    {
        //마나 회복
        Mp += mpGen*Time.deltaTime;
        MpInfo();
    }
    void updateUI() {//체력바 갱신
        hpBar.value = Hp;
    }

    public void Damaged(float damage)//체력을 변경
    {
        Hp -= damage;
        updateUI();
    }

    public void MpInfo() {//mp정보 UI 갱신
        GameManager.instans.Um.mpBar.value = mp;
        GameManager.instans.Um.mpText.text = (int)mp + "/" + maxMp;
    }


    public bool IsMagic(int cost) {//외부에서 mp비교하는 함수
        return cost <= mp;
    }

    public void Upgrade() {//업그레이드시 변수 갱신
        mpGen = GameManager.instans.MPRegenLevel+1;
        maxMp = GameManager.instans.MPLevel+20;
        GameManager.instans.Um.mpBar.maxValue = maxMp;
    }
    
}
