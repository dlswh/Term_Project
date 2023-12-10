using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float jump_power;
    
    void Start()
    {
        jump_power = Random.Range(4.0f, 9.0f);
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
            GetComponent<Rigidbody>().velocity = new Vector3(0, jump_power, 0);
    }

    private void OnCollisionEnter(Collision collision)
    {
        SceneManager.LoadScene("Flappy");
    }
}
