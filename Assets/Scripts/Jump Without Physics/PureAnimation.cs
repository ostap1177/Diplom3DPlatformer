using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PureAnimation 
{
    public TransfomChanges LastChanges { get; private set; }

    private Coroutine _lastAnimation;
    private MonoBehaviour _context;

    public PureAnimation(MonoBehaviour context)
    {
        _context = context;
    }

    public void Play(float duration, Func<float, TransfomChanges> body)
    {
        if (_lastAnimation != null)
        {
            _context.StopCoroutine(_lastAnimation);
        }

        _lastAnimation = _context.StartCoroutine(GetAnimation(duration,body));
    }

    private IEnumerator GetAnimation(float duration, Func<float, TransfomChanges> body)
    {
        float expiredSecond = 0;
        float progress = 0;

        while (progress < 1)
        {
            expiredSecond += Time.deltaTime;
            progress = expiredSecond / duration;

            LastChanges = body.Invoke(progress);

            yield return null;
        }
    }
}
