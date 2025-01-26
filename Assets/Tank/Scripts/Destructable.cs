using UnityEngine;

public class Destructable : MonoBehaviour, IDamageable
{
    [SerializeField] float health;
    [SerializeField] int points;
    [SerializeField] GameObject destroyFX;
    [SerializeField] bool cannotBeRemoved = false;

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
            GameManager.Instance.increaseScore(points);
            if(!cannotBeRemoved) Destroy(gameObject);
        }
    }
}
