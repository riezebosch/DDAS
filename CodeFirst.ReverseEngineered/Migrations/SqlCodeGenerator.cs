using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations.Design;
using System.Data.Entity.Migrations.Model;
using System.Data.Entity.Migrations.Utilities;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst.ReverseEngineered.Migrations
{
    class SqlCodeGenerator : CSharpMigrationCodeGenerator
    {
        protected override void Generate(
            DropIndexOperation dropIndexOperation, IndentedTextWriter writer)
        {
            dropIndexOperation.Table = StripDbo(dropIndexOperation.Table);
            Console.WriteLine("Name: {0} Table: {1} HasDefaultName: {2} Columns: {3}",
                dropIndexOperation.Name,
                dropIndexOperation.Table,
                dropIndexOperation.HasDefaultName,
                string.Join(", ", dropIndexOperation.Columns));
            base.Generate(dropIndexOperation, writer);
        }

        // TODO: Override other Generate overloads that involve table names

        private string StripDbo(string table)
        {
            if (table.StartsWith("dbo."))
            {
                table = table.Substring(4);
            }

            return table;
        }
    }
}
