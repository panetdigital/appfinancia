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

    public async Task<List<Transaction>> GetTransactionsAsync()
    {
        var transactions = await _localStorage.GetItemAsync<List<Transaction>>(StorageKey);
        return transactions ?? new List<Transaction>();
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