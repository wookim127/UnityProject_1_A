using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleObject : MonoBehaviour
{
    public bool isDrag;      //마우스 Drag 판단
    public bool isUsed;      //사용 완료 체크
    Rigidbody2D rigidbody2D;


    // Update is called once per frame
    void Start()
    {
        isUsed = false;             //시작할때 사용이 안되었다고 입력
        rigidbody2D = GetComponent<Rigidbody2D>();     //오브젝트의 강체에 접근
        rigidbody2D.simulated = false;                 //물리 행동이 처음에는 동작하지 않게 설정
    }

    void Update()
    {
        if (isUsed)                                 //사용이 완료된 오브젝트는 업데이트 문을 그냥 돌려 보낸다. (마우스 Input 적용을 막기 위해)
            return;

        if (isDrag)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);   //화면 스크린에서 유니티 Scene 공간의 좌표를 가져온다.

            float leftBorder = -5.0f + transform.localScale.x / 2f;      //반지름 만큼 이동 제한
            float rightBorder = 5.0f - transform.localScale.x / 2f;

            if (mousePos.x < leftBorder) mousePos.x = leftBorder;
            if (mousePos.x > rightBorder) mousePos.x = rightBorder;

            mousePos.y = 8;
            mousePos.z = 0;
            transform.position = Vector3.Lerp(transform.position, mousePos, 0.2f);

        }
        if (Input.GetMouseButtonDown(0)) Drag();        //마우스 버튼이 눌렸을때 Drag 함수 실행
        if (Input.GetMouseButtonUp(0)) Drop();          //마우스 버튼이 올라갈때 Drop 함수 실행
    }


    void Drag()                                   //드래그 할 때 상태 값 함수
    {
        isDrag = true;                            //드래그 중이다. (true)
        rigidbody2D.simulated = false;            //물리 시뮬레이션 안함 (false)
    }

    void Drop()                                   //드랍 할 때 상태 값 함수
    {
        isDrag = false;                           //드래그 중이다. (false)
        isUsed = true;                            //사용 완료 되었다.(true)
        rigidbody2D.simulated = true;             //물리 시뮬레이션을 사용함 (true)

        GameObject temp = GameObject.FindWithTag("GameManager");           //Scene에서 GameManager Tag 가지고 있는 오브젝트를 가져온다.
        if(temp != null)                                                   //해당 오브젝트가 있을 경우
        {
            temp.gameObject.GetComponent<GameManager>().GenObject();        //GameManager 의 GenObject 함수를 호출
        }
    }


}
