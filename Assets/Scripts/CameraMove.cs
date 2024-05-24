using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Transform target; // 카메라가 따라갈 타겟 (캐릭터)
    public float smoothing = 5f; // 카메라 이동의 부드러움 정도

    private Vector3 offset; // 초기 오프셋 값

    void Start()
    {
        // 초기 오프셋 계산
        offset = transform.position - target.position;
    }

    void LateUpdate()
    {
        // 타겟의 새로운 위치 계산
        Vector3 targetCamPos = target.position + offset;

        // 카메라의 위치를 부드럽게 이동
        transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);
    }
}
