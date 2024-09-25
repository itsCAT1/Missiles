using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    public Transform plane;
    public float speedMoving;
    public float speedRotate;
    public Rigidbody2D rb;

    void FixedUpdate()
    {
        Vector2 direction = (Vector2)plane.transform.position - (Vector2)this.transform.position;
        Debug.DrawLine(this.transform.position, plane.transform.position, Color.red);
        float rotateAmount = Vector3.Cross(direction.normalized, transform.up).z;
        float angle = Vector2.Angle(direction, plane.transform.position);
        Debug.Log(angle);
        rb.angularVelocity = -rotateAmount * angle * speedRotate;
        rb.velocity = transform.up * speedMoving;
    }

}
