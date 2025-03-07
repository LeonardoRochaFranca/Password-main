using System;
using System.Diagnostics;
using System.Dynamic;

public class Password
{
    private int MinCharacters { get; set; }
    private bool IsSpecialCharactersRequired { get; set; }
    private bool IsUpperCaseRequired { get; set; }
    private bool IsJustNumeric { get; set; }
    private string[] SpecialCharacters = { "!", "@", "#", "$", "%", "&", "*", "?", "." };
    private string PasswordName { get; set; }

    public Password() { }

    public async Task SetPasswordRequirements()
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

        if (isJustNumeric != "S")
        {
            Console.Write("É necessário caracteres especiais? <S/N> ");
            SetIsSpecialCharactersRequired(Console.ReadLine().ToUpper());
            Console.Clear();

            Console.Write("É necessário caracteres maiúsculos? <S/N> ");
            SetIsUpperCaseRequired(Console.ReadLine().ToUpper());
            Console.Clear();
        }
        else
            SetIsJustNumeric(isJustNumeric);

        Console.WriteLine("Pronto!");
        await Task.Delay(3000);
        Console.Clear();
    }
    public void SetIsJustNumeric(string isJustNumeric)
    {
        if (isJustNumeric == "S")
            IsJustNumeric = true;
        else
            IsJustNumeric = false;
    }
    public void SetIsUpperCaseRequired(string isUpperCaseRequired)
    {
        if (isUpperCaseRequired == "S")
            IsUpperCaseRequired = true;
        else
            IsUpperCaseRequired = false;
    }
    public void SetIsSpecialCharactersRequired(string isSpecialCharactersRequired)
    {
        if (isSpecialCharactersRequired == "S")
            IsSpecialCharactersRequired = true;
        else
            IsSpecialCharactersRequired = false;
    }
    public int[] PopulateListPassword()
    {
        var PasswordRequiresList = new int[MinCharacters];
        var random = new Random();
        bool hasTwo = false;
        bool hasThree = false;

        if (IsJustNumeric)
        {
            for (int i = 0; i < MinCharacters; i++)
            {
                PasswordRequiresList[i] = 0;
            }
        }
        else if (!IsJustNumeric && IsUpperCaseRequired && !IsSpecialCharactersRequired)
        {
            for (int i = 0; i < MinCharacters; i++)
            {
                PasswordRequiresList[i] = random.Next(0, 3);
                if (PasswordRequiresList[i] == 2)
                    hasTwo = true;
            }

            if (!hasTwo)
                PasswordRequiresList[random.Next(0, MinCharacters)] = 2;
        }
        else if (!IsJustNumeric && !IsUpperCaseRequired && IsSpecialCharactersRequired)
        {
            for (int i = 0; i < MinCharacters; i++)
            {
                PasswordRequiresList[i] = random.Next(0, 4);
                if (PasswordRequiresList[i] == 2)
                    PasswordRequiresList[random.Next(0, MinCharacters)] = 1;
                else if (PasswordRequiresList[i] == 3)
                    hasThree = true;
            }
            if (!hasThree)
                PasswordRequiresList[random.Next(0, MinCharacters)] = 3;
        }
        else if (!IsJustNumeric && IsUpperCaseRequired && IsSpecialCharactersRequired)
        {
            for (int i = 0; i < MinCharacters; i++)
            {
                PasswordRequiresList[i] = random.Next(0, 4);
                if (PasswordRequiresList[i] == 2)
                    hasTwo = true;
                else if (PasswordRequiresList[i] == 3)
                    hasThree = true;
            }
            while (true)
            {
                if (hasTwo && hasThree)
                    break;

                if (!hasTwo && PasswordRequiresList[random.Next(0, MinCharacters)] != 3)
                {
                    PasswordRequiresList[random.Next(0, MinCharacters)] = 2;
                    hasTwo = true;
                }

                if (!hasThree && PasswordRequiresList[random.Next(0, MinCharacters)] != 2)
                {
                    PasswordRequiresList[random.Next(0, MinCharacters)] = 3;
                    hasThree = true;
                }
            }
        }
        return PasswordRequiresList;
    }
    public void GeneratePassword()
    {
        // 0 = numeros
        // 1 = letra
        // 2 = Maiusculo
        // 3 = Especial
        var PasswordRequiresList = PopulateListPassword();
        for (int i = 0; i < MinCharacters; i++)
        {


        }
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