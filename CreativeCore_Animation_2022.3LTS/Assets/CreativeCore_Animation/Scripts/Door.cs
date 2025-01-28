using UnityEngine;
using TMPro;

public class Door : MonoBehaviour
{
    public GameObject player;
    public Animator anim;
    public TMP_Text doorhint;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ((player.transform.position - transform.position).magnitude < 3)
        {
            doorhint.text = "Press 'E' to activate door";
            if (Input.GetKeyDown(KeyCode.E))
            {
                anim.SetBool("isOpen", !anim.GetBool("isOpen"));
            }
        }
        else
        {
            doorhint.text = "";
        }
    }
}
