using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestIndicator : MonoBehaviour
{
    public GameObject Indicator; // Icon chỉ báo
    public GameObject Target; // Đối tượng kẻ địch
    public float angleOffset;
    public float horizontalLimit = 2.68f; // Giới hạn chiều ngang (World Point)
    public float verticalLimit = 4.87f; // Giới hạn chiều dọc (World Point)
    private Camera cam;

    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 screenPos = cam.WorldToViewportPoint(Target.transform.position);
        
        // Kiểm tra nếu đối tượng ở ngoài tầm nhìn của camera
        if (screenPos.z < 0 || screenPos.x < 0 || screenPos.x > 1 || screenPos.y < 0 || screenPos.y > 1)
        {
            if (!Indicator.activeSelf)
            {
                Indicator.SetActive(true);
            }

            // Xác định hướng từ player tới target
            Vector3 direction = (Target.transform.position - cam.transform.position).normalized;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + angleOffset;
            Indicator.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

            Vector3 targetWorldPos = Target.transform.position;

            // Giới hạn vị trí của chỉ báo theo World Point (chiều ngang 5.5, chiều dọc 10)
            targetWorldPos.x = Mathf.Clamp(targetWorldPos.x, -horizontalLimit, horizontalLimit);
            targetWorldPos.y = Mathf.Clamp(targetWorldPos.y, -verticalLimit, verticalLimit);

            Indicator.transform.position = targetWorldPos;
        }
        else
        {
            if (Indicator.activeSelf)
            {
                Indicator.SetActive(false);
            }
        }
    }
}
