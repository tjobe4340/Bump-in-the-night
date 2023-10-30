using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomBoxSpawner : MonoBehaviour
{
    [SerializeField] GameObject boxPrefab;

    void Start(){
        SpawnBoxesOverTime();
    }

    void SpawnBoxesOverTime(){
        StartCoroutine(SpawnBoxesOverTimerRoutine());

        IEnumerator SpawnBoxesOverTimerRoutine(){
            Camera mainCamera = Camera.main;
            float cameraHeight = 2f * mainCamera.orthographicSize;
            float cameraWidth = cameraHeight * mainCamera.aspect;

            Vector3 cameraCenter = mainCamera.transform.position;
            Vector3 cameraMin = cameraCenter - new Vector3(cameraWidth / 2, cameraHeight / 2, 0);
            Vector3 cameraMax = cameraCenter + new Vector3(cameraWidth / 2, cameraHeight / 2, 0);
            while(true){
                yield return new WaitForSeconds(0.5f);
                Vector3 spawnPosition = new Vector3(Random.Range(cameraMin.x, cameraMax.x),Random.Range(cameraMax.y, cameraMax.y+2f),0);
                GameObject newBox = Instantiate(boxPrefab, spawnPosition, Quaternion.identity);
                Destroy(newBox,10);
            }

            yield return null;
            // yield return new WaitForSeconds(2);
            // Instantiate(boxPrefab,Vector3.zero,Quaternion.identity);

            // yield return new WaitForSeconds(2);
            // Instantiate(boxPrefab,new Vector3(0,2,0),Quaternion.identity);

            // yield return null;//waits for a single frame
            //yield return new WaitForFixedUpdate();//waits for physic update
        }
    }
    
}
