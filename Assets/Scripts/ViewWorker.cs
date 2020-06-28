using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ViewWorker : MonoBehaviour {

    [SerializeField]
    private Text _textTimer;
    [SerializeField]
    private Text _textDeltaTime;
    [SerializeField]
    private Text _textPlayerRate;
    [SerializeField]
    private Text _textSpeedCoeff;

    private const string _SEPARATOR = ":";
    private const string _FORM_MIN = "0";
    private const string _FORM_SEC = "00.00000";

    private void Awake()
    {
        _textSpeedCoeff.text = "Speed: 1";
        _textPlayerRate.text = "Grade";
    }

    public void SetSpeedData(int speed)
    {
        _textSpeedCoeff.text = "Speed" + _SEPARATOR + ' ' + speed.ToString();
    }

    public void SetTimerData(float minutes, float seconds)
    {
        _textTimer.text = minutes.ToString(_FORM_MIN) + _SEPARATOR + seconds.ToString(_FORM_SEC);
    }

    public void SetDeltaTimeData(float deltaTime)
    {
        _textDeltaTime.text = deltaTime.ToString(_FORM_SEC);
    }

    public void SetRateTextData(string rateTextData)
    {
        _textPlayerRate.text = rateTextData;
    }
}
