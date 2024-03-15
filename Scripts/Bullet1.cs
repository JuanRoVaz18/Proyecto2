using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet1 : MonoBehaviour
{
    public float Speed;
    public AudioClip Sound;

    private Rigidbody2D Rigidbody2D;
    private Vector3 Direction;

    private void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        Camera.main.GetComponent<AudioSource>().PlayOneShot(Sound);
    }

    private void FixedUpdate()
    {
        Rigidbody2D.velocity = Direction * Speed;
    }

    public void SetDirection(Vector3 direction)
    {
        Direction = direction;
    }

    public void DestroyBullet()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision1)
    {
        // Verificar si la colisión es con el jugador
        GruntScript grunt = collision1.GetComponent<GruntScript>();
        if (grunt != null)
        {
        // Si la colisión es con un enemigo, hacer daño al enemigo y destruir la bala
        grunt.Hit();
        DestroyBullet();
        return; // Salir del método para evitar hacer daño al jugador también
    }
    }
}
