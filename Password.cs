using System;
using System.Threading.Tasks;

public class Password
{
    private int MinCharacters { get; set; }
    private bool IsSpecialCharactersRequired { get; set; }
    private bool IsUpperCaseRequired { get; set; }
    private bool IsJustNumeric { get; set; }
    private readonly string[] SpecialCharacters = { "!", "@", "#", "$", "%", "&", "*", "?", "." };
    private string PasswordName { get; set; }

    public Password() { }

    private async Task SetPasswordRequirements()
    {
        Console.WriteLine("Bem-vindo ao gerador de senha. Por favor, informe os requerimentos necessários:");
        Console.WriteLine(" ");

        Console.Write("Para começarmos, digite como quer chamar sua senha: ");
        PasswordName = Console.ReadLine();
        Console.Clear();

        Console.Write("Qual o mínimo de caracteres necessários? ");
        MinCharacters = int.Parse(Console.ReadLine());
        Console.Clear();

        Console.Write("A senha é apenas numerica? <S/N>  ");
        string isJustNumeric = Console.ReadLine().ToUpper();
        Console.Clear();
        SetIsJustNumeric(isJustNumeric);

        if (!IsJustNumeric)
        {
            Console.Write("É necessário caracteres especiais? <S/N> ");
            SetIsSpecialCharactersRequired(Console.ReadLine().ToUpper());
            Console.Clear();

            Console.Write("É necessário caracteres maiúsculos? <S/N> ");
            SetIsUpperCaseRequired(Console.ReadLine().ToUpper());
            Console.Clear();
        }

        Console.WriteLine("Pronto!");
        await Task.Delay(3000);
        Console.Clear();
    }
    private void SetIsJustNumeric(string isJustNumeric)
    {
        if (isJustNumeric == "S")
        {
            IsJustNumeric = true;
            IsUpperCaseRequired = false;
            IsSpecialCharactersRequired = false;
        }
        else
            IsJustNumeric = false;
    }
    private void SetIsUpperCaseRequired(string isUpperCaseRequired) => IsUpperCaseRequired = isUpperCaseRequired == "S";
    private void SetIsSpecialCharactersRequired(string isSpecialCharactersRequired) => IsSpecialCharactersRequired = isSpecialCharactersRequired == "S";
    private int[] PopulateListPassword()
    {
        var passwordRequiresList = new int[MinCharacters];
        var random = new Random();
        bool hasTwo = false;
        bool hasThree = false;

        if (IsJustNumeric)
        {
            for (int i = 0; i < MinCharacters; i++)
            {
                passwordRequiresList[i] = 0;
            }
        }
        else if (!IsJustNumeric && IsUpperCaseRequired && !IsSpecialCharactersRequired)
        {
            for (int i = 0; i < MinCharacters; i++)
            {
                passwordRequiresList[i] = random.Next(0, 3);
                if (passwordRequiresList[i] == 2)
                    hasTwo = true;
            }

            if (!hasTwo)
                passwordRequiresList[random.Next(0, MinCharacters)] = 2;
        }
        else if (!IsJustNumeric && !IsUpperCaseRequired && IsSpecialCharactersRequired)
        {
            for (int i = 0; i < MinCharacters; i++)
            {
                passwordRequiresList[i] = random.Next(0, 4);
                if (passwordRequiresList[i] == 2)
                    passwordRequiresList[random.Next(0, MinCharacters)] = 1;
                else if (passwordRequiresList[i] == 3)
                    hasThree = true;
            }
            if (!hasThree)
                passwordRequiresList[random.Next(0, MinCharacters)] = 3;
        }
        else if (!IsJustNumeric && IsUpperCaseRequired && IsSpecialCharactersRequired)
        {
            for (int i = 0; i < MinCharacters; i++)
            {
                passwordRequiresList[i] = random.Next(0, 4);
                if (passwordRequiresList[i] == 2)
                    hasTwo = true;
                else if (passwordRequiresList[i] == 3)
                    hasThree = true;
            }
            while (true)
            {
                if (hasTwo && hasThree)
                    break;

                if (!hasTwo && passwordRequiresList[random.Next(0, MinCharacters)] != 3)
                {
                    passwordRequiresList[random.Next(0, MinCharacters)] = 2;
                    hasTwo = true;
                }

                if (!hasThree && passwordRequiresList[random.Next(0, MinCharacters)] != 2)
                {
                    passwordRequiresList[random.Next(0, MinCharacters)] = 3;
                    hasThree = true;
                }
            }
        }
           else if (!IsJustNumeric && !IsUpperCaseRequired && !IsSpecialCharactersRequired)
        {
            for (int i = 0; i < MinCharacters; i++)
            {
                passwordRequiresList[i] = random.Next(0, 2);
            }
        }
        return passwordRequiresList;
    }
    public async Task<string> GeneratePassword()
    {
        // 0 = numeros
        // 1 = letra
        // 2 = Maiusculo
        // 3 = Especial
        var random = new Random();
        await SetPasswordRequirements();
        var passwordRequiresList = PopulateListPassword();
        var password = new List<string>();

        for (int i = 0; i < passwordRequiresList.Length; i++)
        {
            switch (passwordRequiresList[i])
            {
                case 0:
                    password.Add(random.Next(0, 10).ToString());
                    break;
                case 1:
                    password.Add(((char)random.Next(97, 123)).ToString());
                    break;
                case 2:
                    password.Add(((char)random.Next(65, 91)).ToString());
                    break;
                case 3:
                    password.Add(SpecialCharacters[random.Next(0, SpecialCharacters.Length)].ToString());
                    break;
            }
        }
        return string.Concat(password);
    }

    public void SavePassword()
    {
        //Future Implementation
    }

    public void EncryptPassword()
    {
        //Future Implementation
    }
}