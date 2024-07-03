using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MouseInput : MonoBehaviour
{
    public float time = 0;                              //타이머 제어용 변수
    public float Maxtime = 0.5f;                        //최대 시간
    public Canvas canvas;                               //표시할 Ui 캔버스
    public RectTransform rect;                          //캔버스의 rect
    Vector3 pos;                                        //클릭했을 떄 마우스의 위치
    Vector2 localPoint;                                 //마우스 위치를 UI위치로 변환했을때 좌표
    [SerializeField] private GameObject panel;          //마법종류가 표시될 패널
    [SerializeField] private Image load;                //마우스 누르는 시간을 알려줄 이미지
    [SerializeField] GameObject[] magicsPrefab;         //마법들의 프리팹
        
    Tower tower;                                        //타워

    // Start is called before the first frame update
    void Start()
    {//변수 초기화
        tower = GameObject.Find("BaseTower").GetComponent<Tower>();
        canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
        rect = canvas.GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (EventSystem.current.IsPointerOverGameObject() == false)//UI가 클릭된것이 아니면
        {
           
            if (Input.GetMouseButtonDown(0))//마우스 좌클릭을 누를때
            {
                pos = Input.mousePosition;//좌표를저장
                RectTransformUtility.ScreenPointToLocalPointInRectangle(rect, pos, null, out localPoint);//UI좌표로 변환

                load.gameObject.GetComponent<RectTransform>().localPosition = localPoint;//위치 변경

                time = 0;

            }
            if (Input.GetMouseButton(0))//좌클릭을 누르고 있는 동안
            {
                time += Time.deltaTime;//타이머를 돌려서
                if (time > 0.1f)        //0.1초 이상 누를시
                {
                    load.gameObject.SetActive(true);//이미지를 활성화
                    load.fillAmount = time / Maxtime;//fillAmount로 점점 채워진다
                }

                if ((time / Maxtime) > 1)//정해진 시간이 되면
                {
                    panel.GetComponent<RectTransform>().localPosition = localPoint;//마법 종류 UI를 전부 띄우고
                    panel.SetActive(true);
                    load.gameObject.SetActive(false);//로딩 이미지를 비활성화
                }

            }
            
        }
        if (Input.GetMouseButtonUp(0))//마우스 좌클릭을 땔때
        {
            panel.SetActive(false);             //UI들을 비활성화하고
            load.gameObject.SetActive(false);
            Magic(GameManager.instans.i);       //선택된 마법실행
            GameManager.instans.i = 0;          //선택초기화
            
           
        }
    }

    void Magic(int i) {//마법 실행 0이면 아무것도안함
        switch (i) {
            case 0:
                break;
            case 1:
                SelectMagic(1);
                break;
            case 2:
                SelectMagic(2);
                break;
            case 3:
                SelectMagic(3);
                break;

        }
        
    }

    void SelectMagic(int index) {//마법프리팹 생성하고 mp소모
        if (tower.IsMagic(GameManager.instans.magicMp[index-1]))//마법을 쓸수있는 상황이면
        {
            GameObject go;
            go = Instantiate(magicsPrefab[index-1]);
            go.GetComponent<Magic>().attackScale = GameManager.instans.MagicLevel;
            go.transform.position = RayCast(pos);//처음 클릭했던 위치에 생성
            tower.Mp -= GameManager.instans.magicMp[index-1];
            
        }
        else { Debug.Log("마나 부족"); };
        
    }

    Vector3 RayCast(Vector3 pos1)//레이캐스트로 위치 반환
    {
        Vector3 screenPos;
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(pos1);

        if (Physics.Raycast(ray, out hit))
        {
            screenPos = hit.point;
            return screenPos;
        }

        return Vector3.zero;

    } 
}
