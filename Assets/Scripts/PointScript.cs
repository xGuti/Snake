using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointScript : MonoBehaviour
{
    private void Start()
    {
        SetRandomPosition();
    }

    private void SetRandomPosition()
    {
        gameObject.transform.position = new Vector3(
            Random.Range(-16, 16),
            Random.Range(-8, 8),
            0.0f
            );
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            ScoreScript._score += 100;
            SetRandomPosition();
            //Destroy(gameObject);
        }
    }
}
