using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using Calculation.Enums;

namespace Storage
{
    public class DbSolutionsInitializer : CreateDatabaseIfNotExists<DbSolutionContext>
    {
        protected override void Seed(DbSolutionContext context)
        {
            base.Seed(context);
            var grid = context.CreateGrid(0, 1, 100);
            var solution = context.CreateExactSolution(grid, new {s = 1, Re = 2.1});
        }
    }
}