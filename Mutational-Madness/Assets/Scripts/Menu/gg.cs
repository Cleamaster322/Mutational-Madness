using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gg : MonoBehaviour
{
    //for MainHero in bubbles swimming in the menu scene
    public float speed = 0.1f;
    public float startY = 350.0f;
    public float endY = 490.0f;
    public GameObject prefab;
    public float areaWidth = 1050.0f;
    public float areaHeight = 900.0f;

    void Update()
    {
        if (Time.time % 1 < 0.003f)
        {
            SpawnBubbbles();
        }
        // PingPong между 0 и 1
        float time = Mathf.PingPong(Time.time * speed, 1);
        float currentY = Mathf.Lerp(startY, endY, time);
        transform.position = new Vector3(transform.position.x, currentY, transform.position.z);
    }
    void SpawnBubbbles()
    {
        float x = Random.Range(-areaWidth *0.00001f+34, areaWidth / 2);
        float y = Random.Range(-areaHeight *0.00001f+100, areaHeight / 2);
        Vector3 spawnPosition = new Vector3(x, y, 0);
        GameObject spawnedObject = Instantiate(prefab, spawnPosition, Quaternion.identity);
        spawnedObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 0.01f), ForceMode2D.Impulse);
        Destroy(spawnedObject, 3.0f);
    }

}
