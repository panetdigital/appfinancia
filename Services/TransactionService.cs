using Blazored.LocalStorage;
using AppFinancia.Models;


namespace AppFinancia.Services
{
public class TransactionService
{
    private readonly ILocalStorageService _localStorage;
    private const string StorageKey = "transactions";

    public TransactionService(ILocalStorageService localStorage)
    {
        _localStorage = localStorage;
    }
    
    // recuperacao dados localStorage
    public async Task<List<Transaction>> GetTransactionsAsync()
    {
        var transactions = await _localStorage.GetItemAsync<List<Transaction>>(StorageKey);
        return transactions ?? new List<Transaction>();
    }


    // Recuperação do dados  do mes atual
        public async Task<List<Transaction>> GetTransactionsForCurrentMonthAsync()
    {
        var transactions = await _localStorage.GetItemAsync<List<Transaction>>(StorageKey);
        
        // Verifica se há transações e filtra pelo mês atual
        if (transactions != null)
        {
            var currentMonthTransactions = transactions
                .Where(t => t.Date.Year == DateTime.Now.Year && t.Date.Month == DateTime.Now.Month)
                .ToList();
            
            return currentMonthTransactions;
        }

        return new List<Transaction>(); // Retorna uma lista vazia se não houver transações
    }



    public async Task SaveTransactionAsync(Transaction transaction)
    {
        var transactions = await GetTransactionsAsync();
        transactions.Add(transaction);
        await _localStorage.SetItemAsync(StorageKey, transactions);
    }

    public async Task DeleteTransactionAsync(string id)
    {
        var transactions = await GetTransactionsAsync();
        var transaction = transactions.FirstOrDefault(t => t.Id == id);
        if (transaction != null)
        {
            transactions.Remove(transaction);
            await _localStorage.SetItemAsync(StorageKey, transactions);
        }
    }
}

}
