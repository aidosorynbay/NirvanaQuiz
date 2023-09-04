using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TImer : MonoBehaviour
{
    [SerializeField] float timeToCompleteQuestion = 30f;
    [SerializeField] float timeToReviewQuestion = 3f;
    public bool loadNextQuestion;
    public float fillFraction;
    public bool isAnsweringQuestion;
    float timerValue;
    void Update()
    {
        UpdateTimer();
    }
    
    public void CancelTimer()
    {
        timerValue = 0;
    }
    void UpdateTimer()
    {
        timerValue -= Time.deltaTime;

        if (isAnsweringQuestion)
        {
            if (timerValue > 0)
            {
                fillFraction = timerValue / timeToCompleteQuestion;
            }
            else
            {
                isAnsweringQuestion = false;
                timerValue = timeToReviewQuestion;
            }
        }
        else 
        {
            if (timerValue > 0)
            {
                fillFraction = timerValue / timeToReviewQuestion;
            }
            else
            {
                isAnsweringQuestion = true;
                timerValue = timeToCompleteQuestion;
                loadNextQuestion = true;
            }
        }
    }
}
