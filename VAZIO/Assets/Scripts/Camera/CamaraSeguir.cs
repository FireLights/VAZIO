using UnityEngine;

public class CamaraSeguir : MonoBehaviour
{

    public GameObject target;
    public Vector3 offset;
    public string targetTag;

    private void Update()
    {
        target = GameObject.FindWithTag(targetTag);
        transform.position = target.transform.position + offset;

    }

}