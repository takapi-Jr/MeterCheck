using MeterCheck.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MeterCheck.Data
{
    public class MachineDatabase
    {
        private readonly SQLiteAsyncConnection _database;

        public MachineDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Machine>().Wait();
        }

        public Task<List<Machine>> GetMachineListAsync()
        {
            return _database.Table<Machine>().ToListAsync();
        }

        public Task<Machine> GetMachineAsync(int machineId)
        {
            return _database.Table<Machine>()
                .Where(x => x.MachineId == machineId)
                .FirstOrDefaultAsync();
        }

        public Task<int> SaveMachineAsync(Machine machine)
        {
            if (machine.MachineId != 0)
            {
                return _database.UpdateAsync(machine);
            }
            else
            {
                return _database.InsertAsync(machine);
            }
        }

        public Task<int> DeleteMachineAsync(Machine machine)
        {
            return _database.DeleteAsync(machine);
        }
    }
}
