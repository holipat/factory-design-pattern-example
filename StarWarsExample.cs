// Abstract Factory 10.03.2024
// We will make a Star Wars game and user will be sith or jedi according to OS.

abstract class Accessory
{
    public abstract string Render();
}

class BlueLightSaber : Accessory
{
    public override string Render()
    {
        return "render BLUE lightsaber";
    }
}
class BlueEyes : Accessory
{
    public override string Render()
    {
        return "render BLUE eyes";
    }
}
class WhiteRobe : Accessory
{
    public override string Render()
    {
        return "render WHITE robe ";
    }
}

class RedLightSaber : Accessory
{
    public override string Render()
    {
        return "render RED lightsaber";
    }
}
class RedEyes : Accessory
{
    public override string Render()
    {
        return "render RED eyes";
    }
}
class BlackRobe : Accessory
{
    public override string Render()
    {
        return "render BLACK robe ";
    }
}

abstract class AbstractAccessoryFactory
{
    public abstract Accessory CreateLightSaber();
    public abstract Accessory CreateEyes();
    public abstract Accessory CreateRobe();
}

class SithAccessoryFactory : AbstractAccessoryFactory
{
    public override Accessory CreateEyes()
    {
        return new RedEyes();
    }

    public override Accessory CreateLightSaber()
    {
        return new RedLightSaber();
    }

    public override Accessory CreateRobe()
    {
        return new BlackRobe();
    }
}

class JediAccessoryFactory : AbstractAccessoryFactory
{
    public override Accessory CreateEyes()
    {
        return new BlueEyes();
    }

    public override Accessory CreateLightSaber()
    {
        return new BlueLightSaber();
    }

    public override Accessory CreateRobe()
    {
        return new WhiteRobe();
    }
}


public class Program
{
    //Is it okay to make this static???
    static void Client(AbstractAccessoryFactory factory)
    {
        Accessory eyes = factory.CreateEyes();
        Accessory lightsaber = factory.CreateLightSaber();
        Accessory robe = factory.CreateRobe();

        Console.WriteLine(eyes.Render() + "\n" + lightsaber.Render() + "\n" + robe.Render());
    }

    public static void Main()
    {

        switch (Environment.OSVersion.Platform)
        {
            case PlatformID.Win32NT:
            case PlatformID.Win32S:
            case PlatformID.Win32Windows:
            case PlatformID.WinCE:
                Client(new SithAccessoryFactory());
                break;
            case PlatformID.MacOSX:
                Client(new JediAccessoryFactory());
                break;
            default:
                Console.WriteLine("OS not supported");
                break;
        }
    }
}