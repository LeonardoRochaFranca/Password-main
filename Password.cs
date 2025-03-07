using System;

public class Password
{
    private int MinCharacters { get; set; }
    private bool IsSpecialCharactersRequired { get; set; }
    private bool IsUpperCaseRequired { get; set; }
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

        Console.Write("É necessário caracteres especiais? <S/N> ");
        SetIsSpecialCharactersRequired(Console.ReadLine().ToUpper());
        Console.Clear();

        Console.Write("É necessário caractere maiúsculo? <S/N> ");
        SetIsUpperCaseRequired(Console.ReadLine().ToUpper());
        Console.Clear();

        Console.WriteLine("Pronto!");
        await Task.Delay(3000);
        Console.Clear();
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
}