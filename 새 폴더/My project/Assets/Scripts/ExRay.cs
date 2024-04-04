using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExRay : MonoBehaviour
{
    public Text UIText;                         //�ؽ�Ʈ ����
    public int Point;                           //����Ʈ ����
    void Update()
    {
        if(Input.GetMouseButtonDown(1))                                     //GetMouseButtonDown(1) ������ ��ư ���콺�� ������ �� 
        {
            Ray cast = Camera.main.ScreenPointToRay(Input.mousePosition);   //Ray�� �����ϰ� ī�޶��� ���콺 ��ġ���� Ray�� ���.

            RaycastHit hit;                                                 //Ray�� ��� �浿�� ��ü�� ���� Hit �ֱ� ���� ����

            if (Physics.Raycast(cast, out hit))                             //�浹�Ŀ� ���� hit ���� ��� 
            {
                Debug.Log(hit.collider.gameObject.name);                    //�浹�� ������Ʈ�� �̸��� �޾ƿ´�.
                Debug.DrawLine(cast.origin, hit.point, Color.red, 2.0f);    //RayCast ���� ����׷� �� �� �ְ� �Ѵ�. 

                if (hit.collider.gameObject.tag == "Target")                //�浹�� ������Ʈ�� TAG �̸��� Target �� ���
                {
                    Destroy(hit.collider.gameObject);                       //�ش� ������Ʈ�� �ı��Ѵ�.
                    Point += 1;                                             //�ı��� ����Ʈ +1
                }
            }
            else
            {
                Point = 0;                                                  //Miss �� ����Ʈ 0��
            }

            UIText.text = Point.ToString();                                 //UI�� ǥ��
        }        
    }
}
