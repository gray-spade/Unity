using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    //변수 초기화
    [SerializeField]float spawnTime=0.5f;       //몬스터 소환주기
    float Min = -7;                             //소환범위z최소 
    float Max = 7;                              //소환범위z최대
    float time = 0;                             //타이머 제어용 변수
    float Maxtime = 30;                         //몬스터 강화 주기

    [SerializeField] float hpScale = 1.02f;     //몬스터hp 증가량
    [SerializeField] float attScale = 0.25f;    //몬스터 공격력 증가량
    [SerializeField] float spScale = 1.01f;     //몬스터 이동속도 증가량

    [SerializeField] float monHp=100;           //소환할 몬스터 체력
    [SerializeField] float monAtt=1;            //소환할 몬스터 공격력
    [SerializeField] float monSp=1;             //소환할 몬스터 이동속도
    [SerializeField] GameObject Enemy;          //소환할 몬스터 프리팹

    GameObject tower;                           //플레이어가 방어할 타워
    // Start is called before the first frame update
    void Start()
    {//타워를 찾고 생성 코루틴 실행
        tower = GameObject.Find("BaseTower");
        StartCoroutine(Spawn());
    }
    IEnumerator Spawn() {
        while (true) {//일정 범위에서 랜덤한 z값으로 소환
            float rand = Random.Range(Min, Max);
            GameObject go = Instantiate(Enemy);
            Vector3 pos = transform.position;
            pos.z += rand;
            if (time > Maxtime) {//일정시간이 되면 적 스팩 증가
                time = 0;
                monHp *= hpScale;
                monAtt += attScale;
                monSp *= spScale;
            }
            //생성한 적 스테이터스 변경
            go.GetComponent<Monster>().SetStatas((int)(monHp), (int)monAtt, monSp);
            //위치 지정
            go.transform.position = pos;
            //타워를 보면서 스폰
            go.transform.LookAt(tower.transform);
            time += spawnTime;
            yield return new WaitForSeconds(spawnTime);//소환주기마다 실행
        }
    
    }
}
