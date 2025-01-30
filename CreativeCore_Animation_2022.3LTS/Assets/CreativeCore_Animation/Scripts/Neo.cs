using System.Collections;
using UnityEngine;
using UnityEngine.Playables;

public class Neo : MonoBehaviour
{
    public CharacterController cont;
    public Animator anim;
    private float walkSpeed = 1.7f;
    private float walkSpeed2 = 2f;
    private float walkAccel = 2f;
    private int animPhase = 0;
    private float animSpeed = 0f;
    private float walkPositionZ = -15.8f;
    private float walkPositionZ2 = -12.5f;
    public PlayableDirector director;
    private bool punched = false;
    private bool endedPunch = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(MoveInBuilding());
    }

    // Update is called once per frame
    void Update()
    {
        if (animPhase == 1)
        {
            if (cont.transform.position.z < walkPositionZ)
            {
                if (animSpeed < walkSpeed)
                {
                    animSpeed += Time.deltaTime * walkAccel;
                }
                else
                {
                    animSpeed = walkSpeed;
                }
            }
            else if (cont.transform.position.z >= walkPositionZ)
            {
                if (animSpeed > 0f)
                {
                    animSpeed -= Time.deltaTime * walkAccel;
                }
                else
                {
                    animSpeed = 0f;
                    animPhase = 2;
                }
            }
            anim.SetFloat("Speed", animSpeed);
            cont.Move(Vector3.forward * Time.deltaTime * animSpeed);
        }
        else if (director.time > 24.3f)//24.5f)
        {
            if (cont.transform.position.z < walkPositionZ2)
            {
                cont.Move(Vector3.forward * Time.deltaTime * walkSpeed2);
            }
            if (!punched)
            {
                transform.Rotate(Vector3.up * -40f);
                punched = true;
                anim.SetTrigger("DoPunch");
            }
        }
        if (director.time > 25.0f && director.time < 26.1f)//+0.2
        {
            if (director.time > 25.2f)//+0.2
            {
                anim.speed = 0;
                Time.timeScale = 0.2f;
            }
            //anim.SetFloat("MotionSpeed", 0);
        }
        else if (director.time >= 26.2f)//+0.2
        {
            if (!endedPunch)
            {
                endedPunch = true;
                anim.speed = 1;
                //anim.SetFloat("MotionSpeed", 1);
                Time.timeScale = 1f;
                transform.Rotate(Vector3.up * 40f);
            }
        }
        if(director.time > 27)
        {
            director.Stop();
        }
    }

    IEnumerator MoveInBuilding()
    {
        yield return new WaitForSeconds(3);
        animPhase = 1;
    }
}
