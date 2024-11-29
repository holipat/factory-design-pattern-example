//Factory Design Pattern - Video Player

using System.ComponentModel;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;

abstract class Component
{
    public abstract string Render();
}

//Components for Windows, Windows components

class WindowsPlayButton: Component
{
    public override string Render()
    {
        return "render Windows play button";
    }
}

class WindowsTimeline : Component
{
    public override string Render()
    {
        return "render Windows timeline";
    }
}

class WindowsWindow : Component
{
    public override string Render()
    {
        return "render Windows window";
    }
}

//Components for Mac, Mac components

class MacPlayButton : Component
{
    public override string Render()
    {
        return "render Mac play button";
    }
}

class MacTimeline : Component
{
    public override string Render()
    {
        return "render Mac timeline";
    }
}

class MacWindow : Component
{
    public override string Render()
    {
        return "render Mac window";
    }
}


abstract class AbstractPlayerComponentFactory
{
    public abstract Component CreateComponent(string component);
}


//Windows Factory
class WindowsPlayerComponentFactory : AbstractPlayerComponentFactory
{
    public override Component CreateComponent(string myComponent)
    {
        if (myComponent == "play_button")
            return new WindowsPlayButton();

        else if (myComponent == "timeline")
            return new WindowsTimeline();

        else if (myComponent == "window")
            return new WindowsWindow();

        else
            throw new ArgumentException("Invalid component type", nameof(myComponent));
    }
}

//Mac Factory
class MacPlayerComponentFactory : AbstractPlayerComponentFactory
{
    public override Component CreateComponent(string myComponent)
    {
        if (myComponent == "play_button")
            return new MacPlayButton();

        else if (myComponent == "timeline")
            return new MacTimeline();

        else if (myComponent == "window")
            return new MacWindow();

        else
            throw new ArgumentException("Invalid component type", nameof(myComponent));
    }
}


class Program
{

//Client code doesn't need to know the OS.
//If we want to add new features; we don't need to change our client code

    static void Client(AbstractPlayerComponentFactory factory)
    {
        Component play_button = factory.CreateComponent("play_button");
        Component timeline = factory.CreateComponent("timeline");
        Component window = factory.CreateComponent("window");

        Console.WriteLine(play_button.Render() + "\n" +  timeline.Render() + "\n" + window.Render());
    }

    static void Main(string[] args)
    {
        switch (Environment.OSVersion.Platform)
        {
            case PlatformID.Win32NT:
                Client(new WindowsPlayerComponentFactory());
                break;
            case PlatformID.MacOSX:
                Client(new MacPlayerComponentFactory());
                break;
            default:
                Console.WriteLine("OS not supported");
                break;
        }
    }
}