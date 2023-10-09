using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    TextMeshProUGUI text;
    [HideInInspector]
    public int score;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = score.ToString();
    }

    public void ChangeScore(int amount)//Let's other code change the score.
    {
        score += amount;
    }

    public int GetScore()
    {
        return score;
    }
}
