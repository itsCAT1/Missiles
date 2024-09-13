using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndicatorMissileControl : MonoBehaviour
{
    Rigidbody2D rigid2D;
    public Transform missilePos;
    public float speedMoving;
    public float speedRotate;
    public float angleOffset;

    void Start()
    {
        rigid2D = this.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Moving();
    }

    void Moving()
    {
        Vector3 direction = missilePos.position - transform.position;
        var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + angleOffset;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        rigid2D.velocity = direction.normalized * speedMoving;
    }
}
