using UnityEngine;
using UnityEngine.Playables;

public class LoseChangeGuy : MonoBehaviour
{
    public Animator anim;
    public PlayableDirector director;
    private bool stunned = false;
    public CharacterController cont;
    private float fallSpeed = 0.8f;
    private float pushSpeed = 2f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (director.time > 25.08f && !stunned)//25.28f && !stunned)
        {
            stunned = true;
            anim.SetTrigger("DoStunned");
        }
        if (stunned && cont.center.y < 1.9f)
        {
            cont.Move(Vector3.up * Time.deltaTime * Physics.gravity.y * 1.5f + Vector3.forward * Time.deltaTime * pushSpeed);
            cont.center = new Vector3(cont.center.x, cont.center.y + Time.deltaTime * fallSpeed, cont.center.z);
        }
        else if (stunned)
        {
            cont.center = new Vector3(cont.center.x, 1.9f, cont.center.z);
        }
    }
}
