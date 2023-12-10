using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballCtrl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        float ranNum = Random.Range(0.5f, 3f);
        transform.localScale = new Vector3(ranNum, ranNum, ranNum);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "floor")
        {
            GameManager.lose = true;
            GameManager.gameOver = true;
        }
            
        Destroy(gameObject);
    }
}
