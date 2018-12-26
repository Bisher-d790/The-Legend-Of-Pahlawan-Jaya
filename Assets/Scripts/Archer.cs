using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archer : MonoBehaviour {

    public GameObject Arrow;
    public AudioClip ShootSFX;
    public float reloadTime = 1f;
    public float ArrowAngle = 45f;
    public float ArrowDestroyTimeout = 5;
    [Range(-1, 1)] public float xShotPower = 1;
    [Range(-1, 1)] public float yShotPower = 0;
    [Range(0,1000)]public float Power = 150;
    public float instantiatePosX = -0.5f;
    public float instantiatePosY = 0;
    public float instantiatePosZ = 0;
    [HideInInspector]public bool isShooting = false;
    bool reload = true;

    private void Update()
    {
        if (isShooting && !GetComponent<Enemy>().isStunned)
        {
            StartCoroutine(ShootArrow());
        } 
    }

    IEnumerator ShootArrow()
    {
        if (reload)
        {
            GameObject projectile = Instantiate(Arrow, transform.position + new Vector3(instantiatePosX,instantiatePosY,instantiatePosZ), transform.rotation);
            projectile.GetComponent<TimedObjectDestructor>().timeOut = ArrowDestroyTimeout;
            projectile.transform.Rotate(new Vector3(0,0,-1*ArrowAngle));
            projectile.GetComponent<Rigidbody2D>().AddForce(new Vector2(xShotPower*Power, yShotPower*Power));
            this.GetComponent<AudioSource>().PlayOneShot(ShootSFX);
            reload = false;
            yield return new WaitForSeconds(reloadTime);
            reload = true;
        }
    }

}
