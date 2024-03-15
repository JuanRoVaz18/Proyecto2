using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GruntScript : MonoBehaviour
{
    public GameObject John;
    public GameObject BulletPrefab;

    private int Health = 2;
    private float LastShoot;
    public float shootingRange = 1.0f;
    private Game game;
    private Transform respawnPoint;

    public void Initialize(Game game)
    {
        this.game = game;
    }

    public void SetRespawnPoint(Transform point)
    {
        respawnPoint = point;
    }

    
    public void DestroyAndRespawn()
    {
        if (respawnPoint != null)
        {
            
            transform.position = respawnPoint.position;
            gameObject.SetActive(true); // Reactivar el GameObject
        }
        else
        {
            
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if (John == null) return;

        // Calcula la dirección hacia el jugador
        Vector3 direction = John.transform.position - transform.position;

        // Voltea al enemigo hacia el jugador
        if (direction.x >= 0.0f)
            transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        else
            transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);

        // Calcula la distancia al jugador
        float distance = direction.magnitude;

        // Dispara si el jugador está dentro del rango de disparo y ha pasado suficiente tiempo desde el último disparo
        if (distance < shootingRange && Time.time > LastShoot + 0.25f)
        {
            Shoot(direction.normalized);
            LastShoot = Time.time;
        }
    }

    private void Shoot(Vector3 direction)
    {
        // Instancia la bala con la dirección de disparo
        GameObject bullet = Instantiate(BulletPrefab, transform.position, Quaternion.identity);
        bullet.GetComponent<BulletScript>().SetDirection(direction);
    }

    public void Hit()
    {
        Health -= 1;
        if (Health <= 0) 
        Destroy(gameObject);
    }
}
