using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SQLite;

namespace TimeClock
{
    public class TimeClockItemDatabase
    {
        static readonly Lazy<SQLiteAsyncConnection> lazyInitializer = new Lazy<SQLiteAsyncConnection>(() =>
        {
            return new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        });

        static SQLiteAsyncConnection Database => lazyInitializer.Value;
        static bool initialized = false;

        public TimeClockItemDatabase()
        {
            InitializeAsync().SafeFireAndForget(false);
        }

        async Task InitializeAsync()
        {
            if (!initialized)
            {
                if (!Database.TableMappings.Any(m => m.MappedType.Name == typeof(TimeClockItem).Name))
                {
                    await Database.CreateTablesAsync(CreateFlags.None, typeof(TimeClockItem)).ConfigureAwait(false);                    
                }
                initialized = true;
            }
        }

        public Task<List<TimeClockItem>> GetItemsAsync()
        {
            return Database.Table<TimeClockItem>().ToListAsync();
        }

        public Task<List<TimeClockItem>> GetItemsNotDoneAsync()
        {
            return Database.QueryAsync<TimeClockItem>("SELECT * FROM [TimeClockItem] WHERE [Done] = 0");
        }

        public Task<TimeClockItem> GetItemAsync(int id)
        {
            return Database.Table<TimeClockItem>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(TimeClockItem item)
        {
            if (item.ID != 0)
            {
                return Database.UpdateAsync(item);
            }
            else
            {
                return Database.InsertAsync(item);
            }
        }

        public Task<int> DeleteItemAsync(TimeClockItem item)
        {
            return Database.DeleteAsync(item);
        }
    }
}

