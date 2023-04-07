using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EmployeeAllowanceApp.Model;
using SQLite;

namespace EmployeeAllowanceApp.Model
{
    public class DatabaseClass
    {
        readonly SQLiteAsyncConnection database;

        public DatabaseClass(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<PostAllowance>().Wait();
            //database.CreateTableAsync<PostAllowance>().Wait();
            //database.CreateTableAsync<PresentEmployee>().Wait();
        }

        //Get all AllowanceNameList.
        public Task<List<PostAllowance>> GetEmpAllowanceData()
        {
            try
            {
                return database.Table<PostAllowance>().ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        //saveAllowanceDetails
        public async Task<bool> SaveEmpAllowanceData(List<PostAllowance> AllowanceList)
        {
            try
            {
                //if (AllowanceList != null)
                //{
                //    await database.UpdateAsync(AllowanceList);
                //    return true;
                //}
                //else
                //{
                    foreach (PostAllowance allow in AllowanceList)
                    {
                        await database.InsertAllAsync(AllowanceList);
                    }
                    return true;
                //}
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task<bool> DeleteLastDayAllowanceDetail(List<PostAllowance> EmpallowanceDetail)
        {
            try
            {
                foreach (var empData in EmpallowanceDetail)
                {
                    // Delete a row.
                    await database.DeleteAsync(EmpallowanceDetail);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
