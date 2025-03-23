using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class ObstacleEventManager : MonoBehaviour
{
    [System.Serializable]
    public class ObstacleEvent
    {
        public string description;
        public float cost;
    }

    public List<ObstacleEvent> eventPool;
    public GameObject eventPanel;
    public Text eventText;
    public Button payButton;
    public Button ignoreButton;

    private ObstacleEvent currentEvent;
    private MoneyManager moneyManager;

    void Start()
    {
        moneyManager = FindObjectOfType<MoneyManager>();
        eventPanel.SetActive(false);
        // Optional: Start random events triggering every 60 seconds
        InvokeRepeating("TriggerRandomEvent", 30f, 60f);
    }

    public void TriggerRandomEvent()
    {
        if (eventPool.Count == 0) return;

        currentEvent = eventPool[Random.Range(0, eventPool.Count)];
        eventText.text = currentEvent.description + "\nCost: $" + currentEvent.cost;
        eventPanel.SetActive(true);
    }

    public void PayEvent()
    {
        if (moneyManager != null)
        {
            moneyManager.PayExpense(currentEvent.cost);
            Debug.Log("Paid event cost.");
        }
        eventPanel.SetActive(false);
    }

    public void IgnoreEvent()
    {
        Debug.Log("Ignored the event. You may penalize here if you want.");
        eventPanel.SetActive(false);
    }
}
