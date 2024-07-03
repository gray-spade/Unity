using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeSelect : MonoBehaviour
{
    //시간 배속을 담당하는 스크립트

    //변수 선언
    Button fastBtn;
    GameObject on;
    bool isFast;
    // Start is called before the first frame update
    void Start()
    {//변수 초기화
        fastBtn = GameObject.Find("Time").GetComponent<Button>();
        on = fastBtn.transform.Find("On").gameObject;
        fastBtn.onClick.AddListener(FastToggle);

    }
    void FastToggle() {
        if (isFast)//배속 상태이면
        {//시간을 절반으로 줄이고
            on.SetActive(false);//버튼 이미지 변경
            Time.timeScale = 0.5f;

        }
        else {//배속상태가 아니면
            //이미지를 바꾸고
            on.SetActive(true);
            //배속상태로 변경
            Time.timeScale = 1f;

        }
        isFast = !isFast;//배속상태->기본상태,기본상태->배속상태

    }
}
