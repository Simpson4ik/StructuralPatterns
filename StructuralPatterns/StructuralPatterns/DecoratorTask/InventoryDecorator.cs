namespace StructuralPatterns.DecoratorTask;

public abstract class InventoryDecorator : Hero
{
    protected readonly Hero _heroWrapper;

    public InventoryDecorator(Hero hero)
    {
        _heroWrapper = hero;
    }

    public override string GetDescription() => _heroWrapper.GetDescription();
    public override int GetAttack() => _heroWrapper.GetAttack();
    public override int GetDefense() => _heroWrapper.GetDefense();
}