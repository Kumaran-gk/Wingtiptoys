using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wingtiptoys.DB.Models;

namespace Wingtiptoys.client.Repository
{
    /// <summary>
    /// Common Unit of work will be used to have common reference table Repositpry
    /// No Implementation Required, Not need for any information on this assignment
    /// </summary>
    public class CommonUnitOfWork : IDisposable
    {
        
        private WingtiptoysContext context = null;
        private bool disposed = false;

        // Parameterized Constructor, Inject the DB context
        public CommonUnitOfWork(WingtiptoysContext context)
        {
            this.context = context;
        }

        public CommonUnitOfWork()
        {
            this.context = new WingtiptoysContext();
        }

        // Dispose False will clean up native resources
        // Dispose True will clear up both managed and native resources.

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    // Placeholder : To dispose the created respositories, for standard Practise
                    context.Dispose();
                }
            }
        }


        // Commit All Changes

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
