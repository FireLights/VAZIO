using UnityEngine;

public class CamaraSeguir : MonoBehaviour
{

    public Transform target;
    public float smoothSpeed = 0.3f;
    public Vector3 offset;
    public Vector3 velocity = Vector2.one;
    public string targetTag;

    public MovimentoJogador mj;

    private void Start()
    {
        findPlayer();
        mj = target.GetComponent<MovimentoJogador>();
    }

    private void Update()
    {
        findPlayer();
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            smoothSpeed = smoothSpeed / mj.turboMultiplier / 1.2f;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            smoothSpeed = smoothSpeed * mj.turboMultiplier / 1.2f;
        }
    }

    void LateUpdate()
    {

        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, smoothSpeed);

        transform.position = smoothedPosition;
    }

    private void findPlayer()
    {
        if (target == null)
        {
            GameObject go = GameObject.FindWithTag(targetTag);
            if (go != null)
            {
                target = go.transform;
            }
        }
        if (target == null) return;
    }

}