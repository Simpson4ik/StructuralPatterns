namespace StructuralPatterns.DecoratorTask;

public class Warrior : Hero
{
    public override string GetDescription() => "Базовий Воїн";
    public override int GetAttack() => 15;
    public override int GetDefense() => 20;
}

public class Mage : Hero
{
    public override string GetDescription() => "Базовий Маг";
    public override int GetAttack() => 25;
    public override int GetDefense() => 5;
}

public class Palladin : Hero
{
    public override string GetDescription() => "Базовий Паладин";
    public override int GetAttack() => 18;
    public override int GetDefense() => 18;
}