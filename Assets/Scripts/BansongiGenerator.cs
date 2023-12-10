using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor.SceneManagement;

public class BansongiGenerator : MonoBehaviour
{
    public GameObject bamsongi_prefab;
    //�������� ǳ�� �� ǳ���� �����ϱ� ���� ����
    public float RandomX; 
    public float RandomY;

    //�� ������ ����� ���� ������ ����. �ٸ� ��ũ��Ʈ������ �������� ����ϱ� ���� static���� ����.
    public static int totalScore;
    public static int totalBam;

    public Text RanDir; //ǳ�� �� ǳ�� ��� �ؽ�Ʈ
    public Text TotalUI; //������ ����� ���� ��� �ؽ�Ʈ
    public Text Restart; //����� �޽��� ��� �ؽ�Ʈ
    
    private void Start()
    {
        Restart.gameObject.SetActive(false); //���� ���� �� ����� �޽��� �����
        
        //�������� ǳ�� �� ǳ�� ����
        RandomX = Random.Range(-10.0f, 10.0f); //X��ǥ: -10.0f ~ 10.0f
        RandomY = Random.Range(-5.0f, 5.0f);  //Y��ǥ: -5.0f ~ 5.0f
        
        totalScore = 0; //���� �ʱ�ȭ
        totalBam = 0; //����� ���� �ʱ�ȭ
    }

    void Update()
    {
        RanDir.text = string.Format("({0:0.0}, {1:0.0}, {2:0.0})", RandomX, RandomY, 0.0f); //ǳ�� �� ǳ�� ���
        TotalUI.text = string.Format("({0:0} : {1:0})", totalBam, totalScore); //����� ������ ���� ���

        if (totalBam < 5) //����� ������ 5 �̸��� ���� �����ϴ� �ڵ�
        {
            if (Input.GetMouseButtonDown(0))
            {
                GameObject bamsogi = Instantiate(bamsongi_prefab) as GameObject;
                Destroy(bamsogi, 3.0f); //3�ʰ� ������ �ڵ����� ����� ����
                
                Ray screen_ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                Vector3 shooting_ray = screen_ray.direction;
                shooting_ray *= 1000;
                shooting_ray.x += RandomX; //X��ǥ ǳ�� �� ǳ�ӿ� ���� ��ȭ �ֱ�
                shooting_ray.y += RandomY; //Y��ǥ ǳ�� �� ǳ�ӿ� ���� ��ȭ �ֱ�
                bamsogi.GetComponent<BamsongiCtrl>().Shoot(shooting_ray);

                //ǳ�� �� ǳ�� �ٽ� ����
                RandomX = Random.Range(-10.0f, 10.0f); 
                RandomY = Random.Range(-5.0f, 5.0f);
            }
        }
        else //����� ������ 5 �̻��� �� �����ϴ� �ڵ�
        {
            Restart.gameObject.SetActive(true); //����� �޽��� ���
            if (Input.GetKeyDown(KeyCode.R)) //R ��ư�� ������ ���� �ε��Ͽ� �ٽ� ����
            {
                EditorSceneManager.LoadScene(0);
            }
        }
    }
}
