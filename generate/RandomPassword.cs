using System.Text;

namespace GeneratePassword.generate
{ 
    public class GeneratePassword
    {
        private Random random = new Random();

        public GeneratePassword() {}
        private readonly char[] alphabet_lower = 
                {   'a','b','c','d','e','f','g',
                    'h','i','j','k','l','m','n',
                    'o','p','q','r','s','t','u',
                    'v','w','x','y','z' };  
        private readonly char[] alphabet_upper = 
                {   'A','B','C','D','E','F','G',
                    'H','I','J','K','L','M','N',
                    'O','P','Q','R','S','T','U',
                    'V','W','X','Y','Z' };

        private readonly char[] symbols = { 
            '`','!','@','#','$','%','^',
            '&','*','(',')','-','_','=',
            '+','[',']','{','}','\\','|',
            ';',':','"','\'',',','.','<',
            '>','/','?'};

        private string RandomGenerate(params OptionGenerate[] options)
        {
            return options[random.Next(options.Length)] switch
            {
                OptionGenerate.LowerCase => alphabet_lower[random.Next(alphabet_lower.Length)].ToString(),
                OptionGenerate.UpperCase => alphabet_upper[random.Next(alphabet_upper.Length)].ToString(),
                OptionGenerate.Symbols => symbols[random.Next(symbols.Length)].ToString(),
                OptionGenerate.Numbers => random.Next(10).ToString(),
                _ => alphabet_lower[random.Next(alphabet_lower.Length)].ToString(),

            };
        }
        public string Generate(int lenght, params OptionGenerate[] options)
        {
            if (lenght > 40) throw new ApplicationException("password terlalu panjang");

            int len = (lenght > 5) ? lenght : 6;
            OptionGenerate[] optionGenerate = (options.Length > 0) ? options : new OptionGenerate[]{OptionGenerate.LowerCase,OptionGenerate.Numbers};
            var result = new StringBuilder(len);

            for (int i = 1; i <= len; i++)
            {
                result.Append(RandomGenerate(optionGenerate));
            }
            return result.ToString();
        }

         public string GenerateUnique(int lenght, params OptionGenerate[] options)
        {
            if (lenght > 40) throw new ApplicationException("password terlalu panjang");
            int len = (lenght > 5) ? lenght : 6;
            OptionGenerate[] optionGenerate = (options.Length > 0) ? options : new OptionGenerate[]{OptionGenerate.LowerCase,OptionGenerate.Numbers};
            var result = new StringBuilder(lenght);
            var unique_result = new SortedSet<string>();

            while(true)
            {
                if(unique_result.Count == len) break;
                unique_result.Add(RandomGenerate(optionGenerate));
            }

            unique_result.ToList().ForEach((unique) => result.Append(unique));
            return result.ToString();

        }


    }
}