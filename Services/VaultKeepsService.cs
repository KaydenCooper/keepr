using System;
using System.Collections.Generic;
using System.Data;
using Keepr.Models;
using Keepr.Repositories;

namespace Keepr.Services
{
    public class VaultKeepsService
    {
        private readonly VaultKeepsRepository _repo;
        public VaultKeepsService(VaultKeepsRepository repo)
        {
            _repo = repo;
        }
        public IEnumerable<VaultKeepViewModel> GetKeepsByVaultId(int vaultId, string userId)
        {
            return _repo.GetKeepsByVaultId(vaultId, userId);
        }

        public VaultKeep Create(VaultKeep newVaultKeep)
        {
            int id = _repo.Create(newVaultKeep);
            newVaultKeep.Id = id;
            return newVaultKeep;
        }


        public VaultKeep Delete(int id)
        {
            VaultKeep exists = Get(id);
            _repo.Delete(id);
            return exists;
        }
        public VaultKeep Get(int id)
        {
            VaultKeep exists = _repo.GetById(id);
            return exists;
        }
    }
}