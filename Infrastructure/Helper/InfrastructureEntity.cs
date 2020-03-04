namespace HDCoreApi.Infrastucture.Helper{
    public class ConnectionModel{
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string SubDomain { get; set; }
        public string SqlIPAddress { get; set; }
        public string SqlLoginId { get; set; }
        public string SqlPassword { get; set; }
        public string DatabaseName { get; set; }
        public string GeoLocationSupport { get; set; }
        public string CompanyCode { get; set; }
        public string CommonPassword { get; set; }
    }
}