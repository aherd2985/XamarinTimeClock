using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SQLite;
using TimeClock.Models;

namespace TimeClock.Data
{
  public class JobItemDatabase
  {
    static readonly Lazy<SQLiteAsyncConnection> lazyInitializer = new Lazy<SQLiteAsyncConnection>(() =>
    {
      return new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
    });

    static SQLiteAsyncConnection Database => lazyInitializer.Value;
    static bool initialized = false;

    public JobItemDatabase()
    {
      InitializeAsync().SafeFireAndForget(false);
    }

    async Task InitializeAsync()
    {
      if (!initialized)
      {
        if (!Database.TableMappings.Any(m => m.MappedType.Name == typeof(JobItem).Name))
        {
          await Database.CreateTablesAsync(CreateFlags.None, typeof(JobItem)).ConfigureAwait(false);
        }
        initialized = true;
      }
    }

    public Task<List<JobItem>> GetItemsAsync()
    {
      return Database.Table<JobItem>().ToListAsync();
    }

    public Task<JobItem> GetItemAsync(int JobID)
    {
      return Database.Table<JobItem>().Where(i => i.JobID == JobID).FirstOrDefaultAsync();
    }
    public Task<List<JobItem>> SearchItemAsync(string JobAddress)
    {
      return Database.Table<JobItem>().Where(i => i.JobAddress.ToUpper().Contains(JobAddress.ToUpper())).Take(200).ToListAsync();
    }

    public Task<JobItem> GetLastTimeClockItemAsync()
    {
      return Database.Table<JobItem>().OrderByDescending(x => x.JobID).FirstOrDefaultAsync();
    }

    public Task<int> SaveItemAsync(JobItem item)
    {
      if (item.JobID != 0)
      {
        return Database.UpdateAsync(item);
      }
      else
      {
        return Database.InsertAsync(item);
      }
    }

    public async void CreateDummyData()
    {
      for (int i = 0; i < 6500000; i++)
      {
        JobItem newJobItem = new JobItem();
        newJobItem.JobCode = "Job #" + i.ToString();
        newJobItem.JobAddress = i.ToString() + " Fake Street";
       await SaveItemAsync(newJobItem);
      }
    }

    public Task<int> DeleteItemAsync(JobItem item)
    {
      return Database.DeleteAsync(item);
    }



  }
}
