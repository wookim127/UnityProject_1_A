using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleObject : MonoBehaviour
{
    public bool isDrag;      //���콺 Drag �Ǵ�
    public bool isUsed;      //��� �Ϸ� üũ
    Rigidbody2D rigidbody2D;

    public int index;  //���� ��ȣ ����

    public float EndTime = 0.0f;
    public SpriteRenderer spriteRenderer;

    public GameManager gameManager;
    // Update is called once per frame
    void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();   //������Ʈ�� ��ü�� ����
        isUsed = false;             //�����Ҷ� ����� �ȵǾ��ٰ� �Է�
        rigidbody2D.simulated = false;

        spriteRenderer = GetComponent<SpriteRenderer>(); //���� �ൿ�� ó������ �������� �ʰ� ����
    }

    void Start()
    {
        gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        
    }

    void Update()
    {
        if (isUsed)                                 //����� �Ϸ�� ������Ʈ�� ������Ʈ ���� �׳� ���� ������. (���콺 Input ������ ���� ����)
            return;

        if (isDrag)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);   //ȭ�� ��ũ������ ����Ƽ Scene ������ ��ǥ�� �����´�.

            float leftBorder = -5.0f + transform.localScale.x / 2f;      //������ ��ŭ �̵� ����
            float rightBorder = 5.0f - transform.localScale.x / 2f;

            if (mousePos.x < leftBorder) mousePos.x = leftBorder;
            if (mousePos.x > rightBorder) mousePos.x = rightBorder;

            mousePos.y = 8;
            mousePos.z = 0;
            transform.position = Vector3.Lerp(transform.position, mousePos, 0.2f);

        }
        if (Input.GetMouseButtonDown(0)) Drag();        //���콺 ��ư�� �������� Drag �Լ� ����
        if (Input.GetMouseButtonUp(0)) Drop();          //���콺 ��ư�� �ö󰥶� Drop �Լ� ����
    }


    void Drag()                                   //�巡�� �� �� ���� �� �Լ�
    {
        isDrag = true;                            //�巡�� ���̴�. (true)
        rigidbody2D.simulated = false;            //���� �ùķ��̼� ���� (false)
    }

    void Drop()                                   //��� �� �� ���� �� �Լ�
    {
        isDrag = false;                           //�巡�� ���̴�. (false)
        isUsed = true;                            //��� �Ϸ� �Ǿ���.(true)
        rigidbody2D.simulated = true;

        gameManager.GenObject();//���� �ùķ��̼��� ����� (true)

         
    }

    public void Used()
    {
        isDrag = false;
        isUsed = true;
        rigidbody2D.simulated = true;
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "EndLine")
        {
            EndTime += Time.deltaTime;

            if (EndTime > 1)
            {
                spriteRenderer.color = new Color(0.9f, 0.2f, 0.2f);

            }
            if(EndTime > 3)
            {
                //Debug.Log("���� ����");
                gameManager.EndGame();

            }
        }
        
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "EndLine")
        {
            EndTime = 0.0f;
            spriteRenderer.color = Color.white;
        }
    }


    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (index >= 7)
            return;
    }


    public void OnCollisionEnter2D(Collision collision)
    {
        if (collision.gameObject.tag == "Fruit")
        {
            CircleObject temp = collision.gameObject.GetComponent<CircleObject>();

            if (temp.index == index)
            {

                if (gameObject.GetInstanceID() > collision.gameObject.GetInstanceID())
                {
                    //GameManager���� ��ģ ������Ʈ�� ����
                    GameObject tempGameManager = GameObject.FindWithTag("GameMabager");
                    if (tempGameManager !=null)
                    {
                        tempGameManager.gameObject.GetComponent<GameManager>().MergeObject(index, gameObject.transform.position);
                    }
                }
                Destroy(temp.gameObject);
                Destroy(gameObject);
            }
        }
    }

}
