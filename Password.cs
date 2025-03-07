using System;
using System.Dynamic;

public class Password
{
    private int MinCharacters { get; set; }
    private bool IsSpecialCharactersRequired { get; set; }
    private bool IsUpperCaseRequired { get; set; }
    private bool IsJustNumeric { get; set; }
    private string[] SpecialCharacters = {"!", "@", "#", "$","%","&","*","?","."};
    private string PasswordName { get; set; }
    public Password(){}

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
        
        if(isJustNumeric != "S")
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

    public void GeneratePassword()
    {//random.Next(0, 10);

        for(int i = 0; i < (MinCharacters+3); i++)
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