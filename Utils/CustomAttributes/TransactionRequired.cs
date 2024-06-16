using System.Data;

namespace Utils.CustomAttributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = false)]
    public class TransactionRequired: Attribute
    {
        public IsolationLevel IsolationLevel { get; set; } = IsolationLevel.ReadCommitted;

        public TransactionRequired() { }

        public TransactionRequired(IsolationLevel isolationLevel)
        {
            IsolationLevel = isolationLevel;
        }
    }
}
