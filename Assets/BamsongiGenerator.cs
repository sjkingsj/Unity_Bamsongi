using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BamsongiGenerator : MonoBehaviour
{
    // 아웃렛 접속을 사용해 대입할 수 있도록 public 붙여서 선언 
    public GameObject bamsongiPrefab;
    
    void Start()
    {
        
    }

    void Update()
    {
        // 화면을 누르면
        if (Input.GetMouseButtonDown(0))
        {
            // 밤송이 인스턴스 만들기
            GameObject bamsongi = Instantiate(bamsongiPrefab) as GameObject;
            // 카메라에서 탭 좌표로 향하는 벡터에 따른 Ray 클래스 반환, 좌표 전달
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 worldDir = ray.direction;
            // 탭 좌표로 향하는 벡터를 normalized 변수로 길이가 1 * 2000으로 Shoot 매서드 호출
            bamsongi.GetComponent<BamsongiController>().Shoot(worldDir.normalized * 2000);
            // 날리고자 하는 방향의 벡터를 전달하고 Shoot 매서드 호출
            // bamsongi.GetComponent<BamsongiController>().Shoot(new Vector3(0, 200, 2000));
        }
    }
}
