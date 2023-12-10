using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject ball;
    private Vector3 RanPos;
    private float time;
    
    public static bool gameOver;
    public static bool lose;

    public Text timeUI;
    public Text scoreUI;
    public Text msgUI;
    public Text reUI;

    // Start is called before the first frame update
    void Start()
    {
        time = 0;
        gameOver = false;
        msgUI.gameObject.SetActive(false);
        reUI.gameObject.SetActive(false);
        lose = false;
        StartCoroutine(startClone());
    }
    IEnumerator startClone()
    {
        while (!gameOver)
        {
            RanPos = new Vector3(Random.Range(-10f, 10f), 12, 0);
            Instantiate(ball, RanPos, ball.transform.rotation);

            yield return new WaitForSecondsRealtime(2.0f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (time <= 30.0f && !gameOver)
        {

            time += Time.deltaTime;
            timeUI.text = "Time: " + Mathf.RoundToInt(time);
            scoreUI.text = "Score: " + PlayerCtrl.score;
        }
        else
        {
            gameOver = true;
        }

        if (lose)
        {
            msgUI.text = "Fail...";
        }

        if (gameOver)
        {
            msgUI.gameObject.SetActive(true);
            reUI.gameObject.SetActive(true);
            if (Input.GetKeyDown(KeyCode.R))
                SceneManager.LoadScene(0);
        }
    }
}
