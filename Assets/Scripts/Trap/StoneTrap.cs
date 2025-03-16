using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneTrap : MonoBehaviour
{
    public float swingSpeed = 2f;  // Tốc độ đung đưa
    public float swingAngle = 45f; // Góc lệch tối đa

    private float startAngle;

    void Start()
    {
        startAngle = transform.eulerAngles.z; // Lưu góc ban đầu
    }

    void Update()
    {
        float angle = swingAngle * Mathf.Sin(Time.time * swingSpeed);
        transform.rotation = Quaternion.Euler(0, 0, startAngle + angle);
    }
}
