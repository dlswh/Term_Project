using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    public float speed;

    void Start()
    {
        Destroy(gameObject, 5.0f);
        speed = Random.Range(-6.0f, -4.0f);
    }
    // Update is called once per frame
    void Update()
    {
        transform.Translate(speed * Time.deltaTime, 0, 0);
    }
}
