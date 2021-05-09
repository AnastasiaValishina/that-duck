using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{
    [SerializeField] Bullet bulletPrefab;
    [SerializeField] GameObject gun;
    [SerializeField] int bulletAmountFull = 5;
    [SerializeField] float coolDownTime = 4f;
    [SerializeField] float timeBetweenShots = 0.5f;

    [Header("UI")]
    [SerializeField] Text bulletAmountText;
    [SerializeField] Image coolDownImage;

    Button shootButton;
    int bulletAmount;
    float timeStamp;
    bool coolingDown = false;

    void Start()
    {
        shootButton = GetComponent<Button>();
        shootButton.onClick.AddListener(ButtonClicked);
        bulletAmount = bulletAmountFull;
        bulletAmountText.text = bulletAmount.ToString();
        coolDownImage.fillAmount = 0f;
    }

    void Update()
    {
        if (coolingDown)
        {
            coolDownImage.fillAmount -= 1.0f / coolDownTime * Time.deltaTime;
        }
    }

    void ButtonClicked()
    {
        Shoot();
    }

    private void Shoot()
    {
        if (bulletAmount > 0 && timeStamp <= Time.time)
        {
            Bullet bullet = Instantiate(bulletPrefab, gun.transform.position, Quaternion.identity);
            bullet.transform.parent = gun.transform;
            bulletAmount--;
            bulletAmountText.text = bulletAmount.ToString();
            timeStamp = Time.time + timeBetweenShots;
            shootButton.interactable = false;

            if (bulletAmount <= 0)
            {
                StartCoroutine(CoolDown());
            }
        }
    }

    IEnumerator CoolDown()
    {
        shootButton.interactable = false;
        coolDownImage.fillAmount = 1.0f;
        coolingDown = true;
        yield return new WaitForSeconds(coolDownTime);
        shootButton.interactable = true;
        bulletAmount = bulletAmountFull;
        bulletAmountText.text = bulletAmount.ToString();
    }

    void ButtonPressed()
    {

    }
}
