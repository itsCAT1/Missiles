using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    Rigidbody2D rigid2D;
    public float speedMoving;
    public float speedRotate;

    private void Start()
    {
        rigid2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Quaternion rotate = transform.rotation;
        var angle = rotate.eulerAngles.z - Input.GetAxisRaw("Horizontal") * speedRotate;
        rotate = Quaternion.Euler(0, 0, angle);
        transform.rotation = rotate;

        rigid2D.velocity = transform.up * speedMoving;
    }

}
