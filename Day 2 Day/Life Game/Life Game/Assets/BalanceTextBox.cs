using UnityEngine;
using UnityEngine.UI;

public class BalanceTextBox : MonoBehaviour
{
    public GameObject textBoxPanel;
    public Text balanceText;  // THIS IS YOUR TEXTBOX, NOT THE MONEY HUD

    public void ShowBalance()
    {
        float balance = MoneyManager.Instance.GetCurrentMoney();
        balanceText.text = "Your balance is: $" + balance.ToString("F2");
        textBoxPanel.SetActive(true);
    }

    public void HideBalance()
    {
        textBoxPanel.SetActive(false);
    }
}
