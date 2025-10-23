using Microsoft.VisualBasic.CompilerServices;

namespace phonetest.code.building;

using Godot;
public abstract partial class Construction : StaticBody2D
{
    [Export] private float Hp    = int.MaxValue;
    [Export] private float MaxHp = int.MaxValue;

    public override void _Ready()
    {
        Hp = MaxHp;
    }

    public virtual void takeDamage(float damage)
    {
        Hp -= damage;
        if (Hp <= 0) QueueFree();
    }
}