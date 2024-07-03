using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private static GameManager _gm;                     //싱글톤
    public int i;                                       //어떤마법이 실행될지 알려줄 변수

    [SerializeField] public float MPLevel=0;            //MP최대치업그레이드 레벨
    [SerializeField] public float MPRegenLevel = 0;     //MP회복업그레이드 레벨
    [SerializeField] public float MagicLevel = 0;       //마법 대미지업그레이드 레벨
    public int[] magicMp= { 7, 10, 5 };                 //마법의 마나 소모량

    public int coin;                                    //현제 돈
    public UIManager Um;                                //UIManger

    public int priceMp = 200;                           //MP최대치업그레이드 가격
    public int priceMpGen = 500;                        //MP회복업그레이드 가격
    public int priceMagicPower=100;                     //마법 대미지업그레이드 가격

    public float priceScaleMp = 1.2f;                   //MP최대치업그레이드 가격 증가량 *
    public float priceScaleMpGen = 500;                 //MP회복업그레이드 가격 증가량 +
    public float priceScaleMagicPower = 1.1f;           //마법 대미지업그레이드 가격 증가량 * 
    public static GameManager instans {                 //싱글톤
        get => _gm;
    }

    private void Awake()//싱글톤
    {
        if (_gm == null) {
            _gm = this;
        }
        Um = GetComponent<UIManager>();
    }
    // Start is called before the first frame update
    void Start()
    {//변수 초기화
        
    }
}
