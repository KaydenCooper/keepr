using System;
using System.Collections.Generic;
using System.Data;
using Keepr.Models;
using Dapper;

namespace Keepr.Repositories
{
    public class VaultKeepsRepository
    {
        private readonly IDbConnection _db;

        public VaultKeepsRepository(IDbConnection db)
        {
            _db = db;
        }


        public VaultKeep Create(VaultKeep newVaultKeeps)
        {
            string sql = @"
            UPDATE keeps
            SET keeps = keeps + 1
            WHERE id = @keepId;
            INSERT INTO vaultkeeps
            (vaultId, keepId, userId)
            VALUES
            (@vaultId, @keepId, @userId);
            SELECT LAST_INSERT_ID();";
            newVaultKeeps.Id = _db.ExecuteScalar<int>(sql, newVaultKeeps);
            return newVaultKeeps;

        }


        public IEnumerable<VaultKeepViewModel> GetKeepsByVaultId(int vaultId, string userId)
        {
            string sql = @"
            SELECT 
                k.*,
                vk.id as vaultKeepId
                FROM vaultkeeps vk
                INNER JOIN keeps k ON k.id = vk.keepId 
                WHERE (vaultId = @vaultId AND vk.userId = @userId) ";
            return _db.Query<VaultKeepViewModel>(sql, new { vaultId, userId });

        }

        public VaultKeep GetById(int id, string userId)
        {
            string sql = @"
        SELECT * FROM vaultkeeps WHERE id = @Id AND userId = @UserId;";
            return _db.QueryFirstOrDefault<VaultKeep>(sql, new { id, userId });

        }

        public bool Delete(int id, string userId)
        {
            string sql = @"
            UPDATE keeps 
            SET keeps = keeps - 1
            WHERE id = @Id;
            DELETE FROM vaultkeeps WHERE id = @Id AND userId = @UserId;";
            int rowsAffected = _db.Execute(sql, new { id, userId });
            return rowsAffected == 1;
        }


    }
}