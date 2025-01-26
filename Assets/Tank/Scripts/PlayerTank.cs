using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class PlayerTank : MonoBehaviour
{
    [SerializeField] float maxTorque = 90.0f; //serialize field keeps the variable private but it can still be seen in the editor
    [SerializeField] float maxForce = 90.0f;
    [SerializeField] Transform barrel;
    [SerializeField] GameObject rocket;
    public int ammo = 10; //public so that ammo pickups will work
    public float health = 10;
    [SerializeField] TMP_Text ammoText;
    //[SerializeField] TMP_Text healthText;
    [SerializeField] UnityEngine.UI.Slider healthSlider;

    float torque;
    float force;
    Vector3 turn = Vector3.zero;
   

    Rigidbody rb;
    Destructable destructable;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        destructable = GetComponent<Destructable>();
        GetComponent<Rigidbody>().maxLinearVelocity = 5;
        GetComponent<Rigidbody>().maxAngularVelocity = 1;
    }

    void Update()
    {
        torque = Input.GetAxis("Horizontal") * maxTorque;
        force = Input.GetAxis("Vertical") * maxForce;
        turn.Set(0, torque - force, 0);



        if (Input.GetButtonDown("Fire1") && ammo >0)
        {
            ammo--;
            Instantiate(rocket, barrel.position, barrel.rotation);
        }

        if (Input.GetKey(KeyCode.A) && force == 0)
        {
            GetComponent<Rigidbody>().angularVelocity = turn;
        }

        if(Input.GetKey(KeyCode.D) && force == 0)
        {
            GetComponent<Rigidbody>().angularVelocity = turn;
        }

        ammoText.text = "Ammo: " + ammo.ToString();
        //healthText.text = "Health: " + health.ToString();
        healthSlider.value = destructable.Health;

        if(destructable.Health <= 0)
        {
            //print("working");
            GameManager.Instance.SetGameOver(); //singleton means we did not have to hold this anywhere
            //we can just get the instance itself
        }
    }


    private void FixedUpdate()
    {
        //delta time is already being accounted for in this method
        rb.AddRelativeForce(Vector3.forward * force);
        rb.AddRelativeTorque(Vector3.up * torque);
    }
}
