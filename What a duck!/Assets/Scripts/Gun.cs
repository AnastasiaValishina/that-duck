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

    Button shootButton;
    int bulletAmount;
    float timeStamp;


    void Start()
    {
        shootButton = GetComponent<Button>();
        shootButton.onClick.AddListener(ButtonClicked);
        bulletAmount = bulletAmountFull;
        bulletAmountText.text = bulletAmount.ToString();
    }

    void Update()
    {
        if (bulletAmount <= 0)
        {
            StartCoroutine(CoolDown());
        }
    }

    void ButtonClicked()
    {        
        if (bulletAmount > 0 && timeStamp <= Time.time)
        {
            Bullet bullet = Instantiate(bulletPrefab, gun.transform.position, Quaternion.identity);
            bullet.transform.parent = gun.transform;
            bulletAmount--;
            bulletAmountText.text = bulletAmount.ToString();
            timeStamp = Time.time + timeBetweenShots;
        }      
    }

    IEnumerator CoolDown()
    {
        yield return new WaitForSeconds(coolDownTime);
        bulletAmount = bulletAmountFull;
        bulletAmountText.text = bulletAmount.ToString();
    }

    void ButtonPressed()
    {

    }
}
