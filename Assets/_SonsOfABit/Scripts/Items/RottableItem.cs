using UnityEngine;

public abstract class RottableItem : Item
{
    [SerializeField]
    private float timeToRot = 10.0f;
    private void PassTime(float time)
    {
        timeToRot -= time;
    }
    private void Rott()
    {
        itemType = EItemType.Trash;
    }
    public override void OnUpdate()
    {
        PassTime(Time.deltaTime);
    }
    public override string GetData()
    {
        return base.GetData() + $"Time to rot: {timeToRot}\n";
    }
}
