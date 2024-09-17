using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickController : MonoBehaviour
{
    Vector2 mouPos = Vector2.zero;
    public Transform joystickInterPos;
    public Vector2 direction;

    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            joystickInterPos.localPosition = Vector2.zero;
        }
        /*if (Input.GetMouseButtonDown(0))
        {
            this.transform.position = Input.mousePosition;
        }*/

        if (!Input.GetMouseButton(0))
            return;

        mouPos = Input.mousePosition;

        Debug.DrawLine(this.transform.position, mouPos, Color.red);

        direction = (Vector3)mouPos - this.transform.position;

        if(direction.magnitude <= 164)
        {
            joystickInterPos.position = Input.mousePosition;
            return;
        }

        float angle = Mathf.Atan2(direction.y, direction.x);

        Vector2 pos;
        pos.x = Mathf.Cos(angle) * 164;
        pos.y = Mathf.Sin(angle) * 164;

        joystickInterPos.localPosition = pos;
    }
}
