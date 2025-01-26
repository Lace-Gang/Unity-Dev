using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    [SerializeField] int healthCount = 5;
    [SerializeField] GameObject pickipFX;

    GameObject effect;

    private void OnCollisionEnter(Collision collision)
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        //if(other.CompareTag("Player"))
        {
            print("trigger");
            if (other.TryGetComponent(out PlayerTank component)) //lots of syntax sugar here
            {
                if(other.TryGetComponent(out Destructable destComp))
                {
                    destComp.HealDamage(healthCount);
                }
                component.health += healthCount;
                if (pickipFX != null) Instantiate(pickipFX, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }
    }
}
