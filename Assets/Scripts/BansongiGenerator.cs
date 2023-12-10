using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor.SceneManagement;

public class BansongiGenerator : MonoBehaviour
{
    public GameObject bamsongi_prefab;
    //랜덤으로 풍향 및 풍속을 설정하기 위한 변수
    public float RandomX; 
    public float RandomY;

    //총 점수와 밤송이 개수 저장할 변수. 다른 스크립트에서도 공용으로 사용하기 위해 static으로 선언.
    public static int totalScore;
    public static int totalBam;

    public Text RanDir; //풍향 및 풍속 출력 텍스트
    public Text TotalUI; //총점과 밤송이 개수 출력 텍스트
    public Text Restart; //재시작 메시지 출력 텍스트
    
    private void Start()
    {
        Restart.gameObject.SetActive(false); //게임 실행 시 재시작 메시지 숨기기
        
        //랜덤으로 풍향 및 풍속 설정
        RandomX = Random.Range(-10.0f, 10.0f); //X좌표: -10.0f ~ 10.0f
        RandomY = Random.Range(-5.0f, 5.0f);  //Y좌표: -5.0f ~ 5.0f
        
        totalScore = 0; //총점 초기화
        totalBam = 0; //밤송이 개수 초기화
    }

    void Update()
    {
        RanDir.text = string.Format("({0:0.0}, {1:0.0}, {2:0.0})", RandomX, RandomY, 0.0f); //풍향 및 풍속 출력
        TotalUI.text = string.Format("({0:0} : {1:0})", totalBam, totalScore); //밤송이 개수와 총점 출력

        if (totalBam < 5) //밤송이 개수가 5 미만일 때만 실행하는 코드
        {
            if (Input.GetMouseButtonDown(0))
            {
                GameObject bamsogi = Instantiate(bamsongi_prefab) as GameObject;
                Destroy(bamsogi, 3.0f); //3초가 지나면 자동으로 밤송이 삭제
                
                Ray screen_ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                Vector3 shooting_ray = screen_ray.direction;
                shooting_ray *= 1000;
                shooting_ray.x += RandomX; //X좌표 풍향 및 풍속에 따른 변화 주기
                shooting_ray.y += RandomY; //Y좌표 풍향 및 풍속에 따른 변화 주기
                bamsogi.GetComponent<BamsongiCtrl>().Shoot(shooting_ray);

                //풍향 및 풍속 다시 설정
                RandomX = Random.Range(-10.0f, 10.0f); 
                RandomY = Random.Range(-5.0f, 5.0f);
            }
        }
        else //밤송이 개수가 5 이상일 때 실행하는 코드
        {
            Restart.gameObject.SetActive(true); //재시작 메시지 출력
            if (Input.GetKeyDown(KeyCode.R)) //R 버튼을 누르면 씬을 로드하여 다시 실행
            {
                EditorSceneManager.LoadScene(0);
            }
        }
    }
}
