using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.UIElements;

public class Thief : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _borderZone;

    private bool _isPassed;

    private Rigidbody2D _rigidbody;
    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _isPassed = false;
        _rigidbody = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        CrossBorderZone();

        if (_isPassed == false)
        {
            Move(_speed);
        }
        else if (_isPassed == true)
        {
            Move(-_speed);
        }
    }

    private void Move(float speed)
    {
        Vector2 currentVelocity = _rigidbody.velocity;

        Vector2 newVelocity = new Vector2(speed, currentVelocity.y);
        _rigidbody.velocity = newVelocity;
    }

    private void CrossBorderZone()
    {
        if (transform.position.x >= _borderZone)
        {
            _isPassed = true;
            FlipSprite();
        }
        else if (transform.position.x <= -_borderZone)
        {
            _isPassed = false;
            FlipSprite();
        }
    }

    private void FlipSprite()
    {
        _spriteRenderer.flipX = _isPassed;
    }
}
