using System.Collections;
using UnityEngine;

public class RocketSpace : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 0.2f;
    public GameObject blackHole;
    private bool flying = true;
    private float movingdist = 0f;
    private float movingdist2 = 0f;
    private float suckSpeed = 1f;
    private Vector3 startScale;
    private Vector3 stretchScale;
    private Vector3 finalScale;

    private void Start()
    {
        startScale = transform.localScale;
        stretchScale = new Vector3(startScale.x * 0.001f, startScale.y * 60f, startScale.z * 0.001f);
        finalScale = new Vector3(startScale.x * 0.001f, startScale.y * 0.001f, startScale.z * 0.001f);
    }

    // Update is called once per frame
    void Update()
    {
        if (flying) {
            transform.Translate(Vector3.up * Time.deltaTime * moveSpeed);
        }
    }

    public void BlackHoleSuck()
    {
        flying = false;

        StartCoroutine(Suck());
    }

    IEnumerator Suck()
    {
        while (movingdist < 0.5f)
        {
            movingdist += Time.deltaTime * suckSpeed;
            //transform.position = Vector3.Lerp(transform.position, blackHole.transform.position, movingdist);
            transform.localScale = Vector3.Lerp(startScale, stretchScale, movingdist);
            yield return null;
        }
        while (movingdist2 < 1f)
        {
            movingdist2 += Time.deltaTime * suckSpeed;
            transform.position = Vector3.Lerp(transform.position, blackHole.transform.position, movingdist);
            transform.localScale = Vector3.Lerp(transform.localScale, finalScale, movingdist);
            yield return null;
        }
        gameObject.SetActive(false);
    }
}
