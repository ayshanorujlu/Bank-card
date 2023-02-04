namespace Bank_t
{
    public class Bank
    {
        public List<Client> clients = new();
        public void ShowCard(BankCard bankCard)
        {
            Console.WriteLine($"Balance:{bankCard}");
        }
        public void AddUser(Client client)
        {
            clients.Add(client);
        }
    }
}
