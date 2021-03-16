using SegundaOportunidad.Domain.Entities;
using SegundaOportunidad.Repository.BaseRepository;
using SegundaOportunidad.Repository.Context;
using SegundaOportunidad.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SegundaOportunidad.Repository.Repositories
{
    public class ModeloRepository : BaseRepository<Modelo>,IModeloRepository
    {
        private readonly SegundaOportunidadContext db;

        public ModeloRepository(SegundaOportunidadContext db) : base(db)
        {
            this.db = db;
        }
        public async Task AddModelo(Modelo Modelo)
        {
            try
            {
                await base.Add(Modelo);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public void UpdateModelo(Modelo Modelo)
        {
            try
            {
                base.Update(Modelo);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IEnumerable<Modelo> GetModelos()
        {
            try
            {
                return base.FindAll(oModelo => !oModelo.Deleted);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<Modelo> GetModeloById(int id)
        {
            try
            {
                return await base.GetById(id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<bool> ExisteModelo()
        {
            try
            {
                return await base.Exists(oModelo => !oModelo.Deleted);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }

        }

        public async Task<bool> SaveModelo()
        {
            return await base.Commit();
        }
    }
}
