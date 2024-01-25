using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent (typeof(SpriteRenderer))]
[RequireComponent (typeof(Rigidbody2D))]
public class Thief : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _borderZone;

    private bool _isPassed;

    private void Awake()
    {
        _isPassed = false;
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
        Vector2 currentVelocity = GetComponent<Rigidbody2D>().velocity;

        Vector2 newVelocity = new Vector2(speed, currentVelocity.y);
        GetComponent<Rigidbody2D>().velocity = newVelocity;
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
        GetComponent<SpriteRenderer>().flipX = _isPassed;
    }
}
