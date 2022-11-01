using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Vector2 _direction;
    [SerializeField] private Vector2 _lastPosition;

    public Transform _segmentPrefab;
    private List<Transform> _segments;

    public GameObject _gameManager;

    // Start is called before the first frame update
    void Start()
    {
        _direction = Vector2.right;

        _segments = new List<Transform>();
        _segments.Add(gameObject.transform);

        _lastPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
            if (_direction.x != 0f)
            {
                if ( ( Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow) ) && ( (Vector2) transform.position + Vector2.up ) != _lastPosition )
                    _direction = Vector2.up;
                else if ((Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) && ((Vector2)transform.position + Vector2.down) != _lastPosition)
                    _direction = Vector2.down;
            }
            else if (_direction.y != 0f)
            {
                if ((Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) && ((Vector2)transform.position + Vector2.left) != _lastPosition)
                    _direction = Vector2.left;
                else if ((Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) && ((Vector2)transform.position + Vector2.right) != _lastPosition)
                    _direction = Vector2.right;
            }
    }
    private void FixedUpdate()
    {
        for(int i = _segments.Count-1 ; i>0 ; i--)
            _segments[i].position = _segments[i - 1].position;

        _lastPosition = transform.position;

        transform.position += (Vector3)_direction;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Point"))
            Grow();
        else
            _gameManager.GetComponent<GameManager>().GameOver();

    }

    private void Grow()
    {
        Transform segment = Instantiate(_segmentPrefab);
        segment.position = _segments[_segments.Count - 1].position;

        _segments.Add(segment);
    }
}
