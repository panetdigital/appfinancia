namespace AppFinancia.Models
{
public class Transaction
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string? Description { get; set; }
    public decimal Amount { get; set; }
    public CategoriaTransaction Category { get; set; }
    public DateTime Date { get; set; }
    public bool IsExpense { get; set; }
}

public enum CategoriaTransaction
{
    Alimentação,
    Salario,
    Vale,
    Presente,
    Transporte,
    Moradia,
    Educação,
    Lazer,
    Remedio,
    Gas,
    Internet,
    Agua,
    Luz,
    ProdLimpenza,
    Cabelo,
    Emprestimo,
    Roupas,
    Outros
}
}