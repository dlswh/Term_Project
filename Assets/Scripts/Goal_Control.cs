using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal_Control : MonoBehaviour
{
    private bool is_collided = false;

    // Start is called before the first frame update
    void Start()
    {
        transform.Translate(new Vector3(Random.Range(-5.0f, 10.0f), Random.Range(-3.0f, 1.0f), 0));
        transform.localScale = new Vector3(1f, 1f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionStay(Collision other)
    {
        this.is_collided = true;
        other.transform.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
    }

    private void OnGUI()
    {
        /*
        if (is_collided)
            GUI.¹¹¾îÄ«³Ä(new Rect(Screen.width / 2 - 30, 80, 100, 20), "Success!!!");
        */
    }
}
