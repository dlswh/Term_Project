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
            //Ű���带 ������ �� ���� ��ȯ
            float horizontal_input = Input.GetAxis("Horizontal"); //�� > -1, �� > 1

            if (horizontal_input != 0)
                anim.Play("02_Move");
            else
                anim.Play("01_Idle");

            //�÷��̾ �ʴ� �󸶳� ���� �Ÿ��� �̵��ؾ� �ϴ����� ����ϴµ� ���
            //�ʴ� ������ = �÷��̾��� ���ǵ� * ��Ÿ Ÿ��
            float distance_per_frame = 10.0f * Time.deltaTime;

            transform.Translate(Vector3.right/*X��*/* horizontal_input /*����*/ * distance_per_frame/*�Ÿ�*/);
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
