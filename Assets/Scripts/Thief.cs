using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Thief : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _border;

    private bool _isPassed;

    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _isPassed = false;
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        CheckBorder();
    }

    private void Move(float speed)
    {
        Vector2 currentVelocity = _rigidbody.velocity;

        Vector2 newVelocity = new Vector2(speed, currentVelocity.y);
        _rigidbody.velocity = newVelocity;
    }

    private void CheckBorder()
    {
        if (_isPassed == false)
        {
            Move(_speed);

            if(transform.position.x >= _border)
            {
                _isPassed = true;
                transform.localScale = new Vector3(-1f, 1f, 1f);
            }
        }

        if (_isPassed == true)
        {
            Move(-_speed);

            if (transform.position.x <= -_border)
            {
                _isPassed = false;
                transform.localScale = new Vector3(1f, 1f, 1f);
            }
        }
    }
}
