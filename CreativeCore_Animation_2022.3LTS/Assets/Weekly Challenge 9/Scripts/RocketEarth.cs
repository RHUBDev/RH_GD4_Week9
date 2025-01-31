using UnityEngine;

public class RocketEarth : MonoBehaviour
{
    private bool blastingOff = false;
    private float moveSpeed = 5;
    [SerializeField] private float moveForce = 500;
    public Rigidbody rig;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (blastingOff)
        {
            //transform.Translate(Vector3.up * Time.deltaTime * moveSpeed);
            rig.AddForce(Vector3.up * moveForce);
        }
    }

    public void BlastOff()
    {
        blastingOff = true;
    }
}
