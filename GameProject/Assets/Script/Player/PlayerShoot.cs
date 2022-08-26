using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{

    [SerializeField]
    private GameObject munition;

    [SerializeField]
    [Range(1f, 6f)]
    private float cooldown = 2f;

    private bool canShoot = true;

    public Transform spawnPoint;

    public GameObject bullet;

    public float shootForce = 1500f;
    public float shootRate = 0.5f; 
    private float shootRateTime = 0;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.E))
        {
            if (canShoot)
            {
                canShoot = false;
                Shoot();
                Invoke("ResetShoot", cooldown);
            }
        }

        if (Input.GetButtonDown("Fire1"))
        {
            if(Time.time > shootRateTime && GameManager.instance.gunAmmo > 0)
            {
                GameManager.instance.gunAmmo--;

                GameObject newBullet;

                newBullet = Instantiate(bullet, spawnPoint.position, spawnPoint.rotation);

                newBullet.GetComponent<Rigidbody>().AddForce(spawnPoint.forward * shootForce);

                shootRateTime = Time.time + shootRate;

                Destroy(newBullet, 5);
            }
        }
    }

    private void Shoot()
    {
        Debug.Log("DISPARAR");
        Instantiate(munition, transform.position, transform.rotation);
    }

    private void ResetShoot()
    {
        canShoot = true;
    }
}
