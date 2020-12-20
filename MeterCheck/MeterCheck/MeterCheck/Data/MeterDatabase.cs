using MeterCheck.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MeterCheck.Data
{
    public class MeterDatabase
    {
        private readonly SQLiteAsyncConnection _database;

        public MeterDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Meter>().Wait();
        }

        public Task<List<Meter>> GetMeterListAsync()
        {
            return _database.Table<Meter>().ToListAsync();
        }

        public Task<List<Meter>> GetMeterListAsync(int machineId)
        {
            return _database.Table<Meter>()
                .Where(x => x.MachineId == machineId)
                .ToListAsync();
        }

        public Task<Meter> GetMeterAsync(int meterId)
        {
            return _database.Table<Meter>()
                .Where(x => x.MeterId == meterId)
                .FirstOrDefaultAsync();
        }

        public Task<int> SaveMeterAsync(Meter meter)
        {
            if (meter.MachineId != 0)
            {
                return _database.UpdateAsync(meter);
            }
            else
            {
                return _database.InsertAsync(meter);
            }
        }

        public Task<int> DeleteMeterAsync(Meter meter)
        {
            return _database.DeleteAsync(meter);
        }
    }
}
