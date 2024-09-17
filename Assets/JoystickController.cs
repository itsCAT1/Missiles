using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickController : MonoBehaviour
{

    Vector2 mouPos = Vector2.zero;
    public Transform joystickInterPos;
    public float a;

    private void Update()
    {
        MovingJoystick();
    }


    void MovingJoystick()
    {
        if (!Input.GetMouseButton(0))
            return;

        
        if (Input.GetMouseButtonUp(0))
        {
            joystickInterPos.position = Vector2.zero;

        }
        Debug.Log(joystickInterPos.position);
        mouPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Debug.DrawLine(this.transform.position, (Vector3)mouPos, Color.red);

        Vector2 direction = (Vector3)mouPos - this.transform.position;

        if (direction.magnitude < a)
        {
            joystickInterPos.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            return;
        }

        float angle = Mathf.Atan2(direction.y, direction.x);
        Vector2 pos;
        pos.x = Mathf.Cos(angle) * a;
        pos.y = Mathf.Sin(angle) * a;

        joystickInterPos.position = pos;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(this.transform.position, 0.85f);
    }
}
