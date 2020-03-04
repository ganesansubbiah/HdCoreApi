namespace HDCoreApi.ApplicationCore.Entities
{
    public class OutPutJson
    {
        public int Status { get; set; }
        public string Message { get; set; }
        public object Response { get; set; }
        public int Count { get; set; }
        public int RowsAffected { get; set; }
    }
}