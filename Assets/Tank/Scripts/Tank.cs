using UnityEngine;

public class Tank : MonoBehaviour
{
    [SerializeField] float turnRate = 90.0f; //serialize field keeps the variable private but it can still be seen in the editor
    [SerializeField] float maxSpeed = 1.0f; 
    [SerializeField] GameObject rocket; 

    void Start()
    {
        
    }

    void Update()
    {
        float rotation = Input.GetAxis("Horizontal");
        float speed = Input.GetAxis("Vertical");

        //transform has a shortcut rather than having to get component
        transform.rotation *= Quaternion.AngleAxis(rotation * turnRate * Time.deltaTime , Vector3.up);
        //transform.position += transform.rotation * Vector3.forward * speed * maxSpeed * Time.deltaTime;
        transform.Translate(Vector3.forward * speed * maxSpeed * Time.deltaTime);

        if(Input.GetMouseButtonDown(0))
        {
            Instantiate(rocket, transform.position + Vector3.up, transform.rotation);
        }
    }
}
