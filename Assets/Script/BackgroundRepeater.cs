using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundRepeater : MonoBehaviour
{
    public List<GameObject> backgrounds; // List untuk menyimpan background
    public Transform player; // Referensi ke transform pemain
    public float backgroundWidth; // Lebar setiap background

    private float leftBoundary;
    private float rightBoundary;

    void Start()
    {
        if (backgrounds.Count < 3)
        {
            Debug.LogError("Harus ada minimal 3 background untuk repeating.");
            return;
        }

        // Mengatur batas kiri dan kanan berdasarkan posisi background

    }

    void Update()
    {
        leftBoundary = backgrounds[0].transform.position.x;
        rightBoundary = backgrounds[backgrounds.Count - 1].transform.position.x;
        // Jika pemain bergerak ke kanan dan melewati background kanan
        if (player.position.x > rightBoundary - backgroundWidth)
        {
            ShiftBackground(Vector3.right);
        }
        // Jika pemain bergerak ke kiri dan melewati background kiri
        else if (player.position.x < leftBoundary + backgroundWidth)
        {
            ShiftBackground(Vector3.left);
        }
    }

    void ShiftBackground(Vector3 direction)
    {
        if (direction == Vector3.right)
        {
            // Ambil background paling kiri
            GameObject leftBg = backgrounds[0];
            // Pindahkan ke kanan
            leftBg.transform.position += new Vector3(backgroundWidth * backgrounds.Count, 0, 0);
            // Update batas
            leftBoundary = leftBg.transform.position.x;
            // Reorder list
            backgrounds.RemoveAt(0);
            backgrounds.Add(leftBg);
        }
        else if (direction == Vector3.left)
        {
            // Ambil background paling kanan
            GameObject rightBg = backgrounds[backgrounds.Count - 1];
            // Pindahkan ke kiri
            rightBg.transform.position -= new Vector3(backgroundWidth * backgrounds.Count, 0, 0);
            // Update batas
            rightBoundary = rightBg.transform.position.x;
            // Reorder list
            backgrounds.RemoveAt(backgrounds.Count - 1);
            backgrounds.Insert(0, rightBg);
        }
    }
}
