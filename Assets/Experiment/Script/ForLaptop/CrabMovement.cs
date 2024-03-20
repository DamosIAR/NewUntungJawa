using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrabMovement : MonoBehaviour
{
    public float moveSpeed = 3f; // Kecepatan pergerakan NPC
    public float changeDirectionInterval = 2f; // Interval perubahan arah pergerakan

    private float timer; // Timer untuk interval perubahan arah pergerakan
    private Vector3 randomDirection; // Arah pergerakan acak

    // Dipanggil sekali saat objek diaktifkan
    void Start()
    {
        // Mulai dengan arah pergerakan acak pertama
        ChangeRandomDirection();
    }

    // Update dipanggil setiap frame
    void Update()
    {
        // Pergerakkan NPC
        MoveNPC();

        // Update timer
        timer += Time.deltaTime;

        // Jika waktu interval tercapai, ubah arah pergerakan
        if (timer >= changeDirectionInterval)
        {
            ChangeRandomDirection();
            timer = 0f;
        }
        
    }

    // Fungsi untuk menggerakkan NPC
    void MoveNPC()
    {
        // Gerakkan NPC ke arah randomDirection dengan kecepatan moveSpeed
        transform.Translate(randomDirection * moveSpeed * Time.deltaTime);
        
    }

    // Fungsi untuk mengubah arah pergerakan acak NPC
    void ChangeRandomDirection()
    {
        // Pilih arah acak dalam rentang (-1, 1) untuk x, y, dan z
        randomDirection = new Vector3(Random.Range(-1f, 1f), 0f, Random.Range(-1f, 1f)).normalized;
    }
    
}
