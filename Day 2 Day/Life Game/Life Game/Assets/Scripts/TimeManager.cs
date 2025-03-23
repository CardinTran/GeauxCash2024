using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class TimeManager : MonoBehaviour
{
    [Header("Time Settings")]
    public int day = 1;
    public int week = 1;
    public int month = 1;

    private float inGameSeconds = 0f;   // Tracks in-game seconds
    private const float secondsPerDay = 1440f;  // 1440 in-game seconds = 1 in-game day

    [Header("UI Display (Optional)")]
    public Text timeDisplay;

    [Header("Events")]
    public UnityEvent OnNewDay;
    public UnityEvent OnNewWeek;
    public UnityEvent OnNewMonth;

    private void Update()
    {
        // Add real deltaTime as in-game seconds
        inGameSeconds += Time.deltaTime;

        // If we pass 1440 in-game seconds, trigger a new day
        if (inGameSeconds >= secondsPerDay)
        {
            inGameSeconds -= secondsPerDay;
            AdvanceDay();
        }

        // Optional: Update the time display in HH:MM format
        if (timeDisplay != null)
        {
            int totalMinutes = Mathf.FloorToInt(inGameSeconds);
            int hours = (totalMinutes / 60) % 24;
            int minutes = totalMinutes % 60;
            timeDisplay.text = $"Day {day} - Time: {hours:D2}:{minutes:D2}";
        }
    }

    private void AdvanceDay()
    {
        day++;
        Debug.Log($"New Day: {day}");
        OnNewDay?.Invoke();

        if (day % 7 == 1 && day != 1)
        {
            week++;
            Debug.Log($"New Week: {week}");
            OnNewWeek?.Invoke();
        }

        if (day % 30 == 1 && day != 1)
        {
            month++;
            Debug.Log($"New Month: {month}");
            OnNewMonth?.Invoke();
        }
    }

    // Optional: Skip time manually
    public void SkipSeconds(float seconds)
    {
        inGameSeconds += seconds;
    }

    void ChargeRent()
    {
        MoneyManager.Instance.PayBill(500f);
    }


}
