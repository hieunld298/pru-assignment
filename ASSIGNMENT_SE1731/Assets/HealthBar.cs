using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthBar : MonoBehaviour
{
    public Image healthBar;
    public TextMeshProUGUI healthText;
    public void UpdateBar(int currentValue, int maxValue)
    {
        healthBar.fillAmount = (float)currentValue / (float)maxValue;
        Debug.Log((float)currentValue / (float)maxValue);
        healthText.text=currentValue.ToString() + " / "+ maxValue.ToString();
    }
}
