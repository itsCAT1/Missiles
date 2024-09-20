using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickController : MonoBehaviour
{
    Vector2 mouPos = Vector2.zero;
    public RectTransform joystickInterPos;
    public Vector2 direction;
    public float joystickRadius;

    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            joystickInterPos.localPosition = Vector2.zero;
        }
        /*if (Input.GetMouseButtonDown(0))
        {
            this.transform.position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }*/

        if (!Input.GetMouseButton(0))
            return;

        mouPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Debug.DrawLine(this.transform.position, mouPos, Color.red);
        direction = mouPos - (Vector2)this.transform.position;
        //Debug.Log(direction.magnitude);
        if (direction.magnitude <= joystickRadius)
        {
            joystickInterPos.position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
            return;
        }

        
        float angle = Mathf.Atan2(direction.y, direction.x);

        Vector2 pos;
        pos.x = Mathf.Cos(angle) * joystickRadius;
        pos.y = Mathf.Sin(angle) * joystickRadius;
        joystickInterPos.localPosition = pos;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(this.transform.position, joystickRadius);
    }
}
