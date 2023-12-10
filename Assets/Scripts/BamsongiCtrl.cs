using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BamsongiCtrl : MonoBehaviour
{
    public int oneScore; //��Ʈ ����

    void Start()
    {
        oneScore = 0; //��Ʈ ���� �ʱ�ȭ
    }

    void Update()
    {
       
    }
    public void Shoot(Vector3 dir)
    {
        GetComponent<Rigidbody>().AddForce(dir);
    }

    private void OnCollisionEnter(Collision collision)
    {
        BansongiGenerator.totalBam++; //����� ���� 1 ����
        GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<ParticleSystem>().Play();

        Vector3 collided_position = transform.position;
        float distance = collided_position.x * collided_position.x + (collided_position.y - 6.5f) * (collided_position.y - 6.5f);
        distance = Mathf.Sqrt(distance);

        switch (Mathf.RoundToInt(distance*10 / 4)) //�Ÿ��� ���� ���� ���
        {
            case 0: oneScore = 100;
                break;
            case 1: oneScore = 80;
                break;
            case 2: oneScore = 60;
                break;
            case 3: oneScore = 40;
                break;
            case 4: oneScore = 20;
                break;

            default: oneScore = 0;
                break;
        }
        BansongiGenerator.totalScore += oneScore; //������ ��Ʈ ���� �ݿ�
    }
}
