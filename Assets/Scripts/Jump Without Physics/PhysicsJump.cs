using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsJump : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private SurfaceSlider _surfaceSlider;
    [SerializeField] private JumpFX _fx;
    [SerializeField] private float _lenght;
    [SerializeField] private float _duration;

    private PureAnimation _playtime;

    private void Awake()
    {
        _playtime = new PureAnimation(this);
    }

    public void Jump(Vector3 direction)
    {
        Vector3 target = transform.position + (direction * _lenght);
        Vector3 startPosition = transform.position;
        PureAnimation fxPlaytime = _fx.PlayAnimation(transform, _duration);

        _playtime.Play(_duration, (progress) =>
        {
            transform.position = Vector3.Lerp(startPosition, target, progress) + fxPlaytime.LastChanges.Position;
            transform.localScale = fxPlaytime.LastChanges.Scale;
            return null;
        });
    }
}
