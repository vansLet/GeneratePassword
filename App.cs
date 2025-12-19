namespace GeneratePassword
{
    using GeneratePassword.generate;
    public class App
    {
        public static void Main()
        {
            GeneratePassword generate = new GeneratePassword();
            Console.WriteLine(generate.GenerateUnique(10,OptionGenerate.Symbols));

        }
    }
}