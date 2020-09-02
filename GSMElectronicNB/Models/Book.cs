using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GSMElectronicNB.Models
{
    public class Book
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public string ISBN { get; set; }
        public DateTime FinishedDate  { get; set; }


        public static MobileServiceClient client = new MobileServiceClient("https://readbook7.azurewebsites.net");

        public async Task<bool> SaveBook()
        {
            try
            {
                await client.GetTable<Book>().InsertAsync(this);
                return true;
            }
            catch (MobileServiceInvalidOperationException m) 
            {
                var result = await m.Response.Content.ReadAsStringAsync();
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public async Task<List<Book>> ReadBooks() 
        {
            return await client.GetTable<Book>().ToListAsync();
        }
        public override string ToString()
        {
            return $"{Name} - {Author}";
        }

    }
}
