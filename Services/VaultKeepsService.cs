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
        private readonly VaultsService _vs;
        public VaultKeepsService(VaultKeepsRepository repo, VaultsService vs)
        {
            _repo = repo;
            _vs = vs;
        }
        public VaultKeep Create(VaultKeep newVaultKeep)
        {
            int id = _repo.Create(newVaultKeep);
            newVaultKeep.Id = id;
            return newVaultKeep;
        }
        public IEnumerable<VaultKeepViewModel> GetKeepsByVaultId(int vaultId, string userId)
        {
            return _repo.GetKeepsByVaultId(vaultId, userId);
        }


        public VaultKeep Get(int id)
        {
            VaultKeep exists = _repo.GetById(id);
            if (exists == null)
            {
                throw new Exception("Wrong Keep Bud!");
            }
            return exists;
        }

        public VaultKeep Delete(int id)
        {
            VaultKeep exists = Get(id);
            _repo.Delete(id);
            return exists;
        }
    }
}