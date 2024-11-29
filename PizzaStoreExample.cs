// Factory Method Design Pattern kullanılarak pizza sipariş sistemi

// Ankara ve İstanbul için iki farklı pizza dükkanı.
PizzaStore ankaraPizzaStore = new AnkaraPizzaStore();
PizzaStore istanbulPizzaStore = new IstanbulPizzaStore();

// Ankara dükkanından "cheese" türünde bir pizza sipariş ediliyor.
IPizza cheesePizza = ankaraPizzaStore.OrderPizza("cheese");
Console.WriteLine("Cheese pizza ordered in Ankara Store");

// İstanbul dükkanından "veggie" türünde bir pizza sipariş ediliyor.
IPizza veggiePizza = istanbulPizzaStore.OrderPizza("veggie");
Console.WriteLine("Veggie pizza ordered in Istanbul Store");

// Tüm pizza türlerinin uyması gereken arayüz.
// Her pizza hazırlama, pişirme ve kesme yöntemlerini içerir.
interface IPizza
{
    void Prepare(); // Pizza hazırlanır
    void Bake();    // Pizza pişirilir
    void Cut();     // Pizza kesilir
}

// Peynirli pizza sınıfı, IPizza arayüzünü uygular.
class CheesePizza : IPizza
{
    public void Prepare()
    {
        Console.WriteLine("Cheese pizza prepared.");
    }
    public void Bake()
    {
        Console.WriteLine("Cheese pizza baked.");
    }
    public void Cut()
    {
        Console.WriteLine("Cheese pizza cut.");
    }
}

// Sebzeli pizza sınıfı, IPizza arayüzünü uygular.
class VeggiePizza : IPizza
{
    public void Prepare()
    {
        Console.WriteLine("Veggie pizza prepared.");
    }
    public void Bake()
    {
        Console.WriteLine("Veggie pizza baked.");
    }
    public void Cut()
    {
        Console.WriteLine("Veggie pizza cut.");
    }
}

// PizzaStore sınıfı soyut bir temel sınıftır.
// Farklı mağazalar için özelleştirilmiş pizza oluşturma yöntemini sağlar.
abstract class PizzaStore
{
    // Pizza oluşturma yöntemi, alt sınıflarda tanımlanmalıdır.
    protected abstract IPizza CreatePizza(string type);

    // Pizza sipariş süreci, pizza oluşturmayı ve temel işlemleri içerir.
    public IPizza OrderPizza(string type)
    {
        IPizza pizza = CreatePizza(type); // Pizza oluşturulur.

        pizza.Prepare(); // Hazırlama işlemi yapılır.
        pizza.Bake();    // Pişirme işlemi yapılır.
        pizza.Cut();     // Kesme işlemi yapılır.

        return pizza;    // Hazır pizza döndürülür.
    }
}

// Ankara için pizza mağazası sınıfı
class AnkaraPizzaStore : PizzaStore
{
    // Pizza türüne göre uygun bir pizza nesnesi oluşturur.
    protected override IPizza CreatePizza(string type)
    {
        return type switch
        {
            "cheese" => new CheesePizza(),
            "veggie" => new VeggiePizza(),
            _ => throw new ArgumentException("Invalid pizza type", nameof(type))
        };
    }
}

// İstanbul için pizza mağazası sınıfı
class IstanbulPizzaStore : PizzaStore
{
    // Pizza türüne göre uygun bir pizza nesnesi oluşturur.
    protected override IPizza CreatePizza(string type)
    {
        return type switch
        {
            "cheese" => new CheesePizza(),
            "veggie" => new VeggiePizza(),
            _ => throw new ArgumentException("Invalid pizza type", nameof(type))
        };
    }
}
