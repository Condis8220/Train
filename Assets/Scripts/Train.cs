using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Train : Singleton<Train>
{
    public float minSpeed = 0;
    public float maxSpeed = 10;
    public float accelerate = 10;
    public float speedRotate = 10;

    public float Speed { get; private set; } = 10;

    [Space]
    public Slider sliderAccelerate;
    private Coroutine coroutineChangeSpeed;

    private void Start()
    {
        sliderAccelerate.onValueChanged.AddListener(ChangeAccelerate);

        Speed = minSpeed;

        StartCoroutine(Move());
    }

    public IEnumerator Move()
    {
        while (true)
        {
            Vector3 nextPoint = WayPointsController.Instance.GetNextPoint();

            Quaternion targetRotation = Quaternion.LookRotation(nextPoint - transform.position);

            while (transform.position != nextPoint)
            {
                transform.position = Vector3.MoveTowards(transform.position, nextPoint, Time.deltaTime * Speed);

                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, speedRotate * Time.deltaTime);

                yield return null;
            }
        }
    }

    private void ChangeAccelerate(float _value)
    {
        if (coroutineChangeSpeed != null)
            StopCoroutine(coroutineChangeSpeed);

        coroutineChangeSpeed = StartCoroutine(ChangeSpeedValue(_value == 0 ? minSpeed : maxSpeed));
    }

    private IEnumerator ChangeSpeedValue(float _targetSpeed)
    {
        while (Speed != _targetSpeed)
        {
            Speed = Mathf.MoveTowards(Speed, _targetSpeed, Time.deltaTime * accelerate);
            yield return null;
        }
    }
}
