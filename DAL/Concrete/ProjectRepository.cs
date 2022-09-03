using DAL.Contracts;
using Entities.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Concrete
{
    internal class ProjectRepository : BaseRepository<Project, Guid>, IProjectRepository
    {
        public ProjectRepository(HumanResourcesContext dbContext) : base(dbContext)
        {
        }
        //Password Hash Convert
        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        public static string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }


        public Project GetByName(string name)
        {
            var project = context.Where(a => a.Names == name).FirstOrDefault();
            return project;
        }
        public Project GetById(Guid id)
        {
            var project = context.Where(a => a.Id == id).FirstOrDefault();
            return project;
        }

        public Project Add(Project project)
        {


            context.Add(project);
            PersistChangesToTrackedEntities();
            return context.Add(project).Entity;


        }



        public void Update(Project project)
        {
            if (db.Entry(project).State == EntityState.Detached)
            {
                context.Attach(project);
            }
            //context.Update(project);
            SetModified(project);
            PersistChangesToTrackedEntities();


        }
        public void Remove(Guid id)
        {
            Project projectToRemove = context.Find(id);
            if (projectToRemove != null)
            {
                Remove(projectToRemove);
            }
            PersistChangesToTrackedEntities();

        }
        /*public void Remove(Project project)
        {

        }
        */
    }
}
