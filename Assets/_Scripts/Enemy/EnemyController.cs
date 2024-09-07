using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemyController : MonoBehaviour
{
    public class Missile : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rb;
        [SerializeField] private Rigidbody2D _rbtarget;
        [SerializeField] private float _speed = 15;
        [SerializeField] private float _rotateSpeed = 95;

        [SerializeField] private float _maxDistancePredict = 100;
        [SerializeField] private float _minDistancePredict = 5;
        [SerializeField] private float _maxTimePrediction = 5;
        private Vector3 _standardPrediction, _deviatedPrediction;

        [SerializeField] private float _deviationAmount = 50;
        [SerializeField] private float _deviationSpeed = 2;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
            _rbtarget = PlayerController.playerPos.GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            _rb.velocity = transform.forward * _speed;

            var leadTimePercentage = Mathf.InverseLerp(_minDistancePredict, _maxDistancePredict, Vector3.Distance(transform.position, PlayerController.playerPos.transform.position));

            PredictMovement(leadTimePercentage);

            AddDeviation(leadTimePercentage);

            RotateRocket();
        }

        private void PredictMovement(float leadTimePercentage)
        {
            var predictionTime = Mathf.Lerp(0, _maxTimePrediction, leadTimePercentage);

            _standardPrediction = _rbtarget.position + _rbtarget.velocity * predictionTime;
        }

        private void AddDeviation(float leadTimePercentage)
        {
            var deviation = new Vector3(Mathf.Cos(Time.time * _deviationSpeed), 0, 0);

            var predictionOffset = transform.TransformDirection(deviation) * _deviationAmount * leadTimePercentage;

            _deviatedPrediction = _standardPrediction + predictionOffset;
        }

        private void RotateRocket()
        {
            var heading = _deviatedPrediction - transform.position;

            var rotation = Quaternion.LookRotation(heading);
            _rb.MoveRotation(Quaternion.RotateTowards(transform.rotation, rotation, _rotateSpeed * Time.deltaTime));
        }


        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(transform.position, _standardPrediction);
            Gizmos.color = Color.green;
            Gizmos.DrawLine(_standardPrediction, _deviatedPrediction);
        }
    }
}

/*  public float speedMoving;
    public float angleOffset;
    private Rigidbody2D rigid2D;
    private void Awake()
    {
        rigid2D = this.GetComponent<Rigidbody2D>();
    }

    
    void FixedUpdate()
    {
        Moving();
    }

    void Moving()
    {
        Vector2 dir = PlayerController.playerPos.transform.position - this.transform.position;
        Quaternion rotate = this.transform.rotation;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg + angleOffset;
        rotate.eulerAngles = new Vector3(0, 0, angle);
        this.transform.rotation = rotate;

        rigid2D.velocity = dir.normalized * speedMoving;
    }*/
