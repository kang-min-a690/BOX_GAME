using UnityEngine;

public class Player : MonoBehaviour
{
    public int move_method;

    public float speed;
    public Vector2 speed_vec;
    // public : 변수를 공개, privete은 숨김
    // Vextor2 : 변수가 저장할 값의 타입
    // speed_vec : 변수 이름

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
            Debug.Log("아이템에 닿았다!");
            Destroy(collision.gameObject);
        }
        else if (collision.CompareTag("Enemy"))
        {
            Debug.Log("적에게 닿음!");
            Dead();
        }
    }



    // Update is called once per frame
    [System.Obsolete]
    void Update() // 소괄호가 이름옆에 있으면 함수
    {// 내용을 중괄호에 묶기
     //transform.Translate(speed_vec);
     //위치를 ()만큼 변경 해라

        if (move_method == 0) //메소드가 0인가? 확인
        {
            speed_vec = Vector2.zero;

            //조건문
            // input.Getkey: 키가 눌렸는지 true, flase
            // RightArrow : 오른쪽 키
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
        else if (move_method == 1)  //메소드가 1일 때 아래코드 실행
        {
            //값은 -1~1 로 * speed로 줘서 설정한 속도대로 움직이도록
            // Input.GetAxis(string) : 관성 움직임 , 부드럽게 빠르게, 부드럽게 멈추기
            speed_vec.x = Input.GetAxis("Horizontal") * speed; //수직의 
            speed_vec.y = Input.GetAxis("Vertical") * speed;   //수평의

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



