using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject pf_wall;
    public float interval;

    IEnumerator Start() // IEnumerator: �ش� �Լ��� �����带 �����Ͽ� ������ ���۽�Ŵ
    {
        while (true)
        {
            interval = Random.Range(1.0f, 2.0f);
            Instantiate(pf_wall, new Vector3(transform.position.x, Random.Range(-3.0f, 4.0f), transform.position.z), transform.rotation); //instantiate(������ ���, ������ ��ġ, ������ ����)
            yield return new WaitForSeconds(interval);
        }
    }
}
