using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BamsongiController : MonoBehaviour
{
    // 매개변수 방향으로 힘을 가하기
    public void Shoot(Vector3 dir)
    {
        GetComponent<Rigidbody>().AddForce(dir);
    }

    // 충돌을 감지하면
    void OnCollisionEnter(Collision other)
    {
        GetComponent<Rigidbody>().isKinematic = true; // 움직임을 멈추기
        GetComponent<ParticleSystem>().Play(); // 파티클 재생
    }

    void Start()
    {
        // +Z축 방향 벡터를 매개변수로 전달, 중력으로 낙하를 방지하기 위해 Y축 방향 힘 가하기
        // Shoot(new Vector3(0, 200, 2000));
    }

    void Update()
    {
        
    }
}
