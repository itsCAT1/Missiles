using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlaneController : MonoBehaviour
{
    public float speedMoving;
    public float speedRotate;
    public static Transform playerPos;

    Rigidbody2D rigid2D;
    Animator animator;

    public GameObject shieldReceive;
    bool haveShield;
    bool haveSpeedUp;

    public GameObject explosionPrefab;
    public GameObject explosionMissilePrefab;

    Vector2 mouPos = Vector2.zero;
    public Transform joystickInterPos;
    public Transform joystickExterPos;
    public float a;
    void Awake()
    {
        rigid2D = this.GetComponent<Rigidbody2D>();
        playerPos = this.GetComponent<Transform>();
        animator = this.gameObject.transform.GetChild(0).gameObject.GetComponent<Animator>();
    }
    
    void FixedUpdate()
    {
        //MovingInput();
        MovingJoystick();
        FlipPlane();
        UpdateAnimation();
    }

    void MovingInput()
    {
        Quaternion rotate = transform.rotation;
        float angle = rotate.eulerAngles.z - Input.GetAxisRaw("Horizontal") * speedRotate;
        rotate.eulerAngles = new Vector3(0, 0, angle);
        transform.rotation = rotate;

        rigid2D.velocity = this.transform.up * speedMoving;
    }

    void MovingJoystick()
    {
        if(!Input.GetMouseButton(0))
            return;
        if (Input.GetMouseButtonUp(0))
        {
            joystickExterPos.localPosition = Vector2.zero;
        }

        mouPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Debug.DrawLine(joystickExterPos.position, (Vector3)mouPos, Color.red);

        Vector2 direction = (Vector3)mouPos - joystickExterPos.position;

        if(direction.sqrMagnitude < a)
        {
            joystickInterPos.position = Input.mousePosition;
            return;
        }

        float angle = Mathf.Atan2(direction.y, direction.x);
        Vector2 pos;
        pos.x = Mathf.Cos(angle) * 50;
        pos.y = Mathf.Sin(angle) * 50;

        joystickInterPos.localPosition = pos;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(joystickExterPos.position, 0.85f);
    }

    void FlipPlane()
    {
        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }

    void UpdateAnimation()
    {
        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            animator.SetBool("Rotate", true);
        }
        else animator.SetBool("Rotate", false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("shield") && !haveShield)
        {
            Destroy(collision.gameObject);
            shieldReceive.SetActive(true);
            haveShield = true;
        }
        else if (collision.gameObject.CompareTag("missile"))
        {
            if (haveShield)
            {
                StartCoroutine(StateMissileExplosion());
                Destroy(collision.gameObject);
                shieldReceive.SetActive(false);
                haveShield = false;
            }
            else
            {
                //this.gameObject.transform.GetChild(0).gameObject.SetActive(false);
                //speedMoving = 0;
                //speedRotate = 0;
                Destroy(collision.gameObject);
                Debug.Log("Explosion!");
                StartCoroutine(StateExplosion());
            }
        }

        if (collision.gameObject.CompareTag("speedup") && !haveSpeedUp)
        {
            Debug.Log("speedup");
            Destroy(collision.gameObject);
            StartCoroutine(StateSpeedUp());
        }
    }

    IEnumerator StateSpeedUp()
    {
        haveSpeedUp = true;
        float oldSpeed = speedMoving;
        speedMoving = oldSpeed * 2;
        yield return new WaitForSeconds(5);
        speedMoving = oldSpeed;
        haveSpeedUp = false;
    }

    IEnumerator StateExplosion()
    {
        GameObject explosionTemp = Instantiate(explosionPrefab, this.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(2f);
        Destroy(explosionTemp);
    }

    IEnumerator StateMissileExplosion()
    {
        GameObject explosionTemp = Instantiate(explosionMissilePrefab, this.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(2f);
        Destroy(explosionTemp);
    }
}
