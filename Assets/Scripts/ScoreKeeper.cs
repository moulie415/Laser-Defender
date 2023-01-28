using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{

    float score = 0;
    
    public float GetScore()
    {
        return score;
    }

    public void ModifyScore(float amount)
    {
        score += amount;
        Mathf.Clamp(score, 0, int.MaxValue);
        Debug.Log(score);
    }

    public void ResetScore()
    {
        score = 0;
    }
}
