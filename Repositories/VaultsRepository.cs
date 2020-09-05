using System;
using System.Collections.Generic;
using System.Data;
using Keepr.Models;
using Dapper;

namespace Keepr.Repositories
{
    public class VaultsRepository
    {
        private readonly IDbConnection _db;

        public VaultsRepository(IDbConnection db)
        {
            _db = db;
        }

        public IEnumerable<Vault> Get()
        {
            string sql = "SELECT * FROM vaults;";
            return _db.Query<Vault>(sql);
        }
        public IEnumerable<Vault> Get(string userId)
        {
            string sql = "SELECT * FROM vaults;";
            return _db.Query<Vault>(sql);
        }

        public Vault GetById(int id)
        {
            string sql = @"
        SELECT * FROM vaults WHERE id = @Id;";
            return _db.QueryFirstOrDefault<Vault>(sql, new { id });

        }
        public Vault Create(Vault newVault)
        {
            string sql = @"INSERT INTO vaults
            (userId, name, description)
            VALUES
            (@userId, @name, @description);
            SELECT LAST_INSERT_ID();";
            newVault.Id = _db.ExecuteScalar<int>(sql, newVault);
            return newVault;
        }


        public bool Delete(string userId, int id)
        {
            string sql = @"
            DELETE FROM vaults WHERE id = @Id AND userId = @userId LIMIT 1;";
            int rowsAffected = _db.Execute(sql, new { userId, id });
            return rowsAffected == 1;
        }

        internal bool Edit(Vault updatedVault)
        {
            string sql = @"
            UPDATE vaults
            SET
           name = @name, 
            description = @description, 
            WHERE id = @id AND userId = @userId LIMIT 1;";
            int rowsAffected = _db.Execute(sql, updatedVault);
            return rowsAffected == 1;
        }
    }
}