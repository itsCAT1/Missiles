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

    public JoystickController joystickController;
    void Awake()
    {
        rigid2D = this.GetComponent<Rigidbody2D>();
        playerPos = this.GetComponent<Transform>();
        animator = this.gameObject.transform.GetChild(0).gameObject.GetComponent<Animator>();
    }


    void FixedUpdate()
    {
        MovingInput();
        FlipPlane();
        UpdateAnimation();
        //MovingInputJoystick();
        //FlipPlaneJoystick();
        //UpdateAnimationJoystick();
    }

    void MovingInput()
    {
        Quaternion rotate = transform.rotation;
        float angle = rotate.eulerAngles.z - Input.GetAxisRaw("Horizontal") * speedRotate;
        rotate.eulerAngles = new Vector3(0, 0, angle);
        transform.rotation = rotate;
        
        rigid2D.velocity = this.transform.up * speedMoving;
    }
    
    void MovingInputJoystick()
    {
        var directionNormalized = joystickController.direction.normalized;
        Vector2 dir = Input.mousePosition - joystickController.transform.position;

        float targetAngle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90;

        float currentAngle = transform.rotation.eulerAngles.z;

        float newAngle = Mathf.LerpAngle(currentAngle, targetAngle, speedRotate * Time.deltaTime);
        Debug.Log(newAngle);
        if (newAngle != 0)
        {
            animator.SetBool("Rotate", true);
            if (newAngle < 0)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
            else
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
        }
        else animator.SetBool("Rotate", false);

        transform.rotation = Quaternion.Euler(0, 0, newAngle);

        rigid2D.velocity = this.transform.up * speedMoving;
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

    void FlipPlaneJoystick()
    {
        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else 
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }

    private void UpdateAnimationJoystick()
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
                GameObject explosionTemp = Instantiate(explosionMissilePrefab, this.transform.position, Quaternion.identity);
                Destroy(collision.gameObject);
                shieldReceive.SetActive(false);
                haveShield = false;
            }
            else
            {
                //this.gameObject.transform.GetChild(0).gameObject.SetActive(false);
                //speedMoving = 0;
                //speedRotate = 0;
                Debug.Log("Explosion!");
                GameObject explosionTemp = Instantiate(explosionPrefab, this.transform.position, Quaternion.identity);
                //Destroy(collision.gameObject);
            }
        }

        if (collision.gameObject.CompareTag("speedup") && !haveSpeedUp)
        {
            Debug.Log("speedup");
            Destroy(collision.gameObject);
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
}
