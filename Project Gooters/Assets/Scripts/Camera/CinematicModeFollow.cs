using UnityEngine;

public class CinematicModeFollow : CinematicMode
{
    public float speed;
    public string gooseTag;
    public string mouseTag;

    private Transform _gooseActor;
    private Transform _mouseActor;

    public override void Init()
    {
        _gooseActor = GameObject.FindGameObjectWithTag(gooseTag)?.transform;
        _mouseActor = GameObject.FindGameObjectWithTag(mouseTag)?.transform;
    }

    public override void Run()
    {
        var middlePoint = (_gooseActor.position + _mouseActor.position) / 2;

        var trans = transform;
        var position = trans.position;

        var pos = position;
        pos.x = middlePoint.x;

        trans.position = Vector3.Lerp(position, pos, speed * Time.deltaTime);
    }

    public override void Terminate()
    {
    }
}