using KanbanBoard.Shared.Items.Commands;
using KanbanBoard.Shared.Models;
using System.Net.Http.Json;

namespace KanbanBoard.Client.HttpStorage.Items;

public class ItemStorage : IItemStorage
{
    private readonly HttpClient _httpClient;
    private const string ENDPOINT_NAME = "items";

    public ItemStorage(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task Add(AddItemCommand command)
        => await _httpClient.PostAsJsonAsync(ENDPOINT_NAME, command);

    public async Task<IEnumerable<Item>> GetAll()
        => await _httpClient.GetFromJsonAsync<IEnumerable<Item>>(ENDPOINT_NAME);

    public async Task ChangeItemState(ChangeItemStateCommand command)
        => await _httpClient.PutAsJsonAsync(ENDPOINT_NAME, command);

    public async Task<IEnumerable<Item>> GetArchive()
        => await _httpClient.GetFromJsonAsync<IEnumerable<Item>>($"{ENDPOINT_NAME}-archive");
}
