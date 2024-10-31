using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickController : MonoBehaviour
{
    public RectTransform joystickHandle;
    public Vector2 direction;
    public float joystickRadius;

    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            joystickHandle.localPosition = Vector2.zero;
        }

        if (!Input.GetMouseButton(0))
            return;

        Vector2 mouPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Debug.DrawLine(this.transform.position, mouPos, Color.red);
        direction = mouPos - (Vector2)this.transform.position;

        if (direction.magnitude <= joystickRadius)
        {
            joystickHandle.position = mouPos;
            return;
        }

        float angle = Mathf.Atan2(direction.y, direction.x);

        Vector2 posLimited;
        posLimited.x = Mathf.Cos(angle) * joystickRadius;
        posLimited.y = Mathf.Sin(angle) * joystickRadius;
        joystickHandle.localPosition = posLimited;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(this.transform.position, joystickRadius);
    }
}
