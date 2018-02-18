using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotatetowardscam : MonoBehaviour {

    public Transform player;

    private void Start()
    {
        player = GetComponent<Transform>();
    }

    private void FixedUpdate()
    {
        var mousePos = Input.mousePosition;
        var objectPos = Camera.main.WorldToScreenPoint(player.position);
        mousePos.x = mousePos.x - objectPos.x;
        mousePos.y = mousePos.y - objectPos.y;
        var playerRotationAngle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg - 90;

        Quaternion desiredRotation = Quaternion.Euler(new Vector3(0, 0, playerRotationAngle));
        transform.rotation = Quaternion.RotateTowards(transform.rotation, desiredRotation, 270 * Time.deltaTime);
    }
}
