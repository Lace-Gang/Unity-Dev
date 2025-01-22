using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    [SerializeField] int ammoCount = 5;
    [SerializeField] GameObject pickipFX;

    private void OnCollisionEnter(Collision collision)
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        //if(other.CompareTag("Player"))
        {
            if(other.TryGetComponent(out PlayerTank component)) //lots of syntax sugar here
            {
                component.ammo += ammoCount;
                if(pickipFX != null) Instantiate(pickipFX, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }
    }
}
