using UnityEngine;
using UnityEngine.UI;

public class UITimer : MonoBehaviour
{
    [SerializeField]
    Timer timer;

    [SerializeField]
    Text lblTimer;

    [SerializeField]
    RectTransform panelTimeUp;


    void Awake()
    {
        SubscribeEvent();
    }

    void OnDestroy()
    {
        UnsubscribeEvent();
    }

    void Start()
    {
        timer.Countdown();
    }

    void Update()
    {
        UpdateUI();
    }

    void UpdateUI()
    {
        lblTimer.text = ("Time : " + timer.Current.ToString("0"));
    }

    void OnTimerStart()
    {
        panelTimeUp.gameObject.SetActive(false);
    }

    void OnTimerStop()
    {
        panelTimeUp.gameObject.SetActive(true);
    }

    void SubscribeEvent()
    {
        timer.OnTimerStart += OnTimerStart;
        timer.OnTimerStop += OnTimerStop;
    }

    void UnsubscribeEvent()
    {
        timer.OnTimerStart -= OnTimerStart;
        timer.OnTimerStop -= OnTimerStop;
    }
}
