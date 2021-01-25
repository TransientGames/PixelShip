using System.Collections;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject projectile;
    public GameObject spawn;
    public float fireRate = 1f;

    void Start()
    {
        StartCoroutine(Shoot());
    }

    IEnumerator Shoot()
    {
        while (this.gameObject != null)
        {
            yield return new WaitForSeconds(fireRate);
            Instantiate(projectile, spawn.transform.position, Quaternion.identity);
        }
    }
}
