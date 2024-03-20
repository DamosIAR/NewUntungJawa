using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrabSpawner : MonoBehaviour
{
    public GameObject objectToSpawn; // Objek yang ingin di-spawn
    public Vector3 spawnAreaCenter; // Pusat area spawn
    public Vector3 spawnAreaSize; // Ukuran area spawn
    public float spawnInterval = 2f; // Interval waktu antar spawn dalam detik
    public float crabLifetime = 5f;
    public float speed;

    private float timeSinceLastSpawn; // Waktu sejak spawn terakhir

    void Start()
    {
        // Inisialisasi waktu
        timeSinceLastSpawn = spawnInterval;
    }

    void Update()
    {
        spawnAreaCenter = new Vector3 (spawnAreaCenter.x, spawnAreaCenter.y, spawnAreaCenter.z);
        spawnAreaCenter.z += speed;
        //transform.position = (spawnAreaCenter * speed);

        // Perbarui waktu sejak spawn terakhir
        timeSinceLastSpawn += Time.deltaTime;

        // Cek apakah sudah waktunya untuk spawn objek baru
        if (timeSinceLastSpawn >= spawnInterval)
        {
            SpawnObject();
            timeSinceLastSpawn = 0;
        }
    }

    void SpawnObject()
    {
        // Hitung posisi spawn random di dalam area yang ditentukan
        Vector3 spawnPosition = new Vector3(
            Random.Range(spawnAreaCenter.x - spawnAreaSize.x / 2, spawnAreaCenter.x + spawnAreaSize.x / 2),
            Random.Range(spawnAreaCenter.y - spawnAreaSize.y / 2, spawnAreaCenter.y + spawnAreaSize.y / 2),
            Random.Range(spawnAreaCenter.z - spawnAreaSize.z / 2, spawnAreaCenter.z + spawnAreaSize.z / 2)
        );

        // Instansiasi objek baru di posisi spawn yang telah diacak
        GameObject spawnedCrab =  Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);

        Destroy(spawnedCrab, crabLifetime);
    }

    // Menampilkan area spawn di dalam scene editor untuk referensi
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawWireCube(spawnAreaCenter, spawnAreaSize);
    }
}
