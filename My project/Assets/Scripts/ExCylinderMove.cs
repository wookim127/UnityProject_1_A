using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExCylinderMove : MonoBehaviour
{
    public float speed = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // ���� �������� ��ǥ ����
        // Vector3 (X,Y,Z) ���� �ǹ��Ѵ�. new �� Ŭ������ ���� ���ؼ� ���� 
        // X = X + 5 <- X += 5 (��� ǥ��)
        // Time.deltaTime ������ ���� �ð� ex) 60fps �ϰ�� 0.1�ʶ�� ��ġ�� ��ȯ ���ش�. 
        // ��ǻ�� ���� �������� �޶� ������ �̵� �ӵ��� ������� �ϱ⶧���� ��� 
        gameObject.transform.position += new Vector3(-1.0f, 0.0f, 0.0f) * speed * Time.deltaTime;

        //�� ������Ʈ�� X ��ǥ�� -12 �̸����� ������ ��� 
        if(gameObject.transform.position.x < -12.0f)
        {
            gameObject.transform.position += new Vector3(24.0f, 0.0f, 0.0f);
            //X�࿡ 24���ؼ� ȭ�� ���������� �̵� �����ش�. 
        }
    }
}
