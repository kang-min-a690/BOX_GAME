using UnityEngine;

public class Player : MonoBehaviour
{
    public int move_method;

    public float speed;
    public Vector2 speed_vec;
    // public : ������ ����, privete�� ����
    // Vextor2 : ������ ������ ���� Ÿ��
    // speed_vec : ���� �̸�

    void Start()
    {

    }
    public void Dead()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Item"))
        {
            Debug.Log("�����ۿ� ��Ҵ�!");
            Destroy(collision.gameObject);
        }
        else if (collision.CompareTag("Enemy"))
        {
            Debug.Log("������ ����!");
            Dead();
        }
    }



    // Update is called once per frame
    [System.Obsolete]
    void Update() // �Ұ�ȣ�� �̸����� ������ �Լ�
    {// ������ �߰�ȣ�� ����
     //transform.Translate(speed_vec);
     //��ġ�� ()��ŭ ���� �ض�

        if (move_method == 0) //�޼ҵ尡 0�ΰ�? Ȯ��
        {
            speed_vec = Vector2.zero;

            //���ǹ�
            // input.Getkey: Ű�� ���ȴ��� true, flase
            // RightArrow : ������ Ű
            if (Input.GetKey(KeyCode.RightArrow))
            {
                speed_vec.x += 0.1f;
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                speed_vec.x -= 0.1f;
            }
            if (Input.GetKey(KeyCode.UpArrow))
            {
                speed_vec.y += 0.1f;
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                speed_vec.y -= 0.1f;
            }
            transform.Translate(speed_vec);
        }
        else if (move_method == 1)  //�޼ҵ尡 1�� �� �Ʒ��ڵ� ����
        {
            //���� -1~1 �� * speed�� �༭ ������ �ӵ���� �����̵���
            // Input.GetAxis(string) : ���� ������ , �ε巴�� ������, �ε巴�� ���߱�
            speed_vec.x = Input.GetAxis("Horizontal") * speed; //������ 
            speed_vec.y = Input.GetAxis("Vertical") * speed;   //������

            transform.Translate(speed_vec);
        }
        else if (move_method == 2)
        {
            speed_vec = Vector2.zero;

            if (Input.GetKey(KeyCode.RightArrow))
            {
                speed_vec.x += speed;
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                speed_vec.x -= speed;
            }
            if (Input.GetKey(KeyCode.UpArrow))
            {
                speed_vec.y += speed;
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                speed_vec.y -= speed;
            }
            GetComponent<Rigidbody2D>().velocity = speed_vec;
        }
    }
}



