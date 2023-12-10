using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUI : MonoBehaviour
{
    public Text time;
    public Text jump;
    private float timeSum;
    public Player player;

    private void Start()
    {
        timeSum = 0f;
    }
    // Update is called once per frame
    void Update()
    {
        time.text = "시간: " + Mathf.RoundToInt(timeSum += Time.deltaTime);
        jump.text = "점프력: " + Mathf.RoundToInt(player.jump_power);
    }
}
