using MeterCheck.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MeterCheck.Data
{
    public class PrizeReplaceDatabase
    {
        private readonly SQLiteAsyncConnection _database;

        public PrizeReplaceDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<PrizeReplace>().Wait();
        }

        public Task<List<PrizeReplace>> GetPersonsAsync()
        {
            return _database.Table<PrizeReplace>().ToListAsync();
        }

        public Task<PrizeReplace> GetPersonAsync(int replaceId)
        {
            return _database.Table<PrizeReplace>()
                .Where(x => x.ReplaceId == replaceId)
                .FirstOrDefaultAsync();
        }

        public Task<int> SavePersonAsync(PrizeReplace prizeReplace)
        {
            if (prizeReplace.ReplaceId != 0)
            {
                return _database.UpdateAsync(prizeReplace);
            }
            else
            {
                return _database.InsertAsync(prizeReplace);
            }
        }

        public Task<int> DeletePersonAsync(PrizeReplace prizeReplace)
        {
            return _database.DeleteAsync(prizeReplace);
        }
    }
}
