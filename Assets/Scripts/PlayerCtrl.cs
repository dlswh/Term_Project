using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    private Animation anim;
    public static int score;
    // Start is called before the first frame update
    void Start()
    {
        anim = this.GetComponent<Animation>();
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        if (!GameManager.gameOver)
        {
            //키보드를 누르면 그 값을 반환
            float horizontal_input = Input.GetAxis("Horizontal"); //왼 > -1, 오 > 1

            if (horizontal_input != 0)
                anim.Play("02_Move");
            else
                anim.Play("01_Idle");

            //플레이어가 초당 얼마나 많은 거리를 이동해야 하는지를 계산하는데 사용
            //초당 프레임 = 플레이어의 스피드 * 델타 타임
            float distance_per_frame = 10.0f * Time.deltaTime;

            transform.Translate(Vector3.right/*X축*/* horizontal_input /*방향*/ * distance_per_frame/*거리*/);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "ball")
        {
            score += 10;
        }
    }
}
