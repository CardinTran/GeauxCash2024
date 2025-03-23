using UnityEngine;
using UnityEngine.UI;

public class MoneyManager : MonoBehaviour
{
    public GameManagerScript gameManager;  // Drag in Inspector
    public static MoneyManager Instance;  // Singleton access across scenes

    [Header("Money Settings")]
    public float currentMoney = 500f;        // Starting money
    public Text moneyText;                   // Optional: Assign your money UI Text

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }


    private void Update()
    {
        if (moneyText != null)
        {
            moneyText.text = "$" + currentMoney.ToString("F2");
        }
    }

    // Method to earn income
    public void EarnIncome(float amount)
    {
        currentMoney += amount;
        Debug.Log($"Income Earned: +${amount}. Current Money: ${currentMoney}");
    }

    // Method to pay expenses (like buying items)
    public void PayExpense(float amount)
    {
        currentMoney -= amount;
        Debug.Log($"Expense Paid: -${amount}. Current Money: ${currentMoney}");

        CheckForDebt();
    }

    // Method to pay bills
    public void PayBill(float amount)
    {
        currentMoney -= amount;
        Debug.Log($"Bill Paid: -${amount}. Current Money: ${currentMoney}");

        CheckForDebt();
    }

    // Optional: Trigger Game Over or consequences if money runs out
    private void CheckForDebt()
    {
        if (currentMoney < 0)
        {
        Debug.Log("You're in debt! Triggering Game Over...");
        gameManager.GameOver();
        }
    }

    // Method to get current balance
    public float GetCurrentMoney()
    {
        return currentMoney;
    }

    public void CollectPaycheck()
    {
        EarnIncome(100f);  // No need to call through the Instance, you're already in the instance
    }


}
