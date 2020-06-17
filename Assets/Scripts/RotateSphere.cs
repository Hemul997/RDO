using System.Collections;
using UnityEngine;


public class RotateSphere : MonoBehaviour {

    [SerializeField] private Transform _shpereAnchor;

    [SerializeField] private float _speed = 360.0f / 15.0f;
    [SerializeField] private ViewWorker _viewWorker;
    [SerializeField] private PlayerBehaviorRater _playerRater;

    private const int _SEC_IN_MIN = 60;
    private const float _DEG_IN_CIRCLE = 360.0f;


    private float _time;
    private bool _isPlay;
    private int _speedCoef = 1;

    /// <summary>
    /// 
    /// </summary>
    private void Update () {
	    if (Input.GetKeyUp(KeyCode.Space)) {
	        if (!_isPlay) {
                StartCoroutine(Rotate(_shpereAnchor, Vector3.up, _speedCoef));
            }
	        else {
	            StopAllCoroutines();
                float deltaTime = CalculateTime();
                _viewWorker.SetDeltaTimeData(deltaTime);

                _playerRater.ChangeRateLevel(deltaTime);
                SetRate(_playerRater.GeneratePlayerRate());
            }
	        _isPlay = !_isPlay;
	    }
	}
    /// <summary>
    /// 
    /// </summary>
    /// <param name="rate"></param>
    private void SetRate(Rate rate)
    {
        _speedCoef = rate.SphereSpeed;
        _viewWorker.SetSpeedData(rate.SphereSpeed);
        _viewWorker.SetRateTextData(rate.TextRate);
    }
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    private float CalculateTime() {
        var rotY = _shpereAnchor.localEulerAngles.y;
        if (rotY < _DEG_IN_CIRCLE * 0.5f)
            return  rotY / _speed;
        return (rotY - _DEG_IN_CIRCLE) / _speed;
    }
    /// <summary>
    /// 
    /// </summary>
    private void UpdateTimer() {
        _time += Time.deltaTime;
        var min = _time / _SEC_IN_MIN;
        var sec = _time % _SEC_IN_MIN;
        _viewWorker.SetTimerData(min, sec);

    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="obj"></param>
    /// <param name="axis"></param>
    /// <param name="speedCoef"></param>
    /// <returns></returns>
    private IEnumerator Rotate(Transform obj, Vector3 axis, int speedCoef) {
        while (true) {
            UpdateTimer();
            obj.localRotation *= Quaternion.AngleAxis(_speed * Time.deltaTime * speedCoef, axis);
            yield return new WaitForEndOfFrame();
        }
    }

}
