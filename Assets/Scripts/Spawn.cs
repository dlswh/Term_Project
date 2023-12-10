using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject pf_wall;
    public float interval;

    IEnumerator Start() // IEnumerator: 해당 함수의 쓰레드를 생성하여 별도로 동작시킴
    {
        while (true)
        {
            interval = Random.Range(1.0f, 2.0f);
            Instantiate(pf_wall, new Vector3(transform.position.x, Random.Range(-3.0f, 4.0f), transform.position.z), transform.rotation); //instantiate(복제할 대상, 지정할 위치, 지정한 방향)
            yield return new WaitForSeconds(interval);
        }
    }
}
