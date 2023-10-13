using UnityEngine;

public abstract class RottableItem : Item
{

    [SerializeField]
    private float timeToRot = 10.0f;
    public RottableItem(string name, float weight, EItemType itemType, Sprite itemVisual, float timeToRot): base(name, weight, itemType, itemVisual)
    {
        this.timeToRot = timeToRot;
    }
    /// <summary>
    /// A function to make the items pass time
    /// </summary>
    /// <param name="time">The time that will pass</param>
    public void PassTime(float time)
    {
        if (timeToRot > 0)
        {
            timeToRot -= time;
            return;
        }
        timeToRot = 0;
        Rott();
        
    }
    public override void OnUpdate()
    {
        PassTime(Time.deltaTime);
    }
    public override string GetData()
    {
        return base.GetData() + $"Time to rot: {Mathf.Floor(timeToRot)}\n";
    }
    /// <summary>
    /// This function defines what happens when the timne to rot value reaches 0.
    /// </summary>
    protected abstract void Rott();
}
