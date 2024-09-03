using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private float _speedMoving = 300f;
    //[SerializeField] private GameObject _target;
    [SerializeField] private float _angleOffset;
    private Rigidbody2D _rigid2D;
    //public static Transform _playerPos;
    private void Awake()
    {
        _rigid2D = this.GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        Moving();
    }

    void Moving()
    {
        Vector2 dir = PlayerController.playerPos.transform.position - this.transform.position;
        Debug.Log(PlayerController.playerPos.transform.position);
        Quaternion rotate = this.transform.rotation;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg + _angleOffset;
        rotate.eulerAngles = new Vector3(0, 0, angle);
        this.transform.rotation = rotate;

        _rigid2D.velocity = dir.normalized * _speedMoving * Time.deltaTime;
    }

    void Spawn()
    {

    }

    
}
