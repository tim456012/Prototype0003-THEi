using System.Collections;
using UnityEngine;

public class BaseShake : MonoBehaviour
{
    public GameObject GameObjectToShake;
    private bool shaking;

    //loop - döngü
    private void FixedUpdate()
    {
        shakeGameObject(GameObjectToShake, 5, 3f);
    }

    private void shakeGameObject(GameObject objectToShake, float shakeDuration, float decreasePoint, bool objectIs2D = false)
    {

        shaking = true;
        StartCoroutine(shakeGameObjectCOR(objectToShake, shakeDuration, decreasePoint, objectIs2D));
    }
    
    private IEnumerator shakeGameObjectCOR(GameObject objectToShake, float totalShakeDuration, float decreasePoint, bool objectIs2D = false)
    {
        if (decreasePoint >= totalShakeDuration)
        {
            Debug.LogError("decreasePoint must be less than totalShakeDuration...Exiting");
            yield break; //Exit!
        }
        var objTransform = objectToShake.transform;
        var defaultPos = objTransform.position;
        var defaultRot = objTransform.rotation;

        float counter = 0f;

        //shake speef - sallama hızı
        const float speed = 0.03f;

        //rotation - rotasyon
        const float angleRot = 0.1f;


        while (counter < totalShakeDuration)
        {
            counter += Time.deltaTime;
            float decreaseSpeed = speed;


            //objeyi salla

            {
                objTransform.position = defaultPos + Random.insideUnitSphere * decreaseSpeed;
                objTransform.rotation = defaultRot * Quaternion.AngleAxis(Random.Range(-angleRot, angleRot), new Vector3(1f, 1f, 1f));
            }
            yield return null;



        }
    }
}
