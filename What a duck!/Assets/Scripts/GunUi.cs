using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunUi : MonoBehaviour
{
    [SerializeField] Text bulletAmountText;
    [SerializeField] Image coolDownImage;

    Gun gun;
    public Button shootButton;

    void Start()
    {
        gun = GetComponent<Gun>();
        coolDownImage.fillAmount = 0f;
        shootButton = GetComponent<Button>();
        shootButton.onClick.AddListener(ButtonClicked);
        UpdateText();
    }

    void Update()
    {
        if (gun.coolingDown)
        {
            coolDownImage.fillAmount -= 1.0f / gun.coolDownTime * Time.deltaTime;
        }
    }
    void ButtonClicked()
    {
        gun.Shoot();
    }

    public void UpdateText()
    {
        bulletAmountText.text = gun.bulletAmount.ToString();
    }

    public void CoolDown()
    {
        coolDownImage.fillAmount = 1.0f;
        gun.coolingDown = true;
    }
}
