namespace BAYSOFT.Abstractions.EntityFrameworkCore.Extensions
{
    public class BulkMergeOutputRow<T>
    {
        public string Action { get; set; }

        public BulkMergeOutputRow(string action)
        {
            this.Action = action;
        }
    }
}