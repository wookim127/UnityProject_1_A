using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExGenTarget : MonoBehaviour
{
    public GameObject Target;                                                  //������ �ڽ� ����
    public float checkTime;                                                     //�ð� �˻��� ���� ����
    void Update()
    {
        checkTime += Time.deltaTime;                                            //������ �ð��� �׾Ƽ� �ʸ� �˻��Ѵ�.
        if (checkTime >= 1.0f)                                                   //1���� �ð��� �帣��
        {
            checkTime = 0.0f;                                                           //�ð� �ʱ�ȭ�� ��Ų��.
            GameObject temp = Instantiate(Target);                                      //������ �ڽ� �������� Instantiate �� �����Ѵ�.
            temp.transform.position = new Vector3(-4.0f, -4.0f, 0.0f);         //�����Ҷ� ��ũ��Ʈ�� �ִ� ������Ʈ ��ġ�� ����
            int RandomNumberX = Random.Range(0, 8);                                         //0 ~ 8  ���� ���� ���� �Ѵ�.
            int RandomNumberY = Random.Range(0, 8); 
            temp.transform.position += new Vector3(RandomNumberX, RandomNumberY, 0.0f);   //X, Y�� ��ġ�� �����ش�.

            Destroy(temp, 2.0f);
        }
    }
}
