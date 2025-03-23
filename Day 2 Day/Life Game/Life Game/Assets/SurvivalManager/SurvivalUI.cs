using UnityEngine;
using UnityEngine.UI;

public class SurvivalUI : MonoBehaviour
{
    [SerializeField] private Survival _survivalManager;
    [SerializeField] private MoneyManager _moneyManager;

    [SerializeField] private Image _hungermeter;
    [SerializeField] private Image _thirstmeter;
    [SerializeField] private Image _happinessmeter;
    [SerializeField] private Image _balancemeter; // 🔥 Balance fill Image

    [SerializeField] private float maxBalance = 1000f; // Adjust based on your game economy

    private void FixedUpdate()
    {
        // Update Survival Bars
        _hungermeter.fillAmount = _survivalManager.HungerPercent;
        _thirstmeter.fillAmount = _survivalManager.ThirstPercent;
        _happinessmeter.fillAmount = _survivalManager.HappinessPercent;

    if (_moneyManager != null)
{
    float currentMoney = _moneyManager.GetCurrentMoney();
    float fill = Mathf.Clamp01(currentMoney / maxBalance);
    Debug.Log($"Money: {currentMoney}, Fill: {fill}");
    _balancemeter.fillAmount = fill;
}
else
{
    Debug.LogWarning("MoneyManager is NULL");
}



    }
}
