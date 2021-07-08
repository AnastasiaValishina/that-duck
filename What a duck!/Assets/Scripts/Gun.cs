using System.Collections;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] Bullet bulletPrefab;
    [SerializeField] GameObject gun;
    [SerializeField] int bulletAmountFull = 5;
    public float coolDownTime = 4f;
    [SerializeField] float timeBetweenShots = 0.5f;

    public int bulletAmount;
    public bool coolingDown = false;

    float timeStamp;

    void Start()
    {
        bulletAmount = bulletAmountFull;
    }

    public void Shoot()
    {
        if (bulletAmount > 0 && timeStamp <= Time.time)
        {
            Bullet bullet = Instantiate(bulletPrefab, gun.transform.position, Quaternion.identity);
            bullet.transform.parent = gun.transform;
            bulletAmount--;
            GetComponent<GunUi>().UpdateText();
            timeStamp = Time.time + timeBetweenShots;

            if (bulletAmount <= 0)
            {
                StartCoroutine(CoolDown());
            }
        }
    }

    IEnumerator CoolDown()
    {
        GetComponent<GunUi>().shootButton.interactable = false;
        GetComponent<GunUi>().CoolDown();
        yield return new WaitForSeconds(coolDownTime);
        GetComponent<GunUi>().shootButton.interactable = true;
        bulletAmount = bulletAmountFull;
        GetComponent<GunUi>().UpdateText();
    }
}
