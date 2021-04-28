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

    [Header("UI")]
    [SerializeField] Transform bulletParentUi;
    [SerializeField] GameObject bulletUi;

    Button shootButton;
    int bulletAmount;
    public List<GameObject> bulletList = new List<GameObject>();

    void Start()
    {
        shootButton = GetComponent<Button>();
        shootButton.onClick.AddListener(ButtonClicked);
        bulletAmount = bulletAmountFull;

        for (int i = 0; i < bulletAmount; i++)
        {
            GameObject b = Instantiate(bulletUi, bulletParentUi.position, Quaternion.identity);
            b.transform.parent = bulletParentUi;
            bulletList.Add(b);
        }
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
        if (bulletAmount > 0)
        {
            Bullet bullet = Instantiate(bulletPrefab, gun.transform.position, Quaternion.identity);
            bullet.transform.parent = gun.transform;
            bulletAmount--;
//            bulletList.Remove(gameObject);
        }      
    }

    IEnumerator CoolDown()
    {
        yield return new WaitForSeconds(coolDownTime);
        bulletAmount = bulletAmountFull;
    }
}
