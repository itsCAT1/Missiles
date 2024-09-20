using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    public Transform plane;
    public float speedMoving;
    public float speedRotate;


    void Update()
    {
        Vector2 direction = (Vector2)this.transform.position - (Vector2)plane.transform.position ;
        float targetAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90;
        Debug.Log(targetAngle);
    }

}
