using UnityEngine;

public class Destructable : MonoBehaviour, IDamageable
{
    [SerializeField] float health;
    [SerializeField] GameObject destroyFX;

    bool destroyed = false;

    //property rather than a function
    public float Health { get { return health; } set { health = (value < 0) ? 0 : value; } } //health can't be less than 0

    public void ApplyDamage(float damage)
    {
        if (destroyed) return;

        health -= damage;
        if(health < 0)
        {
            destroyed = true;
            if(destroyFX != null) Instantiate(destroyFX, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
