using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speedMoving = 500f;
    [SerializeField] private float _speedRotate = 100f;
    public static Transform _playerPos;
    private Rigidbody2D _rigid2D;

    void Awake()
    {
        _rigid2D = this.GetComponent<Rigidbody2D>();
        _playerPos = this.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        //Ridgid2D.velocity = new Vector3(Input.GetAxisRaw("Horizontal") * _speed, Input.GetAxisRaw("Vertical") * _speed, 0);
        Quaternion rotate = transform.rotation;
        float angle = rotate.eulerAngles.z - Input.GetAxisRaw("Horizontal") * _speedRotate * Time.deltaTime;
        rotate.eulerAngles = new Vector3(0, 0 , angle);
        transform.rotation = rotate;
        
        _rigid2D.velocity = this.transform.up* _speedMoving * Time.deltaTime;
        Camera.main.transform.position = new Vector3(transform.position.x, transform.position.y, -10);
    }
}
