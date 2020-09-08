using System;
using System.Collections.Generic;
using System.Data;
using Keepr.Models;
using Dapper;

namespace Keepr.Repositories
{
    public class KeepsRepository
    {
        private readonly IDbConnection _db;

        public KeepsRepository(IDbConnection db)
        {
            _db = db;
        }

        public IEnumerable<Keep> Get()
        {
            string sql = "SELECT * FROM keeps WHERE IsPrivate = 0;";
            return _db.Query<Keep>(sql);
        }
        public IEnumerable<Keep> Get(string userId)
        {
            string sql = "SELECT * FROM keeps WHERE userId = @UserId;";
            return _db.Query<Keep>(sql, new { userId });
        }

        public Keep GetById(int id)
        {
            string sql = @"
        SELECT * FROM keeps WHERE id = @Id AND IsPrivate = 0;";
            return _db.QueryFirstOrDefault<Keep>(sql, new { id });

        }
        public Keep Create(Keep newKeep)
        {
            string sql = @"INSERT INTO keeps
            (userId, name, description, img, isprivate, views, shares, keeps)
            VALUES
            (@userId, @name, @description, @img, @isprivate, @views, @shares, @keeps);
            SELECT LAST_INSERT_ID();";
            newKeep.Id = _db.ExecuteScalar<int>(sql, newKeep);
            return newKeep;
        }


        public bool Delete(string userId, int id)
        {
            string sql = @"
            DELETE FROM keeps WHERE id = @Id AND userId = @userId LIMIT 1;";
            int rowsAffected = _db.Execute(sql, new { userId, id });
            return rowsAffected == 1;
        }

        public Keep Edit(Keep foundKeep)
        {
            string sql = @"
            UPDATE keeps
            SET
           name = @name, 
            description = @description, 
            img = @img
            WHERE id = @id AND userId = @userId;";
            return _db.QueryFirstOrDefault<Keep>(sql, foundKeep);
        }
    }
}