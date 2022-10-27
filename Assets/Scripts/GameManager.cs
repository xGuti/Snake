using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject _pointPrefab;

    //TODO Points

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameObject.Find("Point(Clone)") == null)
        {
            Vector2 spawnPosition = new Vector2(Random.Range(-8f, 8f), Random.Range(-4f, 4f));
            spawnPosition.x = Mathf.Floor(spawnPosition.x / .5f) * .5f;
            spawnPosition.y = Mathf.Floor(spawnPosition.y / .5f) * .5f;

            Instantiate(_pointPrefab, spawnPosition, Quaternion.identity);
        }
            
    }
}
