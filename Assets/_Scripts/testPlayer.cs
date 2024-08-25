using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testPlayer : MonoBehaviour
{
    [SerializeField] private float _speed;
    private Rigidbody2D _rb;
    void Start()
    {
        _rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
