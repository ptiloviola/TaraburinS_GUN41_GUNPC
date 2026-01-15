using Classes;

class Program
{
    static void Main(string[] args)
    {

        var unit = new Unit("Vasya");
        Console.WriteLine(unit.Name);
        Console.WriteLine(unit.Armor);
        Console.WriteLine(unit.Damage);
        Console.WriteLine(unit.Health);
        Console.WriteLine(unit.GetRealHealth());
        Console.WriteLine(unit.SetDamage(550));

        Console.WriteLine("-------------------------");

        var weapon = new Weapon("Sword", 0, 1);
        Console.WriteLine(weapon.Name);
        Console.WriteLine(weapon.MinDamage);
        Console.WriteLine(weapon.MaxDamage);
        Console.WriteLine(weapon.GetDamage());

        Console.WriteLine("-------------------------");

        Console.WriteLine("Enter unit name");
        var unitName = Console.ReadLine();

        Console.WriteLine("Enter damage value");

        int damageValue = ReadIntValue();

        var customUnit = new Unit(unitName);

        Console.WriteLine("Unit name = {0}. Armor = {1}. Damage = {2}. Health = {3}. Real health = {4}. Dead = {5}", customUnit.Name, customUnit.Armor, customUnit.Damage, customUnit.Health, customUnit.GetRealHealth(), customUnit.SetDamage(damageValue));

        Console.WriteLine("-------------------------");

        Console.WriteLine("Enter weapon name");

        var weaponName = Console.ReadLine();

        Console.WriteLine("Enter min damage");

        int minDamage = ReadIntValue();

        Console.WriteLine("Enter max damage");

        int maxDamage = ReadIntValue();

        var customWeapon = new Weapon(weaponName, minDamage, maxDamage);
        Console.WriteLine("Weapon name = {0}. MinDamage = {1}. MaxDamage = {2}. Average damage = {3}. Durability = {4}", customWeapon.Name, customWeapon.MinDamage, customWeapon.MaxDamage, customWeapon.GetDamage(), customWeapon.Durability);

        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }

    static int ReadIntValue()
    {
        if (!Int32.TryParse(Console.ReadLine(), out var value))
        {
            Console.WriteLine("Not a number!");
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
        return value;
    }


}