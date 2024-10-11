using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]GameObject[] bulletPrefabs;
    [SerializeField] private float spawnRate = 2f;
    [SerializeField] private bool canSpawn = true;
    float bulletSpeed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(autoSpawn());
    }

    private IEnumerator autoSpawn()
    {
        while(canSpawn)
        {
            yield return new WaitForSeconds(spawnRate);
            int rand = Random.Range(0, bulletPrefabs.Length);
            Spawn(rand);
            yield return new WaitForSeconds(spawnRate);
        }
    }
    void Spawn(int index)
    {
        Debug.Log("Spawn");
        Vector3 randomSpawnPosition = new Vector3(Random.Range(-5,5), this.transform.position.y,this.transform.position.z);
        GameObject bullet = Instantiate(bulletPrefabs[index], randomSpawnPosition, Quaternion.identity);

        // Obtenemos el Rigidbody2D de la instancia de la bala
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        // Aplicamos la fuerza para mover la bala
        rb.AddForce(transform.up * bulletSpeed, ForceMode2D.Impulse); // Usamos el modo de impulso para darle velocidad instantánea
    }
}
    
