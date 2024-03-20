// See https://aka.ms/new-console-template for more information

public interface IAnimal
{
    void Speak();
}

public class Dog : IAnimal
{
    public void Speak()
    {
        Console.WriteLine("Woof");
    }
}

public class Cat : IAnimal
{
    public void Speak()
    {
        Console.WriteLine("Meow");
    }
}

public abstract class AnimalFactory
{
    public abstract IAnimal CreateAnimal();
}

public class DogFactorty: AnimalFactory
{
    public override IAnimal CreateAnimal()
    {
        return new Dog();
    }
}

public class CatFactory : AnimalFactory
{
    public override IAnimal CreateAnimal()
    {
        return new Cat();
    }
}

class Program
{
    //For the factrory creational design pattern I have implemented an abstract Factory style
    static void Main(string[] args)
    {
        AnimalFactory dogFactory = new DogFactorty();
        IAnimal dog = dogFactory.CreateAnimal();
        dog.Speak();

        AnimalFactory catFactory = new CatFactory();
        IAnimal cat = catFactory.CreateAnimal();
        cat.Speak();
    }
}