using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpFX : MonoBehaviour
{
    [SerializeField] private AnimationCurve _yAnimation;
    [SerializeField] private AnimationCurve _scaleAnimation;
    [SerializeField] private float _height;
    [SerializeField] private PureAnimation _playtime;

    private void Awake()
    {
        _playtime = new PureAnimation(this);
    }

    public PureAnimation PlayAnimation(Transform jumper, float duration)
    {
        _playtime.Play(duration, (float prodress) =>
         {
             Vector3 position = Vector3.Scale(new Vector3(0, _height * _yAnimation.Evaluate(prodress), 0), jumper.up);
             Vector3 scale = Vector3.one * _scaleAnimation.Evaluate(prodress);
             Debug.Log("Scale " + scale);
             Debug.Log(_scaleAnimation.Evaluate(prodress));

             return new TransfomChanges(position, scale);
         });

        return _playtime;
    }
}
