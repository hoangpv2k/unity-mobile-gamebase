using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PopupDebug : Popup
{
    [SerializeField] private TMP_InputField setLevel;
    [SerializeField] private TMP_InputField setCoin;
    [SerializeField] private Toggle toggleTesting;

    protected override void OnEnable()
    {
        base.OnEnable();
        toggleTesting.isOn = Data.PlayerData.isTesting;
    }

    public void OnClickAccept()
    {
        if (!string.IsNullOrEmpty(setLevel.text))
        {
            Data.PlayerData.currentLevel = int.Parse(setLevel.text);
            GameManager.Instance.PrepareLevel();
            GameManager.Instance.StartGame();
        }
        if (!string.IsNullOrEmpty(setCoin.text))
        {
            Data.PlayerData.currentMoney = int.Parse(setCoin.text);
        }

        setCoin.text = string.Empty;
        setLevel.text = string.Empty;
        gameObject.SetActive(false);
    }

    public void ChangeTestingState()
    {
        Data.PlayerData.isTesting = toggleTesting.isOn;
    }
}