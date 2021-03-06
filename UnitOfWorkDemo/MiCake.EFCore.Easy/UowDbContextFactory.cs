﻿using MiCake.Uow.Easy;
using Microsoft.EntityFrameworkCore;
using System;

namespace MiCake.EFCore.Easy
{
    internal class UowDbContextFactory<TDbContext> : IUowDbContextFactory<TDbContext>
         where TDbContext : DbContext
    {
        private readonly IUnitOfWorkManager _uowManager;

        public UowDbContextFactory(IUnitOfWorkManager uowManager)
        {
            _uowManager = uowManager;
        }

        public TDbContext CreateDbContext()
        {
            var currentUow = _uowManager.GetCurrentUnitOfWork();

            if (currentUow == null)
                throw new NullReferenceException("Cannot get a unit of work,Please check create root unit of work correctly");

            var wantedDbContext = (TDbContext)currentUow.ServiceProvider.GetService(typeof(TDbContext));

            if (wantedDbContext == null)
                throw new NullReferenceException("Cannot get DbContext.Please check add ef services correctly");

            AddDbTransactionFeatureToUow(currentUow, wantedDbContext);

            return wantedDbContext;
        }

        private void AddDbTransactionFeatureToUow(IUnitOfWork uow, TDbContext dbContext)
        {
            string key = $"EFCore - {dbContext.ContextId.InstanceId.ToString()}";

            var efFeature = (EFTransactionFeature)uow.GetOrAddTransactionFeature(key, new EFTransactionFeature(dbContext));

            if (IsFeatureNeedOpenTransaction(uow, efFeature))
            {
                var dbcontextTransaction = uow.UnitOfWorkOptions.IsolationLevel.HasValue ?
                                            dbContext.Database.BeginTransaction(uow.UnitOfWorkOptions.IsolationLevel.Value) :
                                            dbContext.Database.BeginTransaction();

                efFeature.SetTransaction(dbcontextTransaction);
            }
        }

        private bool IsFeatureNeedOpenTransaction(IUnitOfWork uow, EFTransactionFeature efFeature)
        {
            return !efFeature.IsOpenTransaction;
        }
    }
}
