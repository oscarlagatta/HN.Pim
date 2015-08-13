using System;
using System.ComponentModel.Composition;
using System.ServiceModel;
using System.Threading;
using Core.Common.Contracts;
using Core.Common.Core;
using HN.Pim.Business.Entities;
using HN.Pim.Common;

namespace HN.Pim.Business.Managers
{
     [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall,
        ConcurrencyMode = ConcurrencyMode.Multiple,
        ReleaseServiceInstanceOnTransactionComplete = false)]
    public class ManagerBase
    {
        /// <summary>
        /// In the case WCF MEF cannot service the Manager class, that is the job of WCF
        /// WCF runtime will instantiate the service, we have to tell MEF to resolve the service
        /// after it's been constructed by WCF (POST CONSTRUCTION RESOLVE). Which means after the
        /// class have been constructed we tell MEF to resolve any dependencies (imports) it needs.
        /// </summary>
        public ManagerBase()
        {
            OperationContext context = OperationContext.Current;
            if (context != null)
            {
                try
                {
                    _LoginName = OperationContext.Current.IncomingMessageHeaders.GetHeader<string>("String", "System");
                    // check if it's an application which is not a website 
                    if (_LoginName.IndexOf(@"\") > -1) _LoginName = string.Empty;
                }
                catch
                {
                    _LoginName = string.Empty;
                }
            }

            // WCF worries about the default constructor, where we tell MEF to satisfy the IMPORTs after the construction of the Service
            if (ObjectBase.Container != null)
                ObjectBase.Container.SatisfyImportsOnce(this);


            if (!string.IsNullOrWhiteSpace(_LoginName))
                _AuthorizationAccount = LoadAuthorizationValidationAccount(_LoginName);
        }

        protected virtual Account LoadAuthorizationValidationAccount(string loginName)
        {
            return null;
        }

        Account _AuthorizationAccount = null;
        string _LoginName = string.Empty;

        protected void ValidateAuthorization(IAccountOwnedEntity entity)
        {
            if (!Thread.CurrentPrincipal.IsInRole(Security.eCommerceAdminRole))
            {
                if (_AuthorizationAccount != null)
                {
                    if (_LoginName != string.Empty && entity.OwnerAccountId != _AuthorizationAccount.AccountId)
                    {
                        AuthorizationValidationException ex = new AuthorizationValidationException("Attempt to access a secure record with improper user authorization validation.");
                        throw new FaultException<AuthorizationValidationException>(ex, ex.Message);
                    }
                }
            }
        }

        protected T ExecuteFaultHandledOperation<T>(Func<T> codeToExecute)
        {
            try
            {
                return codeToExecute.Invoke();
            }
            catch (FaultException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        protected void ExecuteFaultHandledOperation(Action codeToExecute)
        {
            try
            {
                codeToExecute.Invoke();
            }
            catch (FaultException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }
    }
}