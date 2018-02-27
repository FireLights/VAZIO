using UnityEngine;

public class CamaraSeguir : MonoBehaviour
{

    public Transform target;
    public Vector3 offset;
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
        transform.position = target.position + offset;

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