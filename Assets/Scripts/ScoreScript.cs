using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreScript : MonoBehaviour
{
    public static int _score = 0;
    private TextMeshProUGUI _tmp;
    private void Start()
    {
        _score = 0;
        _tmp = GetComponent<TextMeshProUGUI>();
    }
    void Update()
    {
        _tmp.text = "Score: " + _score.ToString();
    }
}
