using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Vector2 _direction;
    [SerializeField] private float _speed;

    public GameObject _segmentPrefab;
    private List<Transform> _segments;

    // Start is called before the first frame update
    void Start()
    {
        _direction = new Vector2(0.5f, 0f);
        _speed = 1f;

        _segments = new List<Transform>();
        _segments.Add(transform);
    }

    // Update is called once per frame
    void Update()
    {
        if (_direction.x != 0f)
        {
            if (Input.GetKeyDown(KeyCode.W))
                _direction = new Vector2(0, 0.5f);
            else if (Input.GetKeyDown(KeyCode.S))
                _direction = new Vector2(0, -0.5f);
        }
        else if (_direction.y != 0f)
        {
            if (Input.GetKeyDown(KeyCode.A))
                _direction = new Vector2(-0.5f, 0);
            else if (Input.GetKeyDown(KeyCode.D))
                _direction = new Vector2(0.5f, 0);
        }
    }

    private void FixedUpdate()
    {
        transform.position += (Vector3)_direction;
        for(int i = _segments.Count-1 ; i>0 ; i--)
            _segments[i].position = _segments[i - 1].position;
    }

    private void Grow()
    {
        Transform segment = Instantiate(_segmentPrefab).GetComponent<Transform>();
        segment.position = _segments[_segments.Count - 1].position;

        _segments.Add(segment);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Point"))
        {
            Grow();
            //TODO Add points
        }
        else
        {
            Debug.Log(collision.collider.name);
            //TODO Lose conditions
        }
    }

}
