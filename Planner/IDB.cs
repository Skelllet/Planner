using Planner.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planner
{
    interface IDb
    {
        List<Admin> GetAllAdmin();
        List<Stadiumworkers> GetAllStadiumworkers();
        List<Post> GetAllPositions();
        Post GetPositionById(int id);

        void AddField(Field field);

        void UpdateField(Field field);
        void updateJob(Job job);
        Field GetFieldById(int id);

        List<Job> GetAllJobsByIdWorkers(int id);

        List<Stadiumworkers> GetAllStadiumworkersByIdField(int id);

        void AddJob(Job job);

        List<Job> GetAllJobsByIdFields(int id);

        Field GetFieldByIdAdmin(int id);

        void AddStorage(Storage storage);

        List<Technic> GetAllTechnics(int id);
        List<Fertilizers> GetAllFertilizers(int id);
        List<Inventory> GetAllInventory(int id);
        List<Storage> GetAllStorageByIdField(int id);
        void AddTechnics(Technic technic);
        void AddFertilizers(Fertilizers fertilizers);
        void AddAllInventory(Inventory inventory);

        void UpdateTechnics(Technic technic);
        void UpdateFertilizers(Fertilizers fertilizers);
        void UpdateInventory(Inventory inventory);

    }
}
