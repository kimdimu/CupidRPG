using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpBar : MonoBehaviour
{
    public Image bar;
    public Health health;
    private void Update()
    {
        UpdateHpBar();
    }
    public void UpdateHpBar()
    {
        bar.fillAmount = health.FillAmount();
    }
}
