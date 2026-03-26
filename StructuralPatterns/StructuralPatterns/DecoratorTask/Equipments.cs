namespace StructuralPatterns.DecoratorTask;

public class Weapon : InventoryDecorator
{
    private readonly string _weaponName;
    private readonly int _attackBonus;

    public Weapon(Hero hero, string weaponName, int attackBonus) : base(hero)
    {
        _weaponName = weaponName;
        _attackBonus = attackBonus;
    }

    public override string GetDescription() => $"{base.GetDescription()} + Зброя: [{_weaponName}]";
    public override int GetAttack() => base.GetAttack() + _attackBonus;
    public override int GetDefense() => base.GetDefense();
}
public class Clothing : InventoryDecorator
{
    private readonly string _clothingName;
    private readonly int _defenseBonus;

    public Clothing(Hero hero, string clothingName, int defenseBonus) : base(hero)
    {
        _clothingName = clothingName;
        _defenseBonus = defenseBonus;
    }

    public override string GetDescription() => $"{base.GetDescription()} + Одяг: [{_clothingName}]";
    public override int GetAttack() => base.GetAttack();
    public override int GetDefense() => base.GetDefense() + _defenseBonus;
}

public class Artifact : InventoryDecorator
{
    private readonly string _artifactName;
    private readonly int _magicBonus;

    public Artifact(Hero hero, string artifactName, int magicBonus) : base(hero)
    {
        _artifactName = artifactName;
        _magicBonus = magicBonus;
    }

    public override string GetDescription() => $"{base.GetDescription()} + Артефакт: [{_artifactName}]";
    public override int GetAttack() => base.GetAttack() + _magicBonus;
    public override int GetDefense() => base.GetDefense() + _magicBonus;
}