using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(SpriteRenderer), typeof(Rigidbody2D))]
public class Thief : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform[] _waypoints;

    private int _currentWaypoint;

    private Rigidbody2D _rigidbody;
    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _currentWaypoint = 0;

        _spriteRenderer = GetComponent<SpriteRenderer>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private Vector3 GetNextWaypoint()
    {
        _currentWaypoint = (++_currentWaypoint) % _waypoints.Length;
        Vector3 waypoint = _waypoints[_currentWaypoint].transform.position;

        return waypoint;
    }

    private void Move()
    {
        Transform currentWaypoint = _waypoints[_currentWaypoint];
        transform.position = Vector3.MoveTowards(transform.position, currentWaypoint.position, _speed * Time.deltaTime);

        if (transform.position.x == currentWaypoint.position.x)
        {
            GetNextWaypoint();
            FlipSprite();
        }
    }

    private void FlipSprite()
    {
        _spriteRenderer.flipX = _currentWaypoint > 0 ? true : false;
    }
}
