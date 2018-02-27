using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class ArmaDeFogo : MonoBehaviour {

    private float cooldownTimer = 0;

    //Jogador apontar arma
    public void jogadorApontarArma(float rotSpeed)
    {
        var mousePos = Input.mousePosition;
        var objectPos = Camera.main.WorldToScreenPoint(this.transform.position);
        mousePos.x = mousePos.x - objectPos.x;
        mousePos.y = mousePos.y - objectPos.y;
        var playerRotationAngle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg - 90;

        Quaternion desiredRotation = Quaternion.Euler(new Vector3(0, 0, playerRotationAngle));
        Quaternion rot = Quaternion.RotateTowards(transform.rotation, desiredRotation, rotSpeed * Time.deltaTime);
        transform.rotation = rot;
    }

    //Disparo do jogador
    public void playerFireBullet(GameObject projectilePrefab, GameObject nozzle, float fireDelay, int multishotChance)
    {
        cooldownTimer -= Time.deltaTime;

		if (Input.GetButton("Fire1") && cooldownTimer <= 0)
        {
            cooldownTimer = fireDelay;

            //Spawn do projétil
            spawnProjectile(projectilePrefab, nozzle);

            //Teste de mulishot
            Multishot(multishotChance, projectilePrefab, nozzle);
        }
    }
		

    //Disparo de um npc
    public void npcFireBullet(GameObject projectilePrefab, GameObject nozzle, float fireDelay, int multishotChance)
    {
        cooldownTimer -= Time.deltaTime;

        if (cooldownTimer <= 0)
        {
            cooldownTimer = fireDelay;

            //Spawn do projétil
            spawnProjectile(projectilePrefab, nozzle);

            //Teste de mulishot
            Multishot(multishotChance, projectilePrefab, nozzle);
        }
    }

    //Redimensionamento do projétil
    public void scaleShotSprite(GameObject projectilePrefab, float scale)
    {
        projectilePrefab.transform.localScale = new Vector2(scale, scale);
    }

	private void Multishot (int multishotChance, GameObject projectilePrefab, GameObject nozzle) 
	{
		if (Random.Range(0, 100) <= multishotChance)
		{
            spawnProjectile(projectilePrefab, nozzle);
        }
	}

	private void spawnProjectile(GameObject projectilePrefab, GameObject nozzle)
    {
        Instantiate(projectilePrefab, nozzle.transform.position, nozzle.transform.rotation);
    }

    //Definir atributos do projétil
    public void setProjectileAtributes(GameObject _obj, float _damage, int _dmgType, float _speed, float _dissipation)
    {
        _obj.GetComponent<Projetil>().setDamage(_damage);
        _obj.GetComponent<Projetil>().setDissipation(_dissipation);
        _obj.GetComponent<Projetil>().setShotSpeed(_speed);
        _obj.GetComponent<Projetil>().setDamageType(_dmgType);
    }

}
