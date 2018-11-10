using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField]
    float current;

    [SerializeField]
    float max;


    public delegate void _Func();

    public event _Func OnTimerStart;
    public event _Func OnTimerStop;

    public float Current { get { return current; } }
    public float Max { get { return max; } }

    public bool IsStart { get; private set; }
    public bool IsPause { get; set; }


    void Update()
    {
        if (!IsStart || IsPause) {
            return;
        }

        if (current > 0.0f) {
            current -= (1.0f * Time.deltaTime);
        }
        else {
            Stop();
        }
    }

    public void Countdown()
    {
        if (IsStart) {
            return;
        }

        Reset();
        IsStart = true;

        if (OnTimerStart!= null) {
            OnTimerStart();
        }
    }

    public void Stop()
    {
        if (!IsStart) {
            return;
        }

        IsStart = false;
        current = 0.0f;

        if (OnTimerStop != null) {
            OnTimerStop();
        }
    }

    public void Reset()
    {
        IsStart = false;
        IsPause = false;
        current = max;
    }
}

