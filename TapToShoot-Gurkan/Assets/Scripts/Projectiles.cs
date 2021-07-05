using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectiles : MonoBehaviour
{

    public int projectileSpeed;

    private bool fired;

    private Vector3 destVec3;


    private void Update()
    {
        if (fired)
        {
            transform.position = Vector3.MoveTowards(transform.position, destVec3, Time.deltaTime * projectileSpeed);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        ProjectileCollision(other);
    }


    private void ProjectileCollision(Collider other)
    {
        if (other.gameObject.tag == "ColorBlock")
        {
            other.transform.parent.GetComponent<BlockScript>().AddingForceAfterImpact();

            FindObjectOfType<SceneManager>().ChangeBlocksColor();

            Destroy(this.gameObject);
        }

        if(other.gameObject.tag == "Block")
        {
            Destroy(this.gameObject);
        }
    }


    public void ProjectileFire(Transform bulletDestination)
    {
        destVec3 = bulletDestination.position;

        this.transform.LookAt(bulletDestination);

        fired = true;
    }

}
