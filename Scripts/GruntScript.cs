using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Malo : MonoBehaviour
{
    public GameObject John;
    public GameObject BulletPrefab;

    private int Health = 3;
    private float LastShoot;

    void Update()
    {
        if (John == null) return;

        Vector3 direction = John.transform.position - transform.position;
        if (direction.x >= 0.0f) transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        else transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);

        // Aquí puedes colocar el resto de la lógica que necesitas para el método Update
    }
}
