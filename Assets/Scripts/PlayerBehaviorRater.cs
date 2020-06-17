using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviorRater : MonoBehaviour
{
    private const float START_GOOD_ERROR_RANGE = -0.7f;
    private const float END_GOOD_ERROR_RANGE = -0.2f;
    private const float START_NORMAL_ERROR_RANGE = -0.2f;
    private const float END_NORMAL_ERROR_RANGE = 0.8f;

    private const string RATE_LEVEL_GOOD = "Хорошо";
    private const string RATE_LEVEL_NORMAL = "Норма";
    private const string RATE_LEVEL_POORLY = "Плохо";

    private RateLevel CurrRateLevel;


    /// <summary>
    /// MonoBehaviour function
    /// called when the script instance is being loaded. 
    /// </summary>
    void Awake()
    {
        CurrRateLevel = RateLevel.START;
    }

    /// <summary>
    /// Changed rate level based on 
    /// </summary>
    /// <param name="deltaTime"></param>
    public void ChangeRateLevel(float deltaTime)
    {
        CountCurrPlayerRateLevel(deltaTime);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public Rate GeneratePlayerRate()
    {
        switch (CurrRateLevel)
        {
            case RateLevel.GOOD:
                return new Rate(RATE_LEVEL_GOOD, Random.Range(5, 7));
            case RateLevel.NORMAL:
                return new Rate(RATE_LEVEL_NORMAL, Random.Range(3, 5));
            default:
                return new Rate(RATE_LEVEL_POORLY, Random.Range(1, 3));
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="deltaTime"></param>
    private void CountCurrPlayerRateLevel(float deltaTime)
    {
        if (deltaTime > (START_GOOD_ERROR_RANGE) && deltaTime < (END_GOOD_ERROR_RANGE))
        {
            CurrRateLevel = RateLevel.GOOD;
        } else if (deltaTime > START_NORMAL_ERROR_RANGE && deltaTime < END_NORMAL_ERROR_RANGE)
        {
            CurrRateLevel = RateLevel.NORMAL;
        } else {
            CurrRateLevel = RateLevel.POOR;
        }
    }

    public enum RateLevel
    {
        GOOD, NORMAL, POOR, START
    }
}