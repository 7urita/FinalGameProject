using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private PlayerData playerData;
    private PlayerMoveForce playerMove;

    private void Start()
    {
        playerData = GetComponent<PlayerData>();
        playerMove = GetComponent<PlayerMoveForce>();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Powerups"))
        {
            Destroy(other.gameObject);
            playerData.Healing(other.gameObject.GetComponent<MedBox>().HealPoints);

            GameManager.Score++;
            Debug.Log(GameManager.Score);
        }

        if (other.gameObject.CompareTag("Munitions"))
        {
            Debug.Log("ENTRANDO EN COLISION CON " + other.gameObject.name);
            playerData.Damage(other.gameObject.GetComponent<Munition>().DamagePoints);
            Destroy(other.gameObject);
            if (playerData.HP <= 0)
            {
                Debug.Log("GAME OVER");
            }

            GameManager.Score--;
            Debug.Log(GameManager.Score);
        }

        if (other.gameObject.CompareTag("Floor"))
        {
            playerMove.CanJump = true;
        }
    }

    private void OnCollisionExit(Collision other)
    {
    }

    private void OnCollisionStay(Collision other)
    {
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Trampoline"))
        {
            /*
             Cambio de velocidad instantáneo (ForceMode.VelocityChange)
             Aqui la fuerza se traduce en un cambio de velocidad,
             por lo cual el movimiento se altera significantemente.
             El cálculo Vector3.up + Vector3.forward permite al
             aplicar fuerza en "diagonal"(hacia arriba y adelante)
            */
            //forward,back,righ,left,up,down//
            playerMove.MyRigidbody.AddForce((Vector3.up) * playerMove.MaxSpeed * 2f, ForceMode.VelocityChange);
        }

        if (other.gameObject.CompareTag("GunAmmo"))
        {
            GameManager.instance.gunAmmo += other.gameObject.GetComponent<AmmoBox>().ammo;

            Destroy(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {

    }

    private void OnTriggerStay(Collider other)
    {

    }
}
