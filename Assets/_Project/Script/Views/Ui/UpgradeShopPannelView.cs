using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UpgradeShopPannelView : MonoBehaviour
{
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI priceText;
    public Button upgradeButton;
    public Image meatUpgradeBG;
    public Sprite unlockImage;
    public Sprite lockImage;

    public Button[] troopButtons;

    public void MeatGenUpgradeButton()
    {
        Controller.self.purchaseManager.UpgradeMeatGeneration();
        UpdateTexts();
        SoundManager.Instance.PlaySound(SoundManager.Instance.button);
    }

    public void UpdateTexts()
    {
        priceText.text = Controller.self.purchaseManager.GetCurrentMeatUpgradePrice().ToString();
        timeText.text = (Mathf.Round(Controller.self.meatManager.GetCurrentDecreaseAmount() * Mathf.Pow(10, 3)) / Mathf.Pow(10, 3)).ToString() + "/s";
        if(Controller.self.currencyManager.GetCurrentCoin() < Controller.self.purchaseManager.GetCurrentMeatUpgradePrice())
        {
            upgradeButton.interactable = false;
            meatUpgradeBG.sprite = lockImage;
            priceText.color = Color.red;
        }
        else
        {
            upgradeButton.interactable = true;
            meatUpgradeBG.sprite = unlockImage;
            priceText.color = Color.black;
        }
    }

    public void RefreshUi()
    {
        UpdateTexts();


        for (int i = 0; i < troopButtons.Length; i++)
        {
            troopButtons[i].GetComponent<TroopButton>().OnStart();
        }
    }
}
