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
    [SerializeField] Transform bulletParentUi;
    [SerializeField] GameObject bulletUi;

    Button shootButton;
    int bulletAmount;
    float timeStamp;


    void Start()
    {
        shootButton = GetComponent<Button>();
        shootButton.onClick.AddListener(ButtonClicked);
        bulletAmount = bulletAmountFull;

        for (int i = 0; i < bulletAmount; i++)
        {
            GameObject b = Instantiate(bulletUi, bulletParentUi.position, Quaternion.identity);
            b.transform.parent = bulletParentUi;
        }
    }
   
    void Update()
    {
        if (bulletAmount <= 0)
        {
            StartCoroutine(CoolDown());
        }
        Debug.Log(timeStamp);
    }

    void ButtonClicked()
    {        
        if (bulletAmount > 0 && timeStamp <= Time.time)
        {
            Bullet bullet = Instantiate(bulletPrefab, gun.transform.position, Quaternion.identity);
            bullet.transform.parent = gun.transform;
            bulletAmount--;
            timeStamp = Time.time + timeBetweenShots;
        }      
    }

    IEnumerator CoolDown()
    {
        yield return new WaitForSeconds(coolDownTime);
        bulletAmount = bulletAmountFull;
    }

    void ButtonPressed()
    {

    }
}
