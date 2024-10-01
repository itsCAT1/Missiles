using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class StarControl : MonoBehaviour
{
    public float speedRotate;
    Rigidbody2D rb;
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Quaternion rotate = transform.rotation;
        float angle = rotate.eulerAngles.z + speedRotate;
        rotate.eulerAngles = new Vector3(0 ,0, angle);
        transform.rotation = rotate;
    }
}
