using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projetil : MonoBehaviour {

    //atributos do projétil
    public float speed;
    public float dissipation;
    public float damage;

    public int dmgType;

    private float shotDissipation;


    private void Start()
    {
        
        shotDissipation = UnityEngine.Random.Range(-dissipation, dissipation);
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        Vector3 velocity = new Vector3(shotDissipation, speed * Time.deltaTime, 0);
        pos += transform.rotation * velocity;
        transform.position = pos;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(this.gameObject);
    }

    public void setDissipation(float _dissipation) { dissipation = _dissipation; }

    public float getDissipation() { return dissipation; }

    public void setShotSpeed(float _speed) { speed = _speed; }

    public float getShotSpeed() { return speed; }

    public void setDamage(float _damage) { damage = _damage; }

    public float getDamage() { return damage; }

    public void setDamageType(int _dmgType) { dmgType = _dmgType; }

    public int getDamageType() { return dmgType; }
}
