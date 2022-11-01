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
        bool canBeSpawnHere;
        Vector3 newPosition;

        do
        {
            canBeSpawnHere = true;

            newPosition = new Vector3(
            Random.Range(-16, 16),
            Random.Range(-8, 8),
            0.0f);

            foreach (Transform segment in GameObject.Find("Player").GetComponent<PlayerMovement>().GetSegments())
            {
                if(newPosition == segment.position)
                {
                    canBeSpawnHere = false;
                    break;
                }
            }
        } while (!canBeSpawnHere);


        gameObject.transform.position = newPosition;
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
