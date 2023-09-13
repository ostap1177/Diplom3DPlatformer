using UnityEngine;

public class TransfomChanges
{
    private Vector3 position;
    private Vector3 scale;

    public TransfomChanges(Vector3 position, Vector3 scale)
    {
        this.position = position;
        this.scale = scale;
    }

    public Vector3 Position { get; private set; }
    public Vector3 Scale { get; private set; }
}