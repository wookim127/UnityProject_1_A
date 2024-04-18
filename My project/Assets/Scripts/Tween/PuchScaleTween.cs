using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class PuchScaleTween : MonoBehaviour
{
    public bool isPunch = false;    //�÷��� �� ����

    // Start is called before the first frame update
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!isPunch)       //��ġ ���� ���� �ƴ� ��(��ġ ���϶��� Ű���带 ������ ǥ���� ���� ����
            {
                isPunch = true;   //��ġ ������ ���°��� �����.
                //��ġ ȿ���� �ְ� ȿ���� ������ EndPunch �Լ� ȣ��
                transform.DOPunchScale(new Vector3(0.5f, 0.5f, 0.5f), 0.1f, 10, 1).OnComplete(EndPunch);

            }
        }
    }

    void EndPunch()
    {
        isPunch = false;
    }
}
